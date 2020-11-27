using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PodfatherClient
{
    internal class HttpClientFactory
    {
        internal static HttpClient CreateClient(Uri apiUri, String accessKey)
        {
            var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            client.BaseAddress = apiUri;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessKey);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
