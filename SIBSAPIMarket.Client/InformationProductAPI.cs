﻿using SIBSAPIMarket.Client.Configuration;
using SIBSAPIMarket.Client.Internals;
using SIBSAPIMarket.Client.Model.API.Responses;
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
            return await base.GetAsync<ASPSPListResponse>(_endpoints.BankList());
        }
    }
}
