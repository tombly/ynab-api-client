# Updating the client for a new YNAB API version

This client is maintained by diffing the committed OpenAPI spec against YNAB's latest spec and applying the changes by hand (or with an AI agent). The spec file is the source of truth for the API surface; the test suite verifies the client matches it.

## Process

1. **Download the latest spec over the committed copy:**

   ```shell
   curl -s https://api.ynab.com/papi/open_api_spec.yaml -o open_api_spec.yaml
   git diff open_api_spec.yaml
   ```

   The diff is the complete work order. Also skim the [changelog](https://api.ynab.com/#changelog) for context on why things changed.

2. **Apply the changes** to the corresponding C# code:

   | Spec change | Where to apply |
   |---|---|
   | New/changed schema property | Matching record in `Models/` (or `Responses/` for `*Response` payload records) |
   | New/changed enum | `Enums/` |
   | New operation | One method in `IYnabApiClient.cs` (with XML docs) and one in `YnabApiClient.cs` (with `/// <inheritdoc />`), calling `SendAsync<TResponse>` — copy the closest existing method |
   | New/changed query or path parameter | The operation's method in both files; query strings are built with the `Query(...)` helper |
   | Changed descriptions | XML doc comments (mirror the spec text) |

3. **Run the tests:**

   ```shell
   dotnet test
   ```

   `SpecCoverageTests` fails if any spec operation is missing a client method or the client has a method the spec no longer defines. Add serialization tests for new fields or converters.

4. **Bump the version** in `Ynab.Api.Client.csproj` (SemVer: breaking changes bump major) and update `PackageReleaseNotes` to state the YNAB API version (the `Package_version_notes_match_spec_version` test enforces the format `YNAB API v<spec version>`).

5. **Update the README** if the changes affect the usage examples, and **MIGRATING.md** if the release is breaking.

## Code conventions

- **Namespaces match folders.** `Models/` → `Ynab.Api.Client.Models`, `Responses/` → `.Responses`, `Enums/` → `.Enums`, `Utils/` → `.Utils`; the client and interface at the repo root stay in `Ynab.Api.Client`.
- **Models are records.** `sealed record` (or non-sealed when inherited, e.g. `TransactionSummary`), `init`-only properties, PascalCase names, one `[JsonPropertyName]` attribute per property carrying the exact wire name. Spec-required fields get the `required` modifier; optional fields are nullable. Property doc comments are single-line `/// <summary>...</summary>` mirroring the spec description. Every record ends with the two-line `[JsonExtensionData] AdditionalProperties` property for forward compatibility. Copy an existing record as a template.
- **allOf flattening.** The spec composes schemas as `FooBase` + `Foo` (allOf) pairs, mostly to layer on `*_formatted`/`*_currency` fields. This client flattens each pair into a single record (`Account`, `Category`, `TransactionSummary`, ...) since the extra fields are nullable and simply absent from contexts that don't send them. True subtype relationships (e.g. `TransactionDetail : TransactionSummary`) use inheritance.
- **Response payloads.** The API wraps every success response as `{ "data": ... }`, which the spec models as `FooResponse` schemas with an inline `data` object. The client represents that envelope exactly once — the internal generic `DataEnvelope<T>` in `Responses/`, unwrapped inside `SendAsync` — so a spec `FooResponse` becomes a C# `FooResponse` record modeling the *inner `data` object* (the envelope level is flattened away), and client methods return it directly (e.g. `getAccounts` returns `Task<AccountsResponse>` with `Accounts` and `ServerKnowledge` on it). `ErrorResponse` models the full error body since the error envelope has a different shape.
- **Dates.** Spec `format: date` fields and parameters are `DateOnly` (System.Text.Json handles them natively as `yyyy-MM-dd`); `format: date-time` fields are `DateTimeOffset`. No date converters.
- **Enums** use `[JsonStringEnumMemberName]` on each member. A single global `JsonStringEnumConverter` in `YnabApiClient.JsonOptions` handles all of them — no per-property converter attributes. Exception: `TransactionFlagColor` is handled by the hand-written `TransactionFlagColorConverter` (registered first in `JsonOptions`) because the API sends empty strings.
- **Client methods** are thin: null-check arguments, build the relative URL with an interpolated string plus the `Escape`/`Query` helpers, and delegate to `SendAsync<TResponse>`. All HTTP mechanics (headers, body serialization, status handling, envelope unwrapping, error mapping) live only in `SendAsync`. Method parameters are camelCase; optional query parameters get `= null` defaults; every method ends with `CancellationToken cancellationToken = default`.
- **Docs live on the interface.** `IYnabApiClient.cs` carries the full XML docs (summaries from the spec's operation descriptions); implementations use `/// <inheritdoc />`.
- **Errors.** Non-2xx responses throw `ApiException<ErrorResponse>` when the body parses as a YNAB error (message = the error `detail`), otherwise plain `ApiException`. Both live in `Utils/ApiException.cs`.

## Escape hatch: full regeneration

If YNAB ever ships a v2-style overhaul too large to patch, generate a fresh reference client from the spec (NSwag CLI or Kiota) into a scratch directory and use it **only as a comparison target** — this codebase is hand-written and must not be overwritten with generated output. Note that the spec is OpenAPI 3.1, which NSwag's support for is incomplete; verify the generated output carefully.
