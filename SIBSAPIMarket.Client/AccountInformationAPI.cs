using SIBSAPIMarket.Client.Internals;
using SIBSAPIMarket.Client.Model.API.Responses;
using System;
using System.Threading.Tasks;

namespace SIBSAPIMarket.Client
{
    public class AccountInformationAPI : BaseAPI
    {
        internal AccountInformationAPI(HttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        public async Task<AccountsResponse> ListAccounts(string aspspCde, string consent, bool withBalances = false, bool psuAsked = false)
        {
            throw new NotImplementedException();
        }
    }
}
