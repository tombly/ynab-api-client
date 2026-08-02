# YNAB.API.Client

A simple and maintainable .NET 10+ client for the [YNAB API](https://api.ynab.com) with no dependencies. Modern, idiomatic C#: immutable record models with `required` members, `DateOnly` for dates, optional parameters, and full IntelliSense documentation. The API surface is kept in sync with the OpenAPI specification committed to this repo (`open_api_spec.yaml`), and a spec-coverage test suite verifies that every API operation has a corresponding client method.

The package follows [SemVer](https://semver.org): breaking changes bump the major version. The YNAB API version the package was built against is listed in the release notes of each version (currently **YNAB API v1.86.0**).

> **Upgrading from 1.x?** Version 2.0 renames budgets to plans (following YNAB API v1.79.0) and modernizes the whole API surface. See [MIGRATING.md](MIGRATING.md) for the complete guide. Also note a server-side behavior change in API v1.85.0: transaction listings now default `since_date` to one year ago — pass an explicit `sinceDate` to retrieve older transactions.

## Usage

Add the nuget to your app:

```shell
dotnet add package Ynab.Api.Client
```

Create [an access token](https://api.ynab.com/#authentication-overview) via [the YNAB website](https://app.ynab.com/settings) and add it to the following code snippet, which shows how to add the client to your app's services (you can alternatively just instantiate the client directly if preferred):

``` csharp
services.AddSingleton<IYnabApiClient>(sp =>
{
    var accessToken = "<YOUR ACCESS TOKEN>";
    return new YnabApiClient(new HttpClient()
    {
        DefaultRequestHeaders = {
            Authorization = new AuthenticationHeaderValue("Bearer", accessToken)
        }
    });
});

...

public class MyClass(IYnabApiClient ynabClient)
{
    public async Task PrintPlansAsync()
    {
        var plans = (await ynabClient.GetPlansAsync()).Plans;
        foreach (var plan in plans)
        {
            Console.WriteLine($"Plan Name: {plan.Name}");
        }
    }
}
```

## How to update

The YNAB OpenAPI specification is committed at the repo root (`open_api_spec.yaml`) and is the source of truth for the client's API surface. To update the client for a new YNAB API version, download the latest spec, diff it against the committed copy, and apply the changes to the client code — the diff is the work order and the review checklist. This works well as an AI-assisted workflow; see [UPDATING.md](UPDATING.md) for the step-by-step process and the code conventions to follow.

The test suite keeps the process honest: it verifies that every operation in the spec has a client method (and vice versa), that requests are constructed correctly, and that the YNAB API's serialization quirks (empty-string flag colors, date-only fields, null omission) keep working.

```shell
dotnet test
```

## License

Copyright (c) 2026 Tom Bulatewicz

Licensed under the MIT license
