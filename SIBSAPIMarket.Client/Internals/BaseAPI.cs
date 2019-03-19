using SIBSAPIMarket.Client.Exceptions;
using SIBSAPIMarket.Client.Model.API;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SIBSAPIMarket.Client.Internals
{
    public class BaseAPI
    {
        private readonly HttpClientFactory _clientFactory;

        internal BaseAPI(HttpClientFactory clientFactory)
        {
            this._clientFactory = clientFactory;
        }

        protected Task<T> GetAsync<T>(Uri requestUri)
        {
            return GetAsync<T>(requestUri.AbsoluteUri);
        }

        protected virtual async Task<T> GetAsync<T>(string requestUri)
        {
            var httpClient = this._clientFactory.Get();

            var responseMessage = await httpClient.GetAsync(requestUri);
            var responseString = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessage.IsSuccessStatusCode)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
            }
            else
            {
                var errors = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorMessage>(responseString);
                throw new SIBSAPIException(errors.Messages.Select(e => (e.Code, e.Description)).ToArray());
            }
        }

        protected Task<TRP> PostAsync<TRQ, TRP>(Uri requestUri, TRQ requestContents = null, IDictionary<string, object> headers = null)
            where TRQ : class
            where TRP : class
        {
            return PostAsync<TRQ, TRP>(requestUri.AbsoluteUri, requestContents, headers);
        }

        protected virtual async Task<TRP> PostAsync<TRQ, TRP>(string requestUri, TRQ requestContents = null, IDictionary<string, object> headers = null)
            where TRQ : class
            where TRP : class
        {
            var httpClient = this._clientFactory.Get();

            var requestAsString = Newtonsoft.Json.JsonConvert.SerializeObject(requestContents);
            HttpContent request = null;
            if (requestContents != null)
                request = new StringContent(requestAsString);

            request.Headers.Add("Digest", GetHashString(requestAsString));
            request.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            if (headers != null)
            {
                foreach (var keyPair in headers)
                {
                    request.Headers.Add(keyPair.Key, keyPair.Value.ToString());
                }
            }

            var responseMessage = await httpClient.PostAsync(requestUri, request);
            var responseString = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessage.IsSuccessStatusCode)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<TRP>(responseString);
            }
            else
            {
                var errors = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorMessage>(responseString);
                throw new SIBSAPIException(errors.Messages.Select(e => (e.Code, e.Description)).ToArray());
            }
        }

        private static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        private static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}
