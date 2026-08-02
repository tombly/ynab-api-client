namespace Ynab.Api.Client.Utils;

/// <summary>Thrown when the YNAB API returns a non-success status code.</summary>
public class ApiException(
    string message,
    int statusCode,
    string? response,
    IReadOnlyDictionary<string, IEnumerable<string>> headers,
    Exception? innerException = null)
    : Exception(message, innerException)
{
    /// <summary>The HTTP status code of the response.</summary>
    public int StatusCode { get; } = statusCode;

    /// <summary>The raw response body, if any.</summary>
    public string? Response { get; } = response;

    /// <summary>The response headers, including rate-limit information (X-Rate-Limit).</summary>
    public IReadOnlyDictionary<string, IEnumerable<string>> Headers { get; } = headers;
}

/// <summary>Thrown when the YNAB API returns a non-success status code with a parseable error body.</summary>
public sealed class ApiException<TResult>(
    string message,
    int statusCode,
    string? response,
    IReadOnlyDictionary<string, IEnumerable<string>> headers,
    TResult result,
    Exception? innerException = null)
    : ApiException(message, statusCode, response, headers, innerException)
{
    /// <summary>The deserialized error body.</summary>
    public TResult Result { get; } = result;
}
