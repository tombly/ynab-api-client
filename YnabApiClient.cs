namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NSwag", "14.0.0.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class YnabApiClient
{
    private string _baseUrl = "https://api.ynab.com/v1/";
    private System.Net.Http.HttpClient _httpClient;
    private static System.Lazy<System.Text.Json.JsonSerializerOptions> _settings = new System.Lazy<System.Text.Json.JsonSerializerOptions>(CreateSerializerSettings, true);

    public YnabApiClient(System.Net.Http.HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private static System.Text.Json.JsonSerializerOptions CreateSerializerSettings()
    {
        var settings = new System.Text.Json.JsonSerializerOptions();
        UpdateJsonSerializerSettings(settings);
        return settings;
    }

    public string BaseUrl
    {
        get { return _baseUrl; }
        set
        {
            _baseUrl = value;
            if (!string.IsNullOrEmpty(_baseUrl) && !_baseUrl.EndsWith("/"))
                _baseUrl += '/';
        }
    }

    protected System.Text.Json.JsonSerializerOptions JsonSerializerSettings { get { return _settings.Value; } }

    static partial void UpdateJsonSerializerSettings(System.Text.Json.JsonSerializerOptions settings);

    partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
    partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
    partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);

    /// <summary>
    /// User info
    /// </summary>
    /// <remarks>
    /// Returns authenticated user information
    /// </remarks>
    /// <returns>The user info</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<UserResponse> GetUserAsync()
    {
        return GetUserAsync(System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// User info
    /// </summary>
    /// <remarks>
    /// Returns authenticated user information
    /// </remarks>
    /// <returns>The user info</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<UserResponse> GetUserAsync(System.Threading.CancellationToken cancellationToken)
    {
        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("user");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<UserResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("An error occurred", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// List budgets
    /// </summary>
    /// <remarks>
    /// Returns budgets list with summary information
    /// </remarks>
    /// <param name="include_accounts">Whether to include the list of budget accounts</param>
    /// <returns>The list of budgets</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<BudgetSummaryResponse> GetBudgetsAsync(bool? include_accounts)
    {
        return GetBudgetsAsync(include_accounts, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// List budgets
    /// </summary>
    /// <remarks>
    /// Returns budgets list with summary information
    /// </remarks>
    /// <param name="include_accounts">Whether to include the list of budget accounts</param>
    /// <returns>The list of budgets</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<BudgetSummaryResponse> GetBudgetsAsync(bool? include_accounts, System.Threading.CancellationToken cancellationToken)
    {
        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('?');
                if (include_accounts != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("include_accounts") + "=").Append(System.Uri.EscapeDataString(ConvertToString(include_accounts, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<BudgetSummaryResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("No budgets were found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("An error occurred", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Single budget
    /// </summary>
    /// <remarks>
    /// Returns a single budget with all related entities.  This resource is effectively a full budget export.
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="last_knowledge_of_server">The starting server knowledge.  If provided, only entities that have changed since `last_knowledge_of_server` will be included.</param>
    /// <returns>The requested budget</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<BudgetDetailResponse> GetBudgetByIdAsync(string budget_id, long? last_knowledge_of_server)
    {
        return GetBudgetByIdAsync(budget_id, last_knowledge_of_server, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Single budget
    /// </summary>
    /// <remarks>
    /// Returns a single budget with all related entities.  This resource is effectively a full budget export.
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="last_knowledge_of_server">The starting server knowledge.  If provided, only entities that have changed since `last_knowledge_of_server` will be included.</param>
    /// <returns>The requested budget</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<BudgetDetailResponse> GetBudgetByIdAsync(string budget_id, long? last_knowledge_of_server, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('?');
                if (last_knowledge_of_server != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("last_knowledge_of_server") + "=").Append(System.Uri.EscapeDataString(ConvertToString(last_knowledge_of_server, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<BudgetDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("The specified budget was not found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("An error occurred", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Budget Settings
    /// </summary>
    /// <remarks>
    /// Returns settings for a budget
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <returns>The requested budget settings</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<BudgetSettingsResponse> GetBudgetSettingsByIdAsync(string budget_id)
    {
        return GetBudgetSettingsByIdAsync(budget_id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Budget Settings
    /// </summary>
    /// <remarks>
    /// Returns settings for a budget
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <returns>The requested budget settings</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<BudgetSettingsResponse> GetBudgetSettingsByIdAsync(string budget_id, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("settings");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<BudgetSettingsResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("The specified Budget was not found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("An error occurred", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Account list
    /// </summary>
    /// <remarks>
    /// Returns all accounts
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="last_knowledge_of_server">The starting server knowledge.  If provided, only entities that have changed since `last_knowledge_of_server` will be included.</param>
    /// <returns>The list of requested accounts</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<AccountsResponse> GetAccountsAsync(string budget_id, long? last_knowledge_of_server)
    {
        return GetAccountsAsync(budget_id, last_knowledge_of_server, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Account list
    /// </summary>
    /// <remarks>
    /// Returns all accounts
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="last_knowledge_of_server">The starting server knowledge.  If provided, only entities that have changed since `last_knowledge_of_server` will be included.</param>
    /// <returns>The list of requested accounts</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<AccountsResponse> GetAccountsAsync(string budget_id, long? last_knowledge_of_server, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("accounts");
                urlBuilder_.Append('?');
                if (last_knowledge_of_server != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("last_knowledge_of_server") + "=").Append(System.Uri.EscapeDataString(ConvertToString(last_knowledge_of_server, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AccountsResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("No accounts were found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("An error occurred", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Create a new account
    /// </summary>
    /// <remarks>
    /// Creates a new account
    /// </remarks>
    /// <param name="budget_id">The id of the budget ("last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget)</param>
    /// <param name="body">The account to create.</param>
    /// <returns>The account was successfully created</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<AccountResponse> CreateAccountAsync(string budget_id, PostAccountWrapper body)
    {
        return CreateAccountAsync(budget_id, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Create a new account
    /// </summary>
    /// <remarks>
    /// Creates a new account
    /// </remarks>
    /// <param name="budget_id">The id of the budget ("last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget)</param>
    /// <param name="body">The account to create.</param>
    /// <returns>The account was successfully created</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<AccountResponse> CreateAccountAsync(string budget_id, PostAccountWrapper body, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        if (body == null)
            throw new System.ArgumentNullException("body");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                var json_ = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(body, _settings.Value);
                var content_ = new System.Net.Http.ByteArrayContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("accounts");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 201)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AccountResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("The request could not be understood due to malformed syntax or validation error(s).", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Single account
    /// </summary>
    /// <remarks>
    /// Returns a single account
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="account_id">The id of the account</param>
    /// <returns>The requested account</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<AccountResponse> GetAccountByIdAsync(string budget_id, System.Guid account_id)
    {
        return GetAccountByIdAsync(budget_id, account_id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Single account
    /// </summary>
    /// <remarks>
    /// Returns a single account
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="account_id">The id of the account</param>
    /// <returns>The requested account</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<AccountResponse> GetAccountByIdAsync(string budget_id, System.Guid account_id, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("accounts");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(account_id, System.Globalization.CultureInfo.InvariantCulture)));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<AccountResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("The requested account was not found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("An error occurred", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// List categories
    /// </summary>
    /// <remarks>
    /// Returns all categories grouped by category group.  Amounts (budgeted, activity, balance, etc.) are specific to the current budget month (UTC).
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="last_knowledge_of_server">The starting server knowledge.  If provided, only entities that have changed since `last_knowledge_of_server` will be included.</param>
    /// <returns>The categories grouped by category group</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<CategoriesResponse> GetCategoriesAsync(string budget_id, long? last_knowledge_of_server)
    {
        return GetCategoriesAsync(budget_id, last_knowledge_of_server, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// List categories
    /// </summary>
    /// <remarks>
    /// Returns all categories grouped by category group.  Amounts (budgeted, activity, balance, etc.) are specific to the current budget month (UTC).
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="last_knowledge_of_server">The starting server knowledge.  If provided, only entities that have changed since `last_knowledge_of_server` will be included.</param>
    /// <returns>The categories grouped by category group</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<CategoriesResponse> GetCategoriesAsync(string budget_id, long? last_knowledge_of_server, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("categories");
                urlBuilder_.Append('?');
                if (last_knowledge_of_server != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("last_knowledge_of_server") + "=").Append(System.Uri.EscapeDataString(ConvertToString(last_knowledge_of_server, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CategoriesResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("No categories were found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("An error occurred", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Single category
    /// </summary>
    /// <remarks>
    /// Returns a single category.  Amounts (budgeted, activity, balance, etc.) are specific to the current budget month (UTC).
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="category_id">The id of the category</param>
    /// <returns>The requested category</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<CategoryResponse> GetCategoryByIdAsync(string budget_id, string category_id)
    {
        return GetCategoryByIdAsync(budget_id, category_id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Single category
    /// </summary>
    /// <remarks>
    /// Returns a single category.  Amounts (budgeted, activity, balance, etc.) are specific to the current budget month (UTC).
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="category_id">The id of the category</param>
    /// <returns>The requested category</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<CategoryResponse> GetCategoryByIdAsync(string budget_id, string category_id, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        if (category_id == null)
            throw new System.ArgumentNullException("category_id");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("categories");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(category_id, System.Globalization.CultureInfo.InvariantCulture)));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CategoryResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("The category not was found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("An error occurred", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Update a category
    /// </summary>
    /// <remarks>
    /// Update a category
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="category_id">The id of the category</param>
    /// <param name="body">The category to update</param>
    /// <returns>The category was successfully updated</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<SaveCategoryResponse> UpdateCategoryAsync(string budget_id, string category_id, PatchCategoryWrapper body)
    {
        return UpdateCategoryAsync(budget_id, category_id, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Update a category
    /// </summary>
    /// <remarks>
    /// Update a category
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="category_id">The id of the category</param>
    /// <param name="body">The category to update</param>
    /// <returns>The category was successfully updated</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<SaveCategoryResponse> UpdateCategoryAsync(string budget_id, string category_id, PatchCategoryWrapper body, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        if (category_id == null)
            throw new System.ArgumentNullException("category_id");

        if (body == null)
            throw new System.ArgumentNullException("body");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                var json_ = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(body, _settings.Value);
                var content_ = new System.Net.Http.ByteArrayContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("PATCH");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("categories");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(category_id, System.Globalization.CultureInfo.InvariantCulture)));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<SaveCategoryResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("The request could not be understood due to malformed syntax or validation error(s)", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Single category for a specific budget month
    /// </summary>
    /// <remarks>
    /// Returns a single category for a specific budget month.  Amounts (budgeted, activity, balance, etc.) are specific to the current budget month (UTC).
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="month">The budget month in ISO format (e.g. 2016-12-01) ("current" can also be used to specify the current calendar month (UTC))</param>
    /// <param name="category_id">The id of the category</param>
    /// <returns>The requested month category</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<CategoryResponse> GetMonthCategoryByIdAsync(string budget_id, System.DateTimeOffset month, string category_id)
    {
        return GetMonthCategoryByIdAsync(budget_id, month, category_id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Single category for a specific budget month
    /// </summary>
    /// <remarks>
    /// Returns a single category for a specific budget month.  Amounts (budgeted, activity, balance, etc.) are specific to the current budget month (UTC).
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="month">The budget month in ISO format (e.g. 2016-12-01) ("current" can also be used to specify the current calendar month (UTC))</param>
    /// <param name="category_id">The id of the category</param>
    /// <returns>The requested month category</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<CategoryResponse> GetMonthCategoryByIdAsync(string budget_id, System.DateTimeOffset month, string category_id, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        if (category_id == null)
            throw new System.ArgumentNullException("category_id");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("months");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(month.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("categories");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(category_id, System.Globalization.CultureInfo.InvariantCulture)));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CategoryResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("The month category was not was found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("An error occurred", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Update a category for a specific month
    /// </summary>
    /// <remarks>
    /// Update a category for a specific month.  Only `budgeted` amount can be updated.
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="month">The budget month in ISO format (e.g. 2016-12-01) ("current" can also be used to specify the current calendar month (UTC))</param>
    /// <param name="category_id">The id of the category</param>
    /// <param name="body">The category to update.  Only `budgeted` amount can be updated and any other fields specified will be ignored.</param>
    /// <returns>The month category was successfully updated</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<SaveCategoryResponse> UpdateMonthCategoryAsync(string budget_id, System.DateTimeOffset month, string category_id, PatchMonthCategoryWrapper body)
    {
        return UpdateMonthCategoryAsync(budget_id, month, category_id, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Update a category for a specific month
    /// </summary>
    /// <remarks>
    /// Update a category for a specific month.  Only `budgeted` amount can be updated.
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="month">The budget month in ISO format (e.g. 2016-12-01) ("current" can also be used to specify the current calendar month (UTC))</param>
    /// <param name="category_id">The id of the category</param>
    /// <param name="body">The category to update.  Only `budgeted` amount can be updated and any other fields specified will be ignored.</param>
    /// <returns>The month category was successfully updated</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<SaveCategoryResponse> UpdateMonthCategoryAsync(string budget_id, System.DateTimeOffset month, string category_id, PatchMonthCategoryWrapper body, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        if (category_id == null)
            throw new System.ArgumentNullException("category_id");

        if (body == null)
            throw new System.ArgumentNullException("body");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                var json_ = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(body, _settings.Value);
                var content_ = new System.Net.Http.ByteArrayContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("PATCH");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("months");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(month.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("categories");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(category_id, System.Globalization.CultureInfo.InvariantCulture)));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<SaveCategoryResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("The request could not be understood due to malformed syntax or validation error(s)", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// List payees
    /// </summary>
    /// <remarks>
    /// Returns all payees
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="last_knowledge_of_server">The starting server knowledge.  If provided, only entities that have changed since `last_knowledge_of_server` will be included.</param>
    /// <returns>The requested list of payees</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PayeesResponse> GetPayeesAsync(string budget_id, long? last_knowledge_of_server)
    {
        return GetPayeesAsync(budget_id, last_knowledge_of_server, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// List payees
    /// </summary>
    /// <remarks>
    /// Returns all payees
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="last_knowledge_of_server">The starting server knowledge.  If provided, only entities that have changed since `last_knowledge_of_server` will be included.</param>
    /// <returns>The requested list of payees</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PayeesResponse> GetPayeesAsync(string budget_id, long? last_knowledge_of_server, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("payees");
                urlBuilder_.Append('?');
                if (last_knowledge_of_server != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("last_knowledge_of_server") + "=").Append(System.Uri.EscapeDataString(ConvertToString(last_knowledge_of_server, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<PayeesResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("No payees were found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("An error occurred", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Single payee
    /// </summary>
    /// <remarks>
    /// Returns a single payee
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="payee_id">The id of the payee</param>
    /// <returns>The requested payee</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PayeeResponse> GetPayeeByIdAsync(string budget_id, string payee_id)
    {
        return GetPayeeByIdAsync(budget_id, payee_id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Single payee
    /// </summary>
    /// <remarks>
    /// Returns a single payee
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="payee_id">The id of the payee</param>
    /// <returns>The requested payee</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PayeeResponse> GetPayeeByIdAsync(string budget_id, string payee_id, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        if (payee_id == null)
            throw new System.ArgumentNullException("payee_id");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("payees");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(payee_id, System.Globalization.CultureInfo.InvariantCulture)));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<PayeeResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("The payee was not found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("An error occurred", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// List payee locations
    /// </summary>
    /// <remarks>
    /// Returns all payee locations
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <returns>The list of payee locations</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PayeeLocationsResponse> GetPayeeLocationsAsync(string budget_id)
    {
        return GetPayeeLocationsAsync(budget_id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// List payee locations
    /// </summary>
    /// <remarks>
    /// Returns all payee locations
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <returns>The list of payee locations</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PayeeLocationsResponse> GetPayeeLocationsAsync(string budget_id, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("payee_locations");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<PayeeLocationsResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("No payees locations were found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("An error occurred", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Single payee location
    /// </summary>
    /// <remarks>
    /// Returns a single payee location
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="payee_location_id">id of payee location</param>
    /// <returns>The payee location</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PayeeLocationResponse> GetPayeeLocationByIdAsync(string budget_id, string payee_location_id)
    {
        return GetPayeeLocationByIdAsync(budget_id, payee_location_id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Single payee location
    /// </summary>
    /// <remarks>
    /// Returns a single payee location
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="payee_location_id">id of payee location</param>
    /// <returns>The payee location</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PayeeLocationResponse> GetPayeeLocationByIdAsync(string budget_id, string payee_location_id, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        if (payee_location_id == null)
            throw new System.ArgumentNullException("payee_location_id");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("payee_locations");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(payee_location_id, System.Globalization.CultureInfo.InvariantCulture)));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<PayeeLocationResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("The payee location was not found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("An error occurred", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// List locations for a payee
    /// </summary>
    /// <remarks>
    /// Returns all payee locations for a specified payee
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="payee_id">id of payee</param>
    /// <returns>The list of requested payee locations</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PayeeLocationsResponse> GetPayeeLocationsByPayeeAsync(string budget_id, string payee_id)
    {
        return GetPayeeLocationsByPayeeAsync(budget_id, payee_id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// List locations for a payee
    /// </summary>
    /// <remarks>
    /// Returns all payee locations for a specified payee
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="payee_id">id of payee</param>
    /// <returns>The list of requested payee locations</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PayeeLocationsResponse> GetPayeeLocationsByPayeeAsync(string budget_id, string payee_id, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        if (payee_id == null)
            throw new System.ArgumentNullException("payee_id");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("payees");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(payee_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("payee_locations");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<PayeeLocationsResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("No payees locations were found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("An error occurred", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// List budget months
    /// </summary>
    /// <remarks>
    /// Returns all budget months
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="last_knowledge_of_server">The starting server knowledge.  If provided, only entities that have changed since `last_knowledge_of_server` will be included.</param>
    /// <returns>The list of budget months</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<MonthSummariesResponse> GetBudgetMonthsAsync(string budget_id, long? last_knowledge_of_server)
    {
        return GetBudgetMonthsAsync(budget_id, last_knowledge_of_server, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// List budget months
    /// </summary>
    /// <remarks>
    /// Returns all budget months
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="last_knowledge_of_server">The starting server knowledge.  If provided, only entities that have changed since `last_knowledge_of_server` will be included.</param>
    /// <returns>The list of budget months</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<MonthSummariesResponse> GetBudgetMonthsAsync(string budget_id, long? last_knowledge_of_server, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("months");
                urlBuilder_.Append('?');
                if (last_knowledge_of_server != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("last_knowledge_of_server") + "=").Append(System.Uri.EscapeDataString(ConvertToString(last_knowledge_of_server, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<MonthSummariesResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("No budget months were found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("An error occurred", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Single budget month
    /// </summary>
    /// <remarks>
    /// Returns a single budget month
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="month">The budget month in ISO format (e.g. 2016-12-01) ("current" can also be used to specify the current calendar month (UTC))</param>
    /// <returns>The budget month detail</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<MonthDetailResponse> GetBudgetMonthAsync(string budget_id, System.DateTimeOffset month)
    {
        return GetBudgetMonthAsync(budget_id, month, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Single budget month
    /// </summary>
    /// <remarks>
    /// Returns a single budget month
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="month">The budget month in ISO format (e.g. 2016-12-01) ("current" can also be used to specify the current calendar month (UTC))</param>
    /// <returns>The budget month detail</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<MonthDetailResponse> GetBudgetMonthAsync(string budget_id, System.DateTimeOffset month, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("months");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(month.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<MonthDetailResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("The budget month was not found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("An error occurred", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// List transactions
    /// </summary>
    /// <remarks>
    /// Returns budget transactions
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="since_date">If specified, only transactions on or after this date will be included.  The date should be ISO formatted (e.g. 2016-12-30).</param>
    /// <param name="type">If specified, only transactions of the specified type will be included. "uncategorized" and "unapproved" are currently supported.</param>
    /// <param name="last_knowledge_of_server">The starting server knowledge.  If provided, only entities that have changed since `last_knowledge_of_server` will be included.</param>
    /// <returns>The list of requested transactions</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<TransactionsResponse> GetTransactionsAsync(string budget_id, System.DateTimeOffset? since_date, Type? type, long? last_knowledge_of_server)
    {
        return GetTransactionsAsync(budget_id, since_date, type, last_knowledge_of_server, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// List transactions
    /// </summary>
    /// <remarks>
    /// Returns budget transactions
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="since_date">If specified, only transactions on or after this date will be included.  The date should be ISO formatted (e.g. 2016-12-30).</param>
    /// <param name="type">If specified, only transactions of the specified type will be included. "uncategorized" and "unapproved" are currently supported.</param>
    /// <param name="last_knowledge_of_server">The starting server knowledge.  If provided, only entities that have changed since `last_knowledge_of_server` will be included.</param>
    /// <returns>The list of requested transactions</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<TransactionsResponse> GetTransactionsAsync(string budget_id, System.DateTimeOffset? since_date, Type? type, long? last_knowledge_of_server, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("transactions");
                urlBuilder_.Append('?');
                if (since_date != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("since_date") + "=").Append(System.Uri.EscapeDataString(since_date.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (type != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("type") + "=").Append(System.Uri.EscapeDataString(ConvertToString(type, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (last_knowledge_of_server != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("last_knowledge_of_server") + "=").Append(System.Uri.EscapeDataString(ConvertToString(last_knowledge_of_server, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<TransactionsResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("An error occurred", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("No transactions were found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Create a single transaction or multiple transactions
    /// </summary>
    /// <remarks>
    /// Creates a single transaction or multiple transactions.  If you provide a body containing a `transaction` object, a single transaction will be created and if you provide a body containing a `transactions` array, multiple transactions will be created.  Scheduled transactions cannot be created on this endpoint.
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="body">The transaction or transactions to create.  To create a single transaction you can specify a value for the `transaction` object and to create multiple transactions you can specify an array of `transactions`.  It is expected that you will only provide a value for one of these objects.</param>
    /// <returns>The transaction or transactions were successfully created</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<SaveTransactionsResponse> CreateTransactionAsync(string budget_id, PostTransactionsWrapper body)
    {
        return CreateTransactionAsync(budget_id, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Create a single transaction or multiple transactions
    /// </summary>
    /// <remarks>
    /// Creates a single transaction or multiple transactions.  If you provide a body containing a `transaction` object, a single transaction will be created and if you provide a body containing a `transactions` array, multiple transactions will be created.  Scheduled transactions cannot be created on this endpoint.
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="body">The transaction or transactions to create.  To create a single transaction you can specify a value for the `transaction` object and to create multiple transactions you can specify an array of `transactions`.  It is expected that you will only provide a value for one of these objects.</param>
    /// <returns>The transaction or transactions were successfully created</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<SaveTransactionsResponse> CreateTransactionAsync(string budget_id, PostTransactionsWrapper body, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        if (body == null)
            throw new System.ArgumentNullException("body");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                var json_ = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(body, _settings.Value);
                var content_ = new System.Net.Http.ByteArrayContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("transactions");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 201)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<SaveTransactionsResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("The request could not be understood due to malformed syntax or validation error(s).", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 409)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("A transaction on the same account with the same `import_id` already exists.", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Update multiple transactions
    /// </summary>
    /// <remarks>
    /// Updates multiple transactions, by `id` or `import_id`.
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="body">The transactions to update. Each transaction must have either an `id` or `import_id` specified. If `id` is specified as null an `import_id` value can be provided which will allow transaction(s) to be updated by their `import_id`. If an `id` is specified, it will always be used for lookup.</param>
    /// <returns>The transactions were successfully updated</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<SaveTransactionsResponse> UpdateTransactionsAsync(string budget_id, PatchTransactionsWrapper body)
    {
        return UpdateTransactionsAsync(budget_id, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Update multiple transactions
    /// </summary>
    /// <remarks>
    /// Updates multiple transactions, by `id` or `import_id`.
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="body">The transactions to update. Each transaction must have either an `id` or `import_id` specified. If `id` is specified as null an `import_id` value can be provided which will allow transaction(s) to be updated by their `import_id`. If an `id` is specified, it will always be used for lookup.</param>
    /// <returns>The transactions were successfully updated</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<SaveTransactionsResponse> UpdateTransactionsAsync(string budget_id, PatchTransactionsWrapper body, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        if (body == null)
            throw new System.ArgumentNullException("body");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                var json_ = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(body, _settings.Value);
                var content_ = new System.Net.Http.ByteArrayContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("PATCH");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("transactions");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 209)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<SaveTransactionsResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("The request could not be understood due to malformed syntax or validation error(s).", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Import transactions
    /// </summary>
    /// <remarks>
    /// Imports available transactions on all linked accounts for the given budget.  Linked accounts allow transactions to be imported directly from a specified financial institution and this endpoint initiates that import.  Sending a request to this endpoint is the equivalent of clicking "Import" on each account in the web application or tapping the "New Transactions" banner in the mobile applications.  The response for this endpoint contains the transaction ids that have been imported.
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <returns>The request was successful but there were no transactions to import</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<TransactionsImportResponse> ImportTransactionsAsync(string budget_id)
    {
        return ImportTransactionsAsync(budget_id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Import transactions
    /// </summary>
    /// <remarks>
    /// Imports available transactions on all linked accounts for the given budget.  Linked accounts allow transactions to be imported directly from a specified financial institution and this endpoint initiates that import.  Sending a request to this endpoint is the equivalent of clicking "Import" on each account in the web application or tapping the "New Transactions" banner in the mobile applications.  The response for this endpoint contains the transaction ids that have been imported.
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <returns>The request was successful but there were no transactions to import</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<TransactionsImportResponse> ImportTransactionsAsync(string budget_id, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Content = new System.Net.Http.StringContent(string.Empty, System.Text.Encoding.UTF8, "application/json");
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("transactions");
                urlBuilder_.Append('/');
                urlBuilder_.Append("import");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<TransactionsImportResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 201)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<TransactionsImportResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("The request could not be understood due to malformed syntax or validation error(s)", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Single transaction
    /// </summary>
    /// <remarks>
    /// Returns a single transaction
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="transaction_id">The id of the transaction</param>
    /// <returns>The requested transaction</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<TransactionResponse> GetTransactionByIdAsync(string budget_id, string transaction_id)
    {
        return GetTransactionByIdAsync(budget_id, transaction_id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Single transaction
    /// </summary>
    /// <remarks>
    /// Returns a single transaction
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="transaction_id">The id of the transaction</param>
    /// <returns>The requested transaction</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<TransactionResponse> GetTransactionByIdAsync(string budget_id, string transaction_id, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        if (transaction_id == null)
            throw new System.ArgumentNullException("transaction_id");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("transactions");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(transaction_id, System.Globalization.CultureInfo.InvariantCulture)));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<TransactionResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("The transaction was not found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("An error occurred", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Updates an existing transaction
    /// </summary>
    /// <remarks>
    /// Updates a single transaction
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="transaction_id">The id of the transaction</param>
    /// <param name="body">The transaction to update</param>
    /// <returns>The transaction was successfully updated</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<TransactionResponse> UpdateTransactionAsync(string budget_id, string transaction_id, PutTransactionWrapper body)
    {
        return UpdateTransactionAsync(budget_id, transaction_id, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Updates an existing transaction
    /// </summary>
    /// <remarks>
    /// Updates a single transaction
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="transaction_id">The id of the transaction</param>
    /// <param name="body">The transaction to update</param>
    /// <returns>The transaction was successfully updated</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<TransactionResponse> UpdateTransactionAsync(string budget_id, string transaction_id, PutTransactionWrapper body, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        if (transaction_id == null)
            throw new System.ArgumentNullException("transaction_id");

        if (body == null)
            throw new System.ArgumentNullException("body");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                var json_ = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(body, _settings.Value);
                var content_ = new System.Net.Http.ByteArrayContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("PUT");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("transactions");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(transaction_id, System.Globalization.CultureInfo.InvariantCulture)));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<TransactionResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("The request could not be understood due to malformed syntax or validation error(s)", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Deletes an existing transaction
    /// </summary>
    /// <remarks>
    /// Deletes a transaction
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="transaction_id">The id of the transaction</param>
    /// <returns>The transaction was successfully deleted</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<TransactionResponse> DeleteTransactionAsync(string budget_id, string transaction_id)
    {
        return DeleteTransactionAsync(budget_id, transaction_id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Deletes an existing transaction
    /// </summary>
    /// <remarks>
    /// Deletes a transaction
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="transaction_id">The id of the transaction</param>
    /// <returns>The transaction was successfully deleted</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<TransactionResponse> DeleteTransactionAsync(string budget_id, string transaction_id, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        if (transaction_id == null)
            throw new System.ArgumentNullException("transaction_id");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("DELETE");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("transactions");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(transaction_id, System.Globalization.CultureInfo.InvariantCulture)));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<TransactionResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("The transaction was not found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// List account transactions
    /// </summary>
    /// <remarks>
    /// Returns all transactions for a specified account
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="account_id">The id of the account</param>
    /// <param name="since_date">If specified, only transactions on or after this date will be included.  The date should be ISO formatted (e.g. 2016-12-30).</param>
    /// <param name="type">If specified, only transactions of the specified type will be included. "uncategorized" and "unapproved" are currently supported.</param>
    /// <param name="last_knowledge_of_server">The starting server knowledge.  If provided, only entities that have changed since `last_knowledge_of_server` will be included.</param>
    /// <returns>The list of requested transactions</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<TransactionsResponse> GetTransactionsByAccountAsync(string budget_id, string account_id, System.DateTimeOffset? since_date, Type? type, long? last_knowledge_of_server)
    {
        return GetTransactionsByAccountAsync(budget_id, account_id, since_date, type, last_knowledge_of_server, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// List account transactions
    /// </summary>
    /// <remarks>
    /// Returns all transactions for a specified account
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="account_id">The id of the account</param>
    /// <param name="since_date">If specified, only transactions on or after this date will be included.  The date should be ISO formatted (e.g. 2016-12-30).</param>
    /// <param name="type">If specified, only transactions of the specified type will be included. "uncategorized" and "unapproved" are currently supported.</param>
    /// <param name="last_knowledge_of_server">The starting server knowledge.  If provided, only entities that have changed since `last_knowledge_of_server` will be included.</param>
    /// <returns>The list of requested transactions</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<TransactionsResponse> GetTransactionsByAccountAsync(string budget_id, string account_id, System.DateTimeOffset? since_date, Type? type, long? last_knowledge_of_server, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        if (account_id == null)
            throw new System.ArgumentNullException("account_id");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("accounts");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(account_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("transactions");
                urlBuilder_.Append('?');
                if (since_date != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("since_date") + "=").Append(System.Uri.EscapeDataString(since_date.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (type != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("type") + "=").Append(System.Uri.EscapeDataString(ConvertToString(type, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (last_knowledge_of_server != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("last_knowledge_of_server") + "=").Append(System.Uri.EscapeDataString(ConvertToString(last_knowledge_of_server, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<TransactionsResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("No transactions were found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("An error occurred", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// List category transactions
    /// </summary>
    /// <remarks>
    /// Returns all transactions for a specified category
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="category_id">The id of the category</param>
    /// <param name="since_date">If specified, only transactions on or after this date will be included.  The date should be ISO formatted (e.g. 2016-12-30).</param>
    /// <param name="type">If specified, only transactions of the specified type will be included. "uncategorized" and "unapproved" are currently supported.</param>
    /// <param name="last_knowledge_of_server">The starting server knowledge.  If provided, only entities that have changed since `last_knowledge_of_server` will be included.</param>
    /// <returns>The list of requested transactions</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<HybridTransactionsResponse> GetTransactionsByCategoryAsync(string budget_id, string category_id, System.DateTimeOffset? since_date, Type? type, long? last_knowledge_of_server)
    {
        return GetTransactionsByCategoryAsync(budget_id, category_id, since_date, type, last_knowledge_of_server, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// List category transactions
    /// </summary>
    /// <remarks>
    /// Returns all transactions for a specified category
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="category_id">The id of the category</param>
    /// <param name="since_date">If specified, only transactions on or after this date will be included.  The date should be ISO formatted (e.g. 2016-12-30).</param>
    /// <param name="type">If specified, only transactions of the specified type will be included. "uncategorized" and "unapproved" are currently supported.</param>
    /// <param name="last_knowledge_of_server">The starting server knowledge.  If provided, only entities that have changed since `last_knowledge_of_server` will be included.</param>
    /// <returns>The list of requested transactions</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<HybridTransactionsResponse> GetTransactionsByCategoryAsync(string budget_id, string category_id, System.DateTimeOffset? since_date, Type? type, long? last_knowledge_of_server, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        if (category_id == null)
            throw new System.ArgumentNullException("category_id");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("categories");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(category_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("transactions");
                urlBuilder_.Append('?');
                if (since_date != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("since_date") + "=").Append(System.Uri.EscapeDataString(since_date.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (type != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("type") + "=").Append(System.Uri.EscapeDataString(ConvertToString(type, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (last_knowledge_of_server != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("last_knowledge_of_server") + "=").Append(System.Uri.EscapeDataString(ConvertToString(last_knowledge_of_server, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<HybridTransactionsResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("No transactions were found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("An error occurred", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// List payee transactions
    /// </summary>
    /// <remarks>
    /// Returns all transactions for a specified payee
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="payee_id">The id of the payee</param>
    /// <param name="since_date">If specified, only transactions on or after this date will be included.  The date should be ISO formatted (e.g. 2016-12-30).</param>
    /// <param name="type">If specified, only transactions of the specified type will be included. "uncategorized" and "unapproved" are currently supported.</param>
    /// <param name="last_knowledge_of_server">The starting server knowledge.  If provided, only entities that have changed since `last_knowledge_of_server` will be included.</param>
    /// <returns>The list of requested transactions</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<HybridTransactionsResponse> GetTransactionsByPayeeAsync(string budget_id, string payee_id, System.DateTimeOffset? since_date, Type? type, long? last_knowledge_of_server)
    {
        return GetTransactionsByPayeeAsync(budget_id, payee_id, since_date, type, last_knowledge_of_server, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// List payee transactions
    /// </summary>
    /// <remarks>
    /// Returns all transactions for a specified payee
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="payee_id">The id of the payee</param>
    /// <param name="since_date">If specified, only transactions on or after this date will be included.  The date should be ISO formatted (e.g. 2016-12-30).</param>
    /// <param name="type">If specified, only transactions of the specified type will be included. "uncategorized" and "unapproved" are currently supported.</param>
    /// <param name="last_knowledge_of_server">The starting server knowledge.  If provided, only entities that have changed since `last_knowledge_of_server` will be included.</param>
    /// <returns>The list of requested transactions</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<HybridTransactionsResponse> GetTransactionsByPayeeAsync(string budget_id, string payee_id, System.DateTimeOffset? since_date, Type? type, long? last_knowledge_of_server, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        if (payee_id == null)
            throw new System.ArgumentNullException("payee_id");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("payees");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(payee_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("transactions");
                urlBuilder_.Append('?');
                if (since_date != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("since_date") + "=").Append(System.Uri.EscapeDataString(since_date.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (type != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("type") + "=").Append(System.Uri.EscapeDataString(ConvertToString(type, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (last_knowledge_of_server != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("last_knowledge_of_server") + "=").Append(System.Uri.EscapeDataString(ConvertToString(last_knowledge_of_server, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<HybridTransactionsResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("No transactions were found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("An error occurred", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// List scheduled transactions
    /// </summary>
    /// <remarks>
    /// Returns all scheduled transactions
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="last_knowledge_of_server">The starting server knowledge.  If provided, only entities that have changed since `last_knowledge_of_server` will be included.</param>
    /// <returns>The list of requested scheduled transactions</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ScheduledTransactionsResponse> GetScheduledTransactionsAsync(string budget_id, long? last_knowledge_of_server)
    {
        return GetScheduledTransactionsAsync(budget_id, last_knowledge_of_server, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// List scheduled transactions
    /// </summary>
    /// <remarks>
    /// Returns all scheduled transactions
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="last_knowledge_of_server">The starting server knowledge.  If provided, only entities that have changed since `last_knowledge_of_server` will be included.</param>
    /// <returns>The list of requested scheduled transactions</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ScheduledTransactionsResponse> GetScheduledTransactionsAsync(string budget_id, long? last_knowledge_of_server, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("scheduled_transactions");
                urlBuilder_.Append('?');
                if (last_knowledge_of_server != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("last_knowledge_of_server") + "=").Append(System.Uri.EscapeDataString(ConvertToString(last_knowledge_of_server, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ScheduledTransactionsResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("No scheduled transactions were found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("An error occurred", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Single scheduled transaction
    /// </summary>
    /// <remarks>
    /// Returns a single scheduled transaction
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="scheduled_transaction_id">The id of the scheduled transaction</param>
    /// <returns>The requested Scheduled Transaction</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ScheduledTransactionResponse> GetScheduledTransactionByIdAsync(string budget_id, string scheduled_transaction_id)
    {
        return GetScheduledTransactionByIdAsync(budget_id, scheduled_transaction_id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Single scheduled transaction
    /// </summary>
    /// <remarks>
    /// Returns a single scheduled transaction
    /// </remarks>
    /// <param name="budget_id">The id of the budget. "last-used" can be used to specify the last used budget and "default" can be used if default budget selection is enabled (see: https://api.ynab.com/#oauth-default-budget).</param>
    /// <param name="scheduled_transaction_id">The id of the scheduled transaction</param>
    /// <returns>The requested Scheduled Transaction</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ScheduledTransactionResponse> GetScheduledTransactionByIdAsync(string budget_id, string scheduled_transaction_id, System.Threading.CancellationToken cancellationToken)
    {
        if (budget_id == null)
            throw new System.ArgumentNullException("budget_id");

        if (scheduled_transaction_id == null)
            throw new System.ArgumentNullException("scheduled_transaction_id");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append("budgets");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(budget_id, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Append('/');
                urlBuilder_.Append("scheduled_transactions");
                urlBuilder_.Append('/');
                urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(scheduled_transaction_id, System.Globalization.CultureInfo.InvariantCulture)));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ScheduledTransactionResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("The scheduled transaction was not found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ErrorResponse>("An error occurred", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    protected struct ObjectResponseResult<T>
    {
        public ObjectResponseResult(T responseObject, string responseText)
        {
            this.Object = responseObject;
            this.Text = responseText;
        }

        public T Object { get; }

        public string Text { get; }
    }

    public bool ReadResponseAsString { get; set; }

    protected virtual async System.Threading.Tasks.Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(System.Net.Http.HttpResponseMessage response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Threading.CancellationToken cancellationToken)
    {
        if (response == null || response.Content == null)
        {
            return new ObjectResponseResult<T>(default(T)!, string.Empty);
        }

        if (ReadResponseAsString)
        {
            var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            try
            {
                var typedBody = System.Text.Json.JsonSerializer.Deserialize<T>(responseText, JsonSerializerSettings);
                return new ObjectResponseResult<T>(typedBody!, responseText);
            }
            catch (System.Text.Json.JsonException exception)
            {
                var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
                throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
            }
        }
        else
        {
            try
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    var typedBody = await System.Text.Json.JsonSerializer.DeserializeAsync<T>(responseStream, JsonSerializerSettings, cancellationToken).ConfigureAwait(false);
                    return new ObjectResponseResult<T>(typedBody!, string.Empty);
                }
            }
            catch (System.Text.Json.JsonException exception)
            {
                var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
            }
        }
    }

    private string ConvertToString(object? value, System.Globalization.CultureInfo cultureInfo)
    {
        if (value == null)
        {
            return "";
        }

        if (value is System.Enum)
        {
            var name = System.Enum.GetName(value.GetType(), value);
            if (name != null)
            {
                var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                if (field != null)
                {
                    var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute))
                        as System.Runtime.Serialization.EnumMemberAttribute;
                    if (attribute != null)
                    {
                        return attribute.Value != null ? attribute.Value : name;
                    }
                }

                var converted = System.Convert.ToString(System.Convert.ChangeType(value, System.Enum.GetUnderlyingType(value.GetType()), cultureInfo));
                return converted == null ? string.Empty : converted;
            }
        }
        else if (value is bool)
        {
            return System.Convert.ToString((bool)value, cultureInfo).ToLowerInvariant();
        }
        else if (value is byte[])
        {
            return System.Convert.ToBase64String((byte[])value);
        }
        else if (value.GetType().IsArray)
        {
            var array = System.Linq.Enumerable.OfType<object>((System.Array)value);
            return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
        }

        var result = System.Convert.ToString(value, cultureInfo);
        return result == null ? "" : result;
    }
}