using Ynab.Api.Client.Enums;
using Ynab.Api.Client.Models;
using Ynab.Api.Client.Responses;

namespace Ynab.Api.Client;

/// <summary>A client for the YNAB API (https://api.ynab.com).</summary>
public interface IYnabApiClient
{
    /// <summary>The base URL for API calls. Defaults to https://api.ynab.com/v1/.</summary>
    string BaseUrl { get; set; }

    /// <summary>Returns authenticated user information.</summary>
    Task<UserResponse> GetUserAsync(CancellationToken cancellationToken = default);

    /// <summary>Returns the plans list with summary information.</summary>
    /// <param name="includeAccounts">Whether to include the list of plan accounts.</param>
    Task<PlanSummaryResponse> GetPlansAsync(bool? includeAccounts = null, CancellationToken cancellationToken = default);

    /// <summary>Returns a single plan with all related entities. This resource is effectively a full plan export.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since then will be included.</param>
    Task<PlanDetailResponse> GetPlanByIdAsync(string planId, long? lastKnowledgeOfServer = null, CancellationToken cancellationToken = default);

    /// <summary>Returns settings for a plan.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    Task<PlanSettingsResponse> GetPlanSettingsByIdAsync(string planId, CancellationToken cancellationToken = default);

    /// <summary>Returns all accounts.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since then will be included.</param>
    Task<AccountsResponse> GetAccountsAsync(string planId, long? lastKnowledgeOfServer = null, CancellationToken cancellationToken = default);

    /// <summary>Creates a new account.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="body">The account to create.</param>
    Task<AccountResponse> CreateAccountAsync(string planId, PostAccountWrapper body, CancellationToken cancellationToken = default);

    /// <summary>Returns a single account.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="accountId">The id of the account.</param>
    Task<AccountResponse> GetAccountByIdAsync(string planId, Guid accountId, CancellationToken cancellationToken = default);

    /// <summary>Returns all categories grouped by category group. Amounts (budgeted, activity, balance, etc.) are specific to the current plan month (UTC).</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since then will be included.</param>
    Task<CategoriesResponse> GetCategoriesAsync(string planId, long? lastKnowledgeOfServer = null, CancellationToken cancellationToken = default);

    /// <summary>Creates a new category.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="body">The category to create.</param>
    Task<SaveCategoryResponse> CreateCategoryAsync(string planId, PostCategoryWrapper body, CancellationToken cancellationToken = default);

    /// <summary>Returns a single category. Amounts (budgeted, activity, balance, etc.) are specific to the current plan month (UTC).</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="categoryId">The id of the category.</param>
    Task<CategoryResponse> GetCategoryByIdAsync(string planId, string categoryId, CancellationToken cancellationToken = default);

    /// <summary>Updates a category.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="categoryId">The id of the category.</param>
    /// <param name="body">The category to update.</param>
    Task<SaveCategoryResponse> UpdateCategoryAsync(string planId, string categoryId, PatchCategoryWrapper body, CancellationToken cancellationToken = default);

    /// <summary>Returns a single category for a specific plan month. Amounts (budgeted, activity, balance, etc.) are specific to the current plan month (UTC).</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="month">The plan month.</param>
    /// <param name="categoryId">The id of the category.</param>
    Task<CategoryResponse> GetMonthCategoryByIdAsync(string planId, DateOnly month, string categoryId, CancellationToken cancellationToken = default);

    /// <summary>Updates a category for a specific month. Only `budgeted` (assigned) amount can be updated.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="month">The plan month.</param>
    /// <param name="categoryId">The id of the category.</param>
    /// <param name="body">The category to update. Only `budgeted` (assigned) amount can be updated.</param>
    Task<SaveCategoryResponse> UpdateMonthCategoryAsync(string planId, DateOnly month, string categoryId, PatchMonthCategoryWrapper body, CancellationToken cancellationToken = default);

    /// <summary>Creates a new category group.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="body">The category group to create.</param>
    Task<SaveCategoryGroupResponse> CreateCategoryGroupAsync(string planId, PostCategoryGroupWrapper body, CancellationToken cancellationToken = default);

    /// <summary>Updates a category group.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="categoryGroupId">The id of the category group.</param>
    /// <param name="body">The category group to update.</param>
    Task<SaveCategoryGroupResponse> UpdateCategoryGroupAsync(string planId, string categoryGroupId, PatchCategoryGroupWrapper body, CancellationToken cancellationToken = default);

    /// <summary>Returns all payees.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since then will be included.</param>
    Task<PayeesResponse> GetPayeesAsync(string planId, long? lastKnowledgeOfServer = null, CancellationToken cancellationToken = default);

    /// <summary>Creates a new payee.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="body">The payee to create.</param>
    Task<SavePayeeResponse> CreatePayeeAsync(string planId, PostPayeeWrapper body, CancellationToken cancellationToken = default);

    /// <summary>Returns a single payee.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="payeeId">The id of the payee.</param>
    Task<PayeeResponse> GetPayeeByIdAsync(string planId, string payeeId, CancellationToken cancellationToken = default);

    /// <summary>Updates a payee.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="payeeId">The id of the payee.</param>
    /// <param name="body">The payee to update.</param>
    Task<SavePayeeResponse> UpdatePayeeAsync(string planId, string payeeId, PatchPayeeWrapper body, CancellationToken cancellationToken = default);

    /// <summary>Returns all payee locations.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    Task<PayeeLocationsResponse> GetPayeeLocationsAsync(string planId, CancellationToken cancellationToken = default);

    /// <summary>Returns a single payee location.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="payeeLocationId">The id of the payee location.</param>
    Task<PayeeLocationResponse> GetPayeeLocationByIdAsync(string planId, string payeeLocationId, CancellationToken cancellationToken = default);

    /// <summary>Returns all payee locations for a specified payee.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="payeeId">The id of the payee.</param>
    Task<PayeeLocationsResponse> GetPayeeLocationsByPayeeAsync(string planId, string payeeId, CancellationToken cancellationToken = default);

    /// <summary>Returns all plan months.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since then will be included.</param>
    Task<MonthSummariesResponse> GetPlanMonthsAsync(string planId, long? lastKnowledgeOfServer = null, CancellationToken cancellationToken = default);

    /// <summary>Returns a single plan month.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="month">The plan month.</param>
    Task<MonthDetailResponse> GetPlanMonthAsync(string planId, DateOnly month, CancellationToken cancellationToken = default);

    /// <summary>Returns all money movements.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    Task<MoneyMovementsResponse> GetMoneyMovementsAsync(string planId, CancellationToken cancellationToken = default);

    /// <summary>Returns all money movements for a specific month.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="month">The plan month.</param>
    Task<MoneyMovementsResponse> GetMoneyMovementsByMonthAsync(string planId, DateOnly month, CancellationToken cancellationToken = default);

    /// <summary>Returns all money movement groups.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    Task<MoneyMovementGroupsResponse> GetMoneyMovementGroupsAsync(string planId, CancellationToken cancellationToken = default);

    /// <summary>Returns all money movement groups for a specific month.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="month">The plan month.</param>
    Task<MoneyMovementGroupsResponse> GetMoneyMovementGroupsByMonthAsync(string planId, DateOnly month, CancellationToken cancellationToken = default);

    /// <summary>Returns plan transactions, excluding any pending transactions.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="sinceDate">If specified, only transactions on or after this date will be included. Defaults to one year ago when not specified.</param>
    /// <param name="untilDate">If specified, only transactions on or before this date will be included.</param>
    /// <param name="type">If specified, only transactions of the specified type will be included.</param>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since then will be included.</param>
    Task<TransactionsResponse> GetTransactionsAsync(string planId, DateOnly? sinceDate = null, DateOnly? untilDate = null, TransactionFilterType? type = null, long? lastKnowledgeOfServer = null, CancellationToken cancellationToken = default);

    /// <summary>Creates a single transaction or multiple transactions. Provide a body containing a `transaction` object to create a single transaction, or a `transactions` array to create multiple. Scheduled transactions (transactions with a future date) cannot be created on this endpoint.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="body">The transaction or transactions to create.</param>
    Task<SaveTransactionsResponse> CreateTransactionAsync(string planId, PostTransactionsWrapper body, CancellationToken cancellationToken = default);

    /// <summary>Updates multiple transactions, by `id` or `import_id`.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="body">The transactions to update. Each transaction must have either an `id` or `import_id` specified.</param>
    Task<SaveTransactionsResponse> UpdateTransactionsAsync(string planId, PatchTransactionsWrapper body, CancellationToken cancellationToken = default);

    /// <summary>Imports available transactions on all linked accounts for the given plan. Linked accounts allow transactions to be imported directly from a specified financial institution and this endpoint initiates that import. Sending a request to this endpoint is the equivalent of clicking "Import" on each account in the web application or tapping the "New Transactions" banner in the mobile applications.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    Task<TransactionsImportResponse> ImportTransactionsAsync(string planId, CancellationToken cancellationToken = default);

    /// <summary>Returns a single transaction.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="transactionId">The id of the transaction.</param>
    Task<TransactionResponse> GetTransactionByIdAsync(string planId, string transactionId, CancellationToken cancellationToken = default);

    /// <summary>Updates a single transaction.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="transactionId">The id of the transaction.</param>
    /// <param name="body">The transaction to update.</param>
    Task<TransactionResponse> UpdateTransactionAsync(string planId, string transactionId, PutTransactionWrapper body, CancellationToken cancellationToken = default);

