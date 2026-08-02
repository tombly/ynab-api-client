using System.Net;
using System.Text;

namespace Ynab.Api.Client.Tests;

/// <summary>
/// Captures the outgoing request and returns a canned JSON response, so tests can
/// assert on the exact URL, HTTP method, and request body the client produces.
/// </summary>
internal sealed class FakeHttpMessageHandler(HttpStatusCode statusCode, string responseJson) : HttpMessageHandler
{
    public HttpRequestMessage? Request { get; private set; }
    public string? RequestBody { get; private set; }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Request = request;
        RequestBody = request.Content == null ? null : await request.Content.ReadAsStringAsync(cancellationToken);
        return new HttpResponseMessage(statusCode)
        {
            Content = new StringContent(responseJson, Encoding.UTF8, "application/json")
        };
    }

    public static YnabApiClient CreateClient(out FakeHttpMessageHandler handler, string responseJson, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        handler = new FakeHttpMessageHandler(statusCode, responseJson);
        return new YnabApiClient(new HttpClient(handler));
    }
}
