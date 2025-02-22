# YNAB.API.Client

A simple and maintainable .NET 8+ client for the [YNAB API](https://api.youneedabudget.com). This client was generated using [NSwag Studio](https://github.com/RicoSuter/NSwag/wiki/NSwagStudio) with very few manual changes and has no dependencies. This allows the client to be quickly regenerated as both the YNAB API and .NET SDK evolve over the years.

These are the configuration options used in NSwag:
- Namespace: Ynab.Api
- ☑ Generate optional schema properties as nullable
- ☑ Generate nullable Reference Type annotations
- Select: SystemTextJson
- Output: Path to a single .cs file

It generates one big file so [Rider](https://www.jetbrains.com/rider/) was used to automatically separate all the classes and types into individual files (some of the classes were also renamed to be more descriptive).

## Usage

Add the nuget to your app:

```shell
dotnet add package ynab.api.client
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

## License

Copyright (c) 2025 Tom Bulatewicz

Licensed under the MIT license