# Migrating from 1.x to 2.x

Version 2.0 is a breaking release with two independent causes: the YNAB API renamed budgets to plans (API v1.79.0), and the client was modernized from generated NSwag code to idiomatic hand-maintained C#. **The wire format is unchanged** — every request and response still matches the YNAB API exactly — so migration is purely a matter of renaming and type adjustments in your code. Most consumers can migrate with find-and-replace plus compiler errors as a checklist.

## 1. Budgets are now plans

YNAB renamed the budget resource to "plan". The client follows:

| 1.x | 2.x |
|---|---|
| `GetBudgetsAsync(...)` | `GetPlansAsync(...)` |
| `GetBudgetByIdAsync(...)` | `GetPlanByIdAsync(...)` |
| `GetBudgetSettingsByIdAsync(...)` | `GetPlanSettingsByIdAsync(...)` |
| `GetBudgetMonthsAsync(...)` / `GetBudgetMonthAsync(...)` | `GetPlanMonthsAsync(...)` / `GetPlanMonthAsync(...)` |
| `BudgetSummary`, `BudgetDetail`, `BudgetSettings` (+ `Response` types) | `PlanSummary`, `PlanDetail`, `PlanSettings` (+ `Response` types) |
| `.Data.Budgets`, `.Data.Default_budget`, `.Data.Budget` | `.Plans`, `.DefaultPlan`, `.Plan` (methods return the payload — see section 6) |

Requests now use the `/plans/...` endpoints. Fields that use "budget" as a money term (`budgeted`, `to_be_budgeted`, `on_budget`, `goal_months_to_budget`) are unchanged, matching the API.

## 2. Property names are now PascalCase

All model properties changed from generated `Pascal_snake_case` to standard .NET PascalCase. The JSON mapping is pinned by `[JsonPropertyName]` attributes, so serialization behavior is identical.

Examples: `Last_modified_on` → `LastModifiedOn`, `Amount_formatted` → `AmountFormatted`, `Goal_target_month` → `GoalTargetMonth`, `Server_knowledge` → `ServerKnowledge`, `Category_group_id` → `CategoryGroupId`. Mechanical rule: delete each underscore and capitalize the letter after it.

## 3. Models are now immutable records

Models changed from mutable classes to `record` types with `init`-only properties. Spec-required fields use the `required` modifier.

