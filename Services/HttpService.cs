namespace DGII_Connect;

using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class HttpService : IHttpService
{
    private readonly HttpClient _client;

    public HttpService()
    {
        _client = new HttpClient();
    }

    public async Task<HttpResponseMessage> PostAsync(string url, string jsonContent, string authToken)
    {
        if (!string.IsNullOrEmpty(authToken))
        {
            _client.DefaultRequestHeaders.Add("Authorization",authToken);
        }
            _client.DefaultRequestHeaders.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("gzip"));
            _client.DefaultRequestHeaders.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("deflate"));
            _client.DefaultRequestHeaders.Connection.Add("Keep-Alive");
            //_client.DefaultRequestHeaders.UserAgent.ParseAdd("Apache-HttpClient/4.5.5 (Java/16.0.2)");

        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        return await _client.PostAsync(url, content);
    }
}
