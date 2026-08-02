# Ynab.Api.Client

A dependency-free .NET client NuGet for the YNAB API. The committed `open_api_spec.yaml` is the source of truth for the API surface; the client code mirrors it exactly. The code is hand-maintained modern C# (originally generated, since fully modernized) — never regenerate it with NSwag or another generator.

- To update for a new YNAB API version, follow **UPDATING.md** (download spec, diff, apply changes, `dotnet test`).
- House style (UPDATING.md documents the details): models are records with `required`/`init` PascalCase properties and `[JsonPropertyName]` wire names; `DateOnly` for date-only fields; enums via a global `JsonStringEnumConverter`; client methods are thin wrappers over the single `SendAsync<T>` helper, which unwraps the API's `{ "data": ... }` envelope so the `*Response` records model the spec's inner `data` object and methods return them directly; full XML docs live on `IYnabApiClient`, implementations use `inheritdoc`. Copy the nearest existing record/method as a template.
- `Tests/SpecCoverageTests.cs` fails when the client and spec disagree — run `dotnet test` after any API-surface change.
- Versioning is SemVer, decoupled from the YNAB API version; `PackageReleaseNotes` must state `YNAB API v<spec version>` (enforced by a test). Breaking releases get a MIGRATING.md section.