- **Construct with object initializers** (as before): `new SavePayee { Name = "Grocer" }`. The compiler now tells you which fields are required.
- **Modify with `with` expressions** instead of property assignment: `transaction with { Memo = "updated" }`.
- Records compare by value, which you may find convenient in tests.
- Deserialization now throws `JsonException` if the API omits a spec-required field (previously you'd get a silent default value).

## 4. Date-only fields are now `DateOnly`

Fields and parameters that carry a calendar date with no time component (`Date`, `FirstMonth`, `LastMonth`, `Month`, `GoalTargetDate`, `sinceDate`, `untilDate`, month path parameters, ...) changed from `DateTimeOffset` to `DateOnly`. Date-time fields (`LastModifiedOn`, `LastReconciledAt`, `MovedAt`, ...) remain `DateTimeOffset`.

```csharp
// 1.x
await client.GetBudgetMonthAsync(id, new DateTimeOffset(2026, 6, 1, 0, 0, 0, TimeSpan.Zero));
// 2.x
await client.GetPlanMonthAsync(id, new DateOnly(2026, 6, 1));
```

Convert an existing `DateTimeOffset` with `DateOnly.FromDateTime(value.Date)`.

## 5. One method per operation, with optional parameters

The generated code had two overloads per operation (with and without `CancellationToken`). There is now a single method with `CancellationToken cancellationToken = default`, and optional query parameters have defaults:

```csharp
// 1.x
await client.GetTransactionsAsync(budgetId, null, null, null);
// 2.x — omit what you don't need
await client.GetTransactionsAsync(planId);
await client.GetTransactionsAsync(planId, sinceDate: new DateOnly(2025, 1, 1), cancellationToken: ct);
```

Method parameters are camelCase (`budget_id` → `planId`, `since_date` → `sinceDate`, `last_knowledge_of_server` → `lastKnowledgeOfServer`); update any named arguments.

## 6. Client methods return the `data` payload directly

The YNAB API wraps every successful response in a `{ "data": ... }` envelope. In 1.x each method returned a `*Response` type mirroring that envelope; in 2.x the client unwraps it, so methods return the payload and callers drop one `.Data` hop:

```csharp
// 1.x
var plans = (await client.GetBudgetsAsync(null)).Data.Budgets;
// 2.x
var plans = (await client.GetPlansAsync()).Plans;
```

The `*Response` types keep their 1.x names (`AccountsResponse`, `TransactionsResponse`, `SaveTransactionsResponse`, ...) but now represent the flattened payload, so `ServerKnowledge` and the entities sit directly on them instead of under `.Data`. `ErrorResponse` is unchanged (see error handling below).

## 7. Renamed and moved types

Namespaces now match the folder structure. In 1.x every type lived in `Ynab.Api.Client`; in 2.x the client and interface stay there, while models, responses, enums, and the exceptions move to sub-namespaces. Add the usings you need:

```csharp
using Ynab.Api.Client;            // YnabApiClient, IYnabApiClient
using Ynab.Api.Client.Models;     // Account, Category, request wrappers, ...
using Ynab.Api.Client.Responses;  // *Response payloads, ErrorResponse
using Ynab.Api.Client.Enums;      // AccountType, TransactionFlagColor, ...
using Ynab.Api.Client.Utils;      // ApiException, ApiException<T>
```

| 1.x | 2.x |
|---|---|
| `Ynab.Api.Client.Type` (enum) | `TransactionFilterType` |
| `TransactionSummaryDebtTransactionType` (enum) | `DebtTransactionType` |
| `ScheduledTransactionSummaryFrequency` (enum) | `ScheduledTransactionFrequency` (was an identical duplicate; consolidated) |
| `YnabApiClient.ApiException<TResult>` (nested) | `ApiException<TResult>` (namespace level) |
| `ICollection<T>` collection properties | `IReadOnlyList<T>` |

`catch (YnabApiClient.ApiException<ErrorResponse> e)` becomes `catch (ApiException<ErrorResponse> e)`.

## 8. Error handling changes

- Any non-2xx response with a parseable YNAB error body throws `ApiException<ErrorResponse>`; the exception `Message` is now the API's own error detail (e.g. "Plan not found") instead of a generic spec description. `StatusCode`, `Response`, `Headers`, and `Result` are still available.
- Non-2xx responses with unparseable bodies throw plain `ApiException` with the raw body in `Response`.

## 9. Removed NSwag artifacts

These 1.x members had no replacements because they were generator plumbing:

- The `YnabApiClient(HttpClient, JsonSerializerOptions)` constructor — serialization is fixed to match the API; there is nothing safe to customize.
- `ReadResponseAsString`, `PrepareRequest`/`ProcessResponse` partial hooks — use a `DelegatingHandler` on your `HttpClient` for cross-cutting concerns.
- `[Required]`/`[StringLength]` DataAnnotations on models — these were never enforced; `required` members now provide compile-time enforcement where it matters.
- The `Bulk`, `BulkTransactions`, `BulkData`, and `BulkResponse` types — the deprecated bulk endpoint was removed from the YNAB API long ago, so these were unreachable dead code.

## 10. Behavior note: `since_date` defaults server-side

Unrelated to this package's changes: as of YNAB API v1.85.0, transaction listings default `since_date` to **one year ago** when not specified. Pass an explicit `sinceDate` to retrieve older transactions.

## Versioning going forward

1.x package versions mirrored the YNAB API version (e.g. `1.77.0.x`). From 2.0.0 the package follows [SemVer](https://semver.org) — breaking changes bump the major version — and the YNAB API version it tracks is stated in the release notes.
