using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zendid.Services;

namespace Zendid.Models
{
    public static class ApiClient
    {
        // static HttpClient client = new HttpClient();
        static HttpClient client = new HttpClient(new LoggingHandler(new HttpClientHandler()));

        public static async Task<TResponse> RequestServerPost<TRequest, TResponse>(string url, TRequest request)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(url, request);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            TResponse res = await response.Content.ReadAsAsync<TResponse>();
            return res;
        }
    }
}
