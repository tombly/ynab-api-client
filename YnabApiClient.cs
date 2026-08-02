using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using Ynab.Api.Client.Enums;
using Ynab.Api.Client.Models;
using Ynab.Api.Client.Responses;
using Ynab.Api.Client.Utils;

namespace Ynab.Api.Client;

/// <summary>A client for the YNAB API (https://api.ynab.com).</summary>
/// <param name="httpClient">The HTTP client to send requests with. Configure its default request headers with a bearer access token.</param>
public class YnabApiClient(HttpClient httpClient) : IYnabApiClient
{
    internal static readonly JsonSerializerOptions JsonOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters = { new TransactionFlagColorConverter(), new JsonStringEnumConverter() }
    };

    private string _baseUrl = "https://api.ynab.com/v1/";

    /// <inheritdoc />
    public string BaseUrl
    {
        get => _baseUrl;
        set => _baseUrl = value.EndsWith('/') ? value : value + '/';
    }

    /// <inheritdoc />
    public Task<UserResponse> GetUserAsync(CancellationToken cancellationToken = default)
        => SendAsync<UserResponse>(HttpMethod.Get, "user", null, cancellationToken);

    /// <inheritdoc />
    public Task<PlanSummaryResponse> GetPlansAsync(bool? includeAccounts = null, CancellationToken cancellationToken = default)
        => SendAsync<PlanSummaryResponse>(HttpMethod.Get,
            $"plans{Query(("include_accounts", includeAccounts))}", null, cancellationToken);

    /// <inheritdoc />
    public Task<PlanDetailResponse> GetPlanByIdAsync(string planId, long? lastKnowledgeOfServer = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        return SendAsync<PlanDetailResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}{Query(("last_knowledge_of_server", lastKnowledgeOfServer))}", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<PlanSettingsResponse> GetPlanSettingsByIdAsync(string planId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        return SendAsync<PlanSettingsResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}/settings", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<AccountsResponse> GetAccountsAsync(string planId, long? lastKnowledgeOfServer = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        return SendAsync<AccountsResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}/accounts{Query(("last_knowledge_of_server", lastKnowledgeOfServer))}", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<AccountResponse> CreateAccountAsync(string planId, PostAccountWrapper body, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(body);
        return SendAsync<AccountResponse>(HttpMethod.Post,
            $"plans/{Escape(planId)}/accounts", body, cancellationToken);
    }

    /// <inheritdoc />
    public Task<AccountResponse> GetAccountByIdAsync(string planId, Guid accountId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        return SendAsync<AccountResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}/accounts/{accountId}", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<CategoriesResponse> GetCategoriesAsync(string planId, long? lastKnowledgeOfServer = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        return SendAsync<CategoriesResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}/categories{Query(("last_knowledge_of_server", lastKnowledgeOfServer))}", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<SaveCategoryResponse> CreateCategoryAsync(string planId, PostCategoryWrapper body, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(body);
        return SendAsync<SaveCategoryResponse>(HttpMethod.Post,
            $"plans/{Escape(planId)}/categories", body, cancellationToken);
    }

    /// <inheritdoc />
    public Task<CategoryResponse> GetCategoryByIdAsync(string planId, string categoryId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(categoryId);
        return SendAsync<CategoryResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}/categories/{Escape(categoryId)}", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<SaveCategoryResponse> UpdateCategoryAsync(string planId, string categoryId, PatchCategoryWrapper body, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(categoryId);
        ArgumentNullException.ThrowIfNull(body);
        return SendAsync<SaveCategoryResponse>(HttpMethod.Patch,
            $"plans/{Escape(planId)}/categories/{Escape(categoryId)}", body, cancellationToken);
    }

    /// <inheritdoc />
    public Task<CategoryResponse> GetMonthCategoryByIdAsync(string planId, DateOnly month, string categoryId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(categoryId);
        return SendAsync<CategoryResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}/months/{Escape(month)}/categories/{Escape(categoryId)}", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<SaveCategoryResponse> UpdateMonthCategoryAsync(string planId, DateOnly month, string categoryId, PatchMonthCategoryWrapper body, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(categoryId);
        ArgumentNullException.ThrowIfNull(body);
        return SendAsync<SaveCategoryResponse>(HttpMethod.Patch,
            $"plans/{Escape(planId)}/months/{Escape(month)}/categories/{Escape(categoryId)}", body, cancellationToken);
    }

    /// <inheritdoc />
    public Task<SaveCategoryGroupResponse> CreateCategoryGroupAsync(string planId, PostCategoryGroupWrapper body, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(body);
        return SendAsync<SaveCategoryGroupResponse>(HttpMethod.Post,
            $"plans/{Escape(planId)}/category_groups", body, cancellationToken);
    }

    /// <inheritdoc />
    public Task<SaveCategoryGroupResponse> UpdateCategoryGroupAsync(string planId, string categoryGroupId, PatchCategoryGroupWrapper body, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(categoryGroupId);
        ArgumentNullException.ThrowIfNull(body);
        return SendAsync<SaveCategoryGroupResponse>(HttpMethod.Patch,
            $"plans/{Escape(planId)}/category_groups/{Escape(categoryGroupId)}", body, cancellationToken);
    }

    /// <inheritdoc />
    public Task<PayeesResponse> GetPayeesAsync(string planId, long? lastKnowledgeOfServer = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        return SendAsync<PayeesResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}/payees{Query(("last_knowledge_of_server", lastKnowledgeOfServer))}", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<SavePayeeResponse> CreatePayeeAsync(string planId, PostPayeeWrapper body, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(body);
        return SendAsync<SavePayeeResponse>(HttpMethod.Post,
            $"plans/{Escape(planId)}/payees", body, cancellationToken);
    }

    /// <inheritdoc />
    public Task<PayeeResponse> GetPayeeByIdAsync(string planId, string payeeId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(payeeId);
        return SendAsync<PayeeResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}/payees/{Escape(payeeId)}", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<SavePayeeResponse> UpdatePayeeAsync(string planId, string payeeId, PatchPayeeWrapper body, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(payeeId);
        ArgumentNullException.ThrowIfNull(body);
        return SendAsync<SavePayeeResponse>(HttpMethod.Patch,
            $"plans/{Escape(planId)}/payees/{Escape(payeeId)}", body, cancellationToken);
    }

    /// <inheritdoc />
    public Task<PayeeLocationsResponse> GetPayeeLocationsAsync(string planId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        return SendAsync<PayeeLocationsResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}/payee_locations", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<PayeeLocationResponse> GetPayeeLocationByIdAsync(string planId, string payeeLocationId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(payeeLocationId);
        return SendAsync<PayeeLocationResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}/payee_locations/{Escape(payeeLocationId)}", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<PayeeLocationsResponse> GetPayeeLocationsByPayeeAsync(string planId, string payeeId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(payeeId);
        return SendAsync<PayeeLocationsResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}/payees/{Escape(payeeId)}/payee_locations", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<MonthSummariesResponse> GetPlanMonthsAsync(string planId, long? lastKnowledgeOfServer = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        return SendAsync<MonthSummariesResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}/months{Query(("last_knowledge_of_server", lastKnowledgeOfServer))}", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<MonthDetailResponse> GetPlanMonthAsync(string planId, DateOnly month, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        return SendAsync<MonthDetailResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}/months/{Escape(month)}", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<MoneyMovementsResponse> GetMoneyMovementsAsync(string planId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        return SendAsync<MoneyMovementsResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}/money_movements", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<MoneyMovementsResponse> GetMoneyMovementsByMonthAsync(string planId, DateOnly month, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        return SendAsync<MoneyMovementsResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}/months/{Escape(month)}/money_movements", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<MoneyMovementGroupsResponse> GetMoneyMovementGroupsAsync(string planId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        return SendAsync<MoneyMovementGroupsResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}/money_movement_groups", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<MoneyMovementGroupsResponse> GetMoneyMovementGroupsByMonthAsync(string planId, DateOnly month, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        return SendAsync<MoneyMovementGroupsResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}/months/{Escape(month)}/money_movement_groups", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<TransactionsResponse> GetTransactionsAsync(string planId, DateOnly? sinceDate = null, DateOnly? untilDate = null, TransactionFilterType? type = null, long? lastKnowledgeOfServer = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        return SendAsync<TransactionsResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}/transactions{TransactionsQuery(sinceDate, untilDate, type, lastKnowledgeOfServer)}", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<SaveTransactionsResponse> CreateTransactionAsync(string planId, PostTransactionsWrapper body, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(body);
        return SendAsync<SaveTransactionsResponse>(HttpMethod.Post,
            $"plans/{Escape(planId)}/transactions", body, cancellationToken);
    }

    /// <inheritdoc />
    public Task<SaveTransactionsResponse> UpdateTransactionsAsync(string planId, PatchTransactionsWrapper body, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(body);
        return SendAsync<SaveTransactionsResponse>(HttpMethod.Patch,
            $"plans/{Escape(planId)}/transactions", body, cancellationToken);
    }

    /// <inheritdoc />
    public Task<TransactionsImportResponse> ImportTransactionsAsync(string planId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        return SendAsync<TransactionsImportResponse>(HttpMethod.Post,
            $"plans/{Escape(planId)}/transactions/import", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<TransactionResponse> GetTransactionByIdAsync(string planId, string transactionId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(transactionId);
        return SendAsync<TransactionResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}/transactions/{Escape(transactionId)}", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<TransactionResponse> UpdateTransactionAsync(string planId, string transactionId, PutTransactionWrapper body, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(transactionId);
        ArgumentNullException.ThrowIfNull(body);
        return SendAsync<TransactionResponse>(HttpMethod.Put,
            $"plans/{Escape(planId)}/transactions/{Escape(transactionId)}", body, cancellationToken);
    }

    /// <inheritdoc />
    public Task<TransactionResponse> DeleteTransactionAsync(string planId, string transactionId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(transactionId);
        return SendAsync<TransactionResponse>(HttpMethod.Delete,
            $"plans/{Escape(planId)}/transactions/{Escape(transactionId)}", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<TransactionsResponse> GetTransactionsByAccountAsync(string planId, string accountId, DateOnly? sinceDate = null, DateOnly? untilDate = null, TransactionFilterType? type = null, long? lastKnowledgeOfServer = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(accountId);
        return SendAsync<TransactionsResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}/accounts/{Escape(accountId)}/transactions{TransactionsQuery(sinceDate, untilDate, type, lastKnowledgeOfServer)}", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<HybridTransactionsResponse> GetTransactionsByCategoryAsync(string planId, string categoryId, DateOnly? sinceDate = null, DateOnly? untilDate = null, TransactionFilterType? type = null, long? lastKnowledgeOfServer = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(categoryId);
        return SendAsync<HybridTransactionsResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}/categories/{Escape(categoryId)}/transactions{TransactionsQuery(sinceDate, untilDate, type, lastKnowledgeOfServer)}", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<HybridTransactionsResponse> GetTransactionsByPayeeAsync(string planId, string payeeId, DateOnly? sinceDate = null, DateOnly? untilDate = null, TransactionFilterType? type = null, long? lastKnowledgeOfServer = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(payeeId);
        return SendAsync<HybridTransactionsResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}/payees/{Escape(payeeId)}/transactions{TransactionsQuery(sinceDate, untilDate, type, lastKnowledgeOfServer)}", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<TransactionsResponse> GetTransactionsByMonthAsync(string planId, string month, DateOnly? sinceDate = null, DateOnly? untilDate = null, TransactionFilterType? type = null, long? lastKnowledgeOfServer = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(month);
        return SendAsync<TransactionsResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}/months/{Escape(month)}/transactions{TransactionsQuery(sinceDate, untilDate, type, lastKnowledgeOfServer)}", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<ScheduledTransactionsResponse> GetScheduledTransactionsAsync(string planId, long? lastKnowledgeOfServer = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        return SendAsync<ScheduledTransactionsResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}/scheduled_transactions{Query(("last_knowledge_of_server", lastKnowledgeOfServer))}", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<ScheduledTransactionResponse> CreateScheduledTransactionAsync(string planId, PostScheduledTransactionWrapper body, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(body);
        return SendAsync<ScheduledTransactionResponse>(HttpMethod.Post,
            $"plans/{Escape(planId)}/scheduled_transactions", body, cancellationToken);
    }

    /// <inheritdoc />
    public Task<ScheduledTransactionResponse> GetScheduledTransactionByIdAsync(string planId, string scheduledTransactionId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(scheduledTransactionId);
        return SendAsync<ScheduledTransactionResponse>(HttpMethod.Get,
            $"plans/{Escape(planId)}/scheduled_transactions/{Escape(scheduledTransactionId)}", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<ScheduledTransactionResponse> UpdateScheduledTransactionAsync(string planId, string scheduledTransactionId, PutScheduledTransactionWrapper body, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(scheduledTransactionId);
        ArgumentNullException.ThrowIfNull(body);
        return SendAsync<ScheduledTransactionResponse>(HttpMethod.Put,
            $"plans/{Escape(planId)}/scheduled_transactions/{Escape(scheduledTransactionId)}", body, cancellationToken);
    }

    /// <inheritdoc />
    public Task<ScheduledTransactionResponse> DeleteScheduledTransactionAsync(string planId, string scheduledTransactionId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(planId);
        ArgumentNullException.ThrowIfNull(scheduledTransactionId);
        return SendAsync<ScheduledTransactionResponse>(HttpMethod.Delete,
            $"plans/{Escape(planId)}/scheduled_transactions/{Escape(scheduledTransactionId)}", null, cancellationToken);
    }

    private async Task<TResponse> SendAsync<TResponse>(HttpMethod method, string url, object? body, CancellationToken cancellationToken)
    {
        using var request = new HttpRequestMessage(method, new Uri(_baseUrl + url, UriKind.RelativeOrAbsolute));
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        if (body is not null)
        {
            request.Content = new ByteArrayContent(JsonSerializer.SerializeToUtf8Bytes(body, body.GetType(), JsonOptions));
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        }

        using var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
        var headers = response.Headers.Concat(response.Content.Headers).ToDictionary(h => h.Key, h => h.Value);
        var statusCode = (int)response.StatusCode;

        if (!response.IsSuccessStatusCode)
        {
            var responseText = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
            throw TryParseError(responseText, out var error)
                ? new ApiException<ErrorResponse>(error.Error.Detail, statusCode, responseText, headers, error)
                : new ApiException($"The HTTP status code of the response was not expected ({statusCode}).", statusCode, responseText, headers);
        }

        try
        {
            await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
            var envelope = await JsonSerializer.DeserializeAsync<DataEnvelope<TResponse>>(stream, JsonOptions, cancellationToken).ConfigureAwait(false);
            return envelope is null
                ? throw new ApiException("Response was null which was not expected.", statusCode, null, headers)
                : envelope.Data;
        }
        catch (JsonException exception)
        {
            throw new ApiException($"Could not deserialize the response body as {typeof(TResponse).FullName}.", statusCode, null, headers, exception);
        }
    }

    private static bool TryParseError(string responseText, [NotNullWhen(true)] out ErrorResponse? error)
    {
        try
        {
            error = JsonSerializer.Deserialize<ErrorResponse>(responseText, JsonOptions);
            return error is not null;
        }
        catch (JsonException)
        {
            error = null;
            return false;
        }
    }

    private static string Escape(string value) => Uri.EscapeDataString(value);

    private static string Escape(DateOnly value) => value.ToString("O");

    private static string TransactionsQuery(DateOnly? sinceDate, DateOnly? untilDate, TransactionFilterType? type, long? lastKnowledgeOfServer)
        => Query(("since_date", sinceDate), ("until_date", untilDate), ("type", type), ("last_knowledge_of_server", lastKnowledgeOfServer));

    private static string Query(params (string Name, object? Value)[] parameters)
    {
        var parts = parameters
            .Where(p => p.Value is not null)
            .Select(p => $"{p.Name}={Uri.EscapeDataString(FormatValue(p.Value!))}");
        var query = string.Join('&', parts);
        return query.Length == 0 ? string.Empty : "?" + query;
    }

    private static string FormatValue(object value) => value switch
    {
        bool b => b ? "true" : "false",
        DateOnly d => d.ToString("O"),
        Enum e => JsonSerializer.Serialize(e, e.GetType(), JsonOptions).Trim('"'),
        _ => Convert.ToString(value, CultureInfo.InvariantCulture) ?? string.Empty
    };
}
