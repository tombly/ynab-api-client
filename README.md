# YNAB.API.Client

A simple and maintainable .NET 9+ client for the [YNAB API](https://api.youneedabudget.com). This client was generated using [NSwag Studio](https://github.com/RicoSuter/NSwag/wiki/NSwagStudio) with very few manual changes and has no dependencies. This allows the client to be quickly regenerated as both the YNAB API and .NET SDK evolve over the years. The version number (major/minor) matches the [YNAB API version](https://api.ynab.com/#changelog) it was built from.

## Usage

Add the nuget to your app:

```shell
dotnet add package Ynab.Api.Client
```

Create [an access token](https://api.ynab.com/#authentication-overview) via [the YNAB website](https://app.ynab.com/settings) and add it to the following code snippet, which shows how to add the client to your app's services (you can alternatively just instantiate the client directly if preferred):

``` csharp
services.AddSingleton<YnabApiClient>(sp =>
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

public class MyClass(YnabApiClient ynabClient)
{
  (await _ynabClient.GetBudgetsAsync(false)).Data.Budgets
    .ToList()
    .ForEach(budget => {
      Console.WriteLine($"Budget Name: {budget.Name}");
  });
}
```

## How to update

Download NSwag Studio and launch it. Select `Net90` as the Runtime and enter the following as the Specification URL: `https://api.ynab.com/papi/open_api_spec.yaml`. Choose `CSharp Client` and use all the defaults except for:

- Namespace: `Ynab.Api.Client`
- ☑ Generate optional schema properties as nullable
- ☑ Generate nullable Reference Type annotations
- Select: SystemTextJson
- Output: Path to a file named `YnabApiClient.cs`

Click `Generate files`. It generates one big file so you can use [Rider](https://www.jetbrains.com/rider/) to automatically separate all the classes and types into individual files. Then clean up a few things:

- Create folders: `Enums`, `Models`, `Responses`, `Utils`
- Move files with the suffix `Response` into Responses
- Move files with the suffix `Type` into Enums
- Move files with the suffix `Data` into Responses
- Move remaining files into Models
- Rename each file with the suffix `Data` based on the response that uses it.
- Use your favorite AI agent to extract an `IYnabApiClient` interface.

## License

Copyright (c) 2025 Tom Bulatewicz

Licensed under the MIT license