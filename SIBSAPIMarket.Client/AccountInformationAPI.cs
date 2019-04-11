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

        public async Task<AccountDetailsResponse> GetAccountDetails(string aspspCde, string accountID, bool withBalances = false, bool psuAsked = false)
        {
            return await GetAsync<AccountDetailsResponse>(aspspCde, _endpoints.AccountDetails(aspspCde, accountID, withBalances, psuAsked));
        }

        public async Task<AccountBalancesResponse> GetAccountBalances(string aspspCde, string accountID, bool psuAsked = false)
        {
            return await GetAsync<AccountBalancesResponse>(aspspCde, _endpoints.AccountBalances(aspspCde, accountID, psuAsked));
        }

        public async Task<AccountTransactionsResponse> GetAccountTransactions(string aspspCde, string accountID, bool psuAsked = false)
        {
            return await GetAsync<AccountTransactionsResponse>(aspspCde, _endpoints.AccountTransactions(aspspCde, accountID, psuAsked));
        }
    }
}
