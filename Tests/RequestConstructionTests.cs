using System.Net;
using Ynab.Api.Client.Enums;
using Ynab.Api.Client.Models;
using Ynab.Api.Client.Responses;
using Ynab.Api.Client.Utils;

namespace Ynab.Api.Client.Tests;

public class RequestConstructionTests
{
    private const string EmptyPlansJson = """{"data":{"plans":[]}}""";
    private const string EmptyTransactionsJson = """{"data":{"transactions":[],"server_knowledge":0}}""";

    [Fact]
    public async Task GetPlans_hits_plans_endpoint()
    {
        var client = FakeHttpMessageHandler.CreateClient(out var handler, EmptyPlansJson);

        await client.GetPlansAsync();

        Assert.Equal(HttpMethod.Get, handler.Request!.Method);
        Assert.Equal("https://api.ynab.com/v1/plans", handler.Request.RequestUri!.ToString());
    }

    [Fact]
    public async Task GetTransactions_includes_since_until_and_type_query_parameters()
    {
        var client = FakeHttpMessageHandler.CreateClient(out var handler, EmptyTransactionsJson);

        await client.GetTransactionsAsync(
            "plan-1",
            sinceDate: new DateOnly(2026, 1, 15),
            untilDate: new DateOnly(2026, 6, 30),
            type: TransactionFilterType.Uncategorized,
            lastKnowledgeOfServer: 42);

        var url = handler.Request!.RequestUri!.ToString();
        Assert.StartsWith("https://api.ynab.com/v1/plans/plan-1/transactions?", url);
        Assert.Contains("since_date=2026-01-15", url);
        Assert.Contains("until_date=2026-06-30", url);
        Assert.Contains("type=uncategorized", url);
        Assert.Contains("last_knowledge_of_server=42", url);
    }

    [Fact]
    public async Task GetMoneyMovementsByMonth_formats_month_path_segment_as_date()
    {
        var client = FakeHttpMessageHandler.CreateClient(out var handler,
            """{"data":{"money_movements":[],"server_knowledge":0}}""");

        await client.GetMoneyMovementsByMonthAsync("plan-1", new DateOnly(2026, 6, 1));

        Assert.Equal("https://api.ynab.com/v1/plans/plan-1/months/2026-06-01/money_movements",
            handler.Request!.RequestUri!.ToString());
    }

    [Fact]
    public async Task CreatePayee_posts_wrapped_payee_body()
    {
        var client = FakeHttpMessageHandler.CreateClient(out var handler,
            """{"data":{"payee":{"id":"7c8d67c8-6f9f-4f0f-9989-6d8f8f8f8f8f","name":"Grocer","deleted":false},"server_knowledge":1}}""",
            HttpStatusCode.Created);

        var response = await client.CreatePayeeAsync("plan-1", new PostPayeeWrapper { Payee = new PostPayee { Name = "Grocer" } });

        Assert.Equal(HttpMethod.Post, handler.Request!.Method);
        Assert.Equal("https://api.ynab.com/v1/plans/plan-1/payees", handler.Request.RequestUri!.ToString());
        Assert.Equal("""{"payee":{"name":"Grocer"}}""", handler.RequestBody);
        Assert.Equal("Grocer", response.Payee.Name);
    }

    [Fact]
    public async Task UpdateCategoryGroup_patches_category_group_by_id()
    {
        var client = FakeHttpMessageHandler.CreateClient(out var handler,
            """{"data":{"category_group":{"id":"3c8d67c8-6f9f-4f0f-9989-6d8f8f8f8f8f","name":"Bills","hidden":false,"internal":false,"deleted":false},"server_knowledge":2}}""");

        await client.UpdateCategoryGroupAsync("plan-1", "group-9",
            new PatchCategoryGroupWrapper { CategoryGroup = new SaveCategoryGroup { Name = "Bills" } });

        Assert.Equal(HttpMethod.Patch, handler.Request!.Method);
        Assert.Equal("https://api.ynab.com/v1/plans/plan-1/category_groups/group-9", handler.Request.RequestUri!.ToString());
        Assert.Equal("""{"category_group":{"name":"Bills"}}""", handler.RequestBody);
    }

    [Fact]
    public async Task CreateTransaction_omits_null_properties_from_body()
    {
        var client = FakeHttpMessageHandler.CreateClient(out var handler,
            """{"data":{"transaction_ids":[],"server_knowledge":0}}""",
            HttpStatusCode.Created);

        await client.CreateTransactionAsync("plan-1", new PostTransactionsWrapper
        {
            Transaction = new NewTransaction
            {
                AccountId = new Guid("11111111-1111-1111-1111-111111111111"),
                Date = new DateOnly(2026, 7, 1),
                Amount = -12340
            }
        });

        Assert.Contains("\"transaction\":", handler.RequestBody);
        Assert.DoesNotContain("\"transactions\"", handler.RequestBody);
        Assert.DoesNotContain("\"memo\"", handler.RequestBody);
        Assert.DoesNotContain("null", handler.RequestBody);
        Assert.Contains("\"date\":\"2026-07-01\"", handler.RequestBody);
    }

    [Fact]
    public async Task Error_response_throws_typed_api_exception_with_error_detail()
    {
        var client = FakeHttpMessageHandler.CreateClient(out _,
            """{"error":{"id":"404.2","name":"resource_not_found","detail":"Plan not found"}}""",
            HttpStatusCode.NotFound);

        var exception = await Assert.ThrowsAsync<ApiException<ErrorResponse>>(
            () => client.GetPlanByIdAsync("nope"));

        Assert.Equal(404, exception.StatusCode);
        Assert.Equal("resource_not_found", exception.Result.Error.Name);
        Assert.Equal("Plan not found", exception.Result.Error.Detail);
        Assert.Equal("Plan not found", exception.Message);
    }

    [Fact]
    public async Task Unparseable_error_response_throws_untyped_api_exception()
    {
        var client = FakeHttpMessageHandler.CreateClient(out _, "<html>gateway timeout</html>", HttpStatusCode.BadGateway);

        var exception = await Assert.ThrowsAsync<ApiException>(() => client.GetUserAsync());

        Assert.Equal(502, exception.StatusCode);
        Assert.Equal("<html>gateway timeout</html>", exception.Response);
    }

    [Fact]
    public async Task BaseUrl_can_be_redirected_for_testing()
    {
        var client = FakeHttpMessageHandler.CreateClient(out var handler, EmptyPlansJson);
        client.BaseUrl = "https://localhost:5001/v1";

        await client.GetPlansAsync();

        Assert.Equal("https://localhost:5001/v1/plans", handler.Request!.RequestUri!.ToString());
    }
}
