using SIBSAPIMarket.Client.Exceptions;
using SIBSAPIMarket.Client.Model;
using System;
using System.Linq;
using System.Net.Http;
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

        internal Task<T> GetAsync<T>(Uri requestUri)
        {
            return GetAsync<T>(requestUri.AbsoluteUri);
        }

        internal async Task<T> GetAsync<T>(string requestUri)
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
    }
}
