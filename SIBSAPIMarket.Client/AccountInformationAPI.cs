using SIBSAPIMarket.Client.Configuration;
using SIBSAPIMarket.Client.Internals;
using SIBSAPIMarket.Client.Model;
using SIBSAPIMarket.Client.Model.API;
using SIBSAPIMarket.Client.Model.API.Responses;
using System;
using System.Threading.Tasks;

namespace SIBSAPIMarket.Client
{
    public class AccountInformationAPI : ConsentRequiredAPI
    {
        private Endpoints _endpoints;

        internal AccountInformationAPI(ConsentRequiredHandler consentRequiredHandler, Endpoints endpoints, HttpClientFactory clientFactory) 
            : base(consentRequiredHandler, endpoints, clientFactory)
        {
            _endpoints = endpoints;
        }

        public async Task<AccountsResponse> ListAccounts(string aspspCde, bool withBalances = false, bool psuAsked = false)
        {
            return await GetAsync<AccountsResponse>(aspspCde, _endpoints.ListAccounts(aspspCde, withBalances, psuAsked));
        }

        public async Task<AccountDetailResponse> GetAccountDetails(string aspspCde, string accountID, bool withBalances = false, bool psuAsked = false)
        {
            return await GetAsync<AccountDetailResponse>(aspspCde, _endpoints.AccountDetails(aspspCde, accountID));
        }
    }
}
