using SIBSAPIMarket.Client.Configuration;
using SIBSAPIMarket.Client.Internals;
using SIBSAPIMarket.Client.Model.Responses;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SIBSAPIMarket.Client
{
    public class InformationProductAPI : BaseAPI
    {
        private readonly Endpoints _endpoints;

        internal InformationProductAPI(Endpoints endpoints, HttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
            this._endpoints = endpoints;
        }

        public async Task<ASPSPListResponse> ListBanks()
        {
            return await base.GetAsync<ASPSPListResponse>(_endpoints.BankListV1);
        }
    }
}