    /// <summary>Deletes a transaction.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="transactionId">The id of the transaction.</param>
    Task<TransactionResponse> DeleteTransactionAsync(string planId, string transactionId, CancellationToken cancellationToken = default);

    /// <summary>Returns all transactions for a specified account, excluding any pending transactions.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="accountId">The id of the account.</param>
    /// <param name="sinceDate">If specified, only transactions on or after this date will be included. Defaults to one year ago when not specified.</param>
    /// <param name="untilDate">If specified, only transactions on or before this date will be included.</param>
    /// <param name="type">If specified, only transactions of the specified type will be included.</param>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since then will be included.</param>
    Task<TransactionsResponse> GetTransactionsByAccountAsync(string planId, string accountId, DateOnly? sinceDate = null, DateOnly? untilDate = null, TransactionFilterType? type = null, long? lastKnowledgeOfServer = null, CancellationToken cancellationToken = default);

    /// <summary>Returns all transactions for a specified category.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="categoryId">The id of the category.</param>
    /// <param name="sinceDate">If specified, only transactions on or after this date will be included. Defaults to one year ago when not specified.</param>
    /// <param name="untilDate">If specified, only transactions on or before this date will be included.</param>
    /// <param name="type">If specified, only transactions of the specified type will be included.</param>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since then will be included.</param>
    Task<HybridTransactionsResponse> GetTransactionsByCategoryAsync(string planId, string categoryId, DateOnly? sinceDate = null, DateOnly? untilDate = null, TransactionFilterType? type = null, long? lastKnowledgeOfServer = null, CancellationToken cancellationToken = default);

    /// <summary>Returns all transactions for a specified payee.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="payeeId">The id of the payee.</param>
    /// <param name="sinceDate">If specified, only transactions on or after this date will be included. Defaults to one year ago when not specified.</param>
    /// <param name="untilDate">If specified, only transactions on or before this date will be included.</param>
    /// <param name="type">If specified, only transactions of the specified type will be included.</param>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since then will be included.</param>
    Task<HybridTransactionsResponse> GetTransactionsByPayeeAsync(string planId, string payeeId, DateOnly? sinceDate = null, DateOnly? untilDate = null, TransactionFilterType? type = null, long? lastKnowledgeOfServer = null, CancellationToken cancellationToken = default);

    /// <summary>Returns all transactions for a specified month.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="month">The plan month in ISO format (e.g. 2016-12-01) ("current" can also be used to specify the current calendar month (UTC)).</param>
    /// <param name="sinceDate">If specified, only transactions on or after this date will be included. Defaults to one year ago when not specified.</param>
    /// <param name="untilDate">If specified, only transactions on or before this date will be included.</param>
    /// <param name="type">If specified, only transactions of the specified type will be included.</param>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since then will be included.</param>
    Task<TransactionsResponse> GetTransactionsByMonthAsync(string planId, string month, DateOnly? sinceDate = null, DateOnly? untilDate = null, TransactionFilterType? type = null, long? lastKnowledgeOfServer = null, CancellationToken cancellationToken = default);

    /// <summary>Returns all scheduled transactions.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since then will be included.</param>
    Task<ScheduledTransactionsResponse> GetScheduledTransactionsAsync(string planId, long? lastKnowledgeOfServer = null, CancellationToken cancellationToken = default);

    /// <summary>Creates a single scheduled transaction (a transaction with a future date).</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="body">The scheduled transaction to create.</param>
    Task<ScheduledTransactionResponse> CreateScheduledTransactionAsync(string planId, PostScheduledTransactionWrapper body, CancellationToken cancellationToken = default);

    /// <summary>Returns a single scheduled transaction.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="scheduledTransactionId">The id of the scheduled transaction.</param>
    Task<ScheduledTransactionResponse> GetScheduledTransactionByIdAsync(string planId, string scheduledTransactionId, CancellationToken cancellationToken = default);

    /// <summary>Updates a single scheduled transaction.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="scheduledTransactionId">The id of the scheduled transaction.</param>
    /// <param name="body">The scheduled transaction to update.</param>
    Task<ScheduledTransactionResponse> UpdateScheduledTransactionAsync(string planId, string scheduledTransactionId, PutScheduledTransactionWrapper body, CancellationToken cancellationToken = default);

    /// <summary>Deletes a scheduled transaction.</summary>
    /// <param name="planId">The id of the plan. "last-used" can be used to specify the last used plan and "default" can be used if default plan selection is enabled.</param>
    /// <param name="scheduledTransactionId">The id of the scheduled transaction.</param>
    Task<ScheduledTransactionResponse> DeleteScheduledTransactionAsync(string planId, string scheduledTransactionId, CancellationToken cancellationToken = default);
}
