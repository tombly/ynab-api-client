using System.Text.Json;
using Ynab.Api.Client.Enums;
using Ynab.Api.Client.Models;
using Ynab.Api.Client.Responses;

namespace Ynab.Api.Client.Tests;

/// <summary>
/// Exercises the JSON conventions the YNAB API relies on: empty-string flag
/// colors, date-only formatting, null omission on writes, and the new v1.78+
/// response fields. Uses the exact serializer options the client uses.
/// </summary>
public class SerializationTests
{
    private static readonly JsonSerializerOptions Options = YnabApiClient.JsonOptions;

    [Theory]
    [InlineData("\"\"", TransactionFlagColor.Empty)]
    [InlineData("\"red\"", TransactionFlagColor.Red)]
    [InlineData("\"purple\"", TransactionFlagColor.Purple)]
    public void Flag_color_deserializes_known_values(string json, TransactionFlagColor expected)
    {
        Assert.Equal(expected, JsonSerializer.Deserialize<TransactionFlagColor>(json, Options));
    }

    [Fact]
    public void Flag_color_null_deserializes_to_null_for_nullable_property()
    {
        var summary = JsonSerializer.Deserialize<TransactionSummary>(
            """{"id":"t-1","date":"2026-06-15","amount":1000,"cleared":"cleared","approved":true,"flag_color":null,"account_id":"11111111-1111-1111-1111-111111111111","deleted":false}""",
            Options);

        Assert.Null(summary!.FlagColor);
    }

    [Fact]
    public void Flag_color_unknown_value_throws()
    {
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<TransactionFlagColor>("\"magenta\"", Options));
    }

    [Fact]
    public void Flag_color_empty_serializes_to_empty_string()
    {
        Assert.Equal("\"\"", JsonSerializer.Serialize(TransactionFlagColor.Empty, Options));
    }

    [Fact]
    public void Dates_serialize_as_date_only_strings()
    {
        var json = JsonSerializer.Serialize(new SaveScheduledTransaction
        {
            AccountId = new Guid("11111111-1111-1111-1111-111111111111"),
            Date = new DateOnly(2026, 7, 4)
        }, Options);

        Assert.Contains("\"date\":\"2026-07-04\"", json);
    }

    [Fact]
    public void Null_properties_are_omitted_when_serializing()
    {
        var json = JsonSerializer.Serialize(new SavePayee(), Options);

        Assert.Equal("{}", json);
    }

    [Fact]
    public void Missing_required_property_throws_on_deserialize()
    {
        Assert.Throws<JsonException>(() =>
            JsonSerializer.Deserialize<Payee>("""{"id":"7c8d67c8-6f9f-4f0f-9989-6d8f8f8f8f8f","deleted":false}""", Options));
    }

    [Fact]
    public void Unknown_response_fields_are_captured_as_additional_properties()
    {
        var payee = JsonSerializer.Deserialize<Payee>(
            """{"id":"7c8d67c8-6f9f-4f0f-9989-6d8f8f8f8f8f","name":"Grocer","deleted":false,"brand_new_field":42}""",
            Options);

        Assert.NotNull(payee!.AdditionalProperties);
        Assert.True(payee.AdditionalProperties.ContainsKey("brand_new_field"));
    }

    [Fact]
    public void Deserializes_plan_summary_response()
    {
        var response = JsonSerializer.Deserialize<DataEnvelope<PlanSummaryResponse>>(
            """
            {"data":{"plans":[{"id":"22222222-2222-2222-2222-222222222222","name":"My Plan",
            "last_modified_on":"2026-06-01T12:34:56Z","first_month":"2024-01-01","last_month":"2026-07-01",
            "date_format":{"format":"MM/DD/YYYY"},
            "currency_format":{"iso_code":"USD","example_format":"123,456.78","decimal_digits":2,
            "decimal_separator":".","symbol_first":true,"group_separator":",","currency_symbol":"$","display_symbol":true}}],
            "default_plan":null}}
            """,
            Options);

        var plan = Assert.Single(response!.Data.Plans);
        Assert.Equal("My Plan", plan.Name);
        Assert.Equal(new DateOnly(2024, 1, 1), plan.FirstMonth);
        Assert.Equal("USD", plan.CurrencyFormat!.IsoCode);
        Assert.Null(response.Data.DefaultPlan);
    }

    [Fact]
    public void Deserializes_transaction_detail_with_currency_fields()
    {
        var transaction = JsonSerializer.Deserialize<TransactionDetail>(
            """
            {"id":"t-1","date":"2026-06-15","amount":-123450,"amount_formatted":"-$123.45","amount_currency":-123.45,
            "cleared":"uncleared","approved":false,"flag_color":"","account_id":"11111111-1111-1111-1111-111111111111",
            "deleted":false,"account_name":"Checking","subtransactions":[
            {"id":"s-1","transaction_id":"t-1","amount":-100000,"amount_formatted":"-$100.00","amount_currency":-100.0,"deleted":false}]}
            """,
            Options);

        Assert.Equal("-$123.45", transaction!.AmountFormatted);
        Assert.Equal(-123.45, transaction.AmountCurrency);
        Assert.Equal(TransactionFlagColor.Empty, transaction.FlagColor);
        Assert.Equal(new DateOnly(2026, 6, 15), transaction.Date);
        var sub = Assert.Single(transaction.Subtransactions);
        Assert.Equal(-100.0, sub.AmountCurrency);
    }

    [Fact]
    public void Deserializes_category_with_internal_flag_and_goal_target_date()
    {
        var category = JsonSerializer.Deserialize<Category>(
            """
            {"id":"33333333-3333-3333-3333-333333333333","category_group_id":"44444444-4444-4444-4444-444444444444",
            "name":"Vacation","hidden":false,"internal":true,"budgeted":50000,"activity":0,"balance":50000,
            "goal_type":"NEED","goal_needs_whole_amount":false,"goal_target":1000000,"goal_target_date":"2026-12-01",
            "budgeted_formatted":"$50.00","budgeted_currency":50.0,"deleted":false}
            """,
            Options);

        Assert.True(category!.Internal);
        Assert.False(category.GoalNeedsWholeAmount);
        Assert.Equal(new DateOnly(2026, 12, 1), category.GoalTargetDate);
        Assert.Equal("$50.00", category.BudgetedFormatted);
    }

    [Fact]
    public void Deserializes_money_movement_response()
    {
        var response = JsonSerializer.Deserialize<DataEnvelope<MoneyMovementsResponse>>(
            """
            {"data":{"money_movements":[{"id":"55555555-5555-5555-5555-555555555555","month":"2026-06-01",
            "moved_at":"2026-06-15T08:00:00Z","money_movement_group_id":null,"from_category_id":"66666666-6666-6666-6666-666666666666",
            "to_category_id":"77777777-7777-7777-7777-777777777777","amount":25000,"amount_formatted":"$25.00","amount_currency":25.0}],
            "server_knowledge":123}}
            """,
            Options);

        var movement = Assert.Single(response!.Data.MoneyMovements);
        Assert.Equal(25000, movement.Amount);
        Assert.Equal("$25.00", movement.AmountFormatted);
        Assert.Null(movement.MoneyMovementGroupId);
        Assert.Equal(123, response.Data.ServerKnowledge);
    }

    [Fact]
    public void Save_account_type_serializes_to_api_string()
    {
        var json = JsonSerializer.Serialize(new PostAccountWrapper
        {
            Account = new SaveAccount { Name = "New Savings", Type = SaveAccountType.OtherAsset, Balance = 0 }
        }, Options);

        Assert.Contains("\"type\":\"otherAsset\"", json);
    }
}
