using System;
using System.Collections.Concurrent;
using System.Net.Http;

namespace SIBSAPIMarket.Client.Internals
{
    internal class HttpClientFactory
    {
        private readonly string _clientID;
        private readonly ConcurrentQueue<HttpClient> _availableClients;

        public HttpClientFactory(string clientID)
        {
            this._clientID = clientID;
            this._availableClients = new ConcurrentQueue<HttpClient>();
        }

        public HttpClient Get()
        {
            HttpClient httpClient;
            if (_availableClients.TryDequeue(out httpClient) == false)
            {
                httpClient = new HttpClient();
                EnsureHeader(httpClient, "X-IBM-Client-Id", _clientID);
            }

            EnsureHeader(httpClient, "TPP-Transaction-ID", Guid.NewGuid().ToString());
            EnsureHeader(httpClient, "TPP-Request-ID", Guid.NewGuid().ToString());
            return httpClient;
        }

        private void EnsureHeader(HttpClient httpClient, string name, string value)
        {
            if (httpClient.DefaultRequestHeaders.Contains(name))
                httpClient.DefaultRequestHeaders.Remove(name);
            httpClient.DefaultRequestHeaders.Add(name, value);
        }
    }
}
