using SIBSAPIMarket.Client.Configuration;
using SIBSAPIMarket.Client.Model;
using SIBSAPIMarket.Client.Model.API;
using SIBSAPIMarket.Client.Model.API.Requests;
using SIBSAPIMarket.Client.Model.API.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBSAPIMarket.Client.Internals
{
    public class ConsentRequiredAPI : BaseAPI
    {
        protected internal string ConsentID { get; private set; }

        private Endpoints _endpoints;
        private ConsentRequiredHandler _consentRequiredHandler;

        internal ConsentRequiredAPI(ConsentRequiredHandler getConsentDetails, Endpoints endpoints, HttpClientFactory clientFactory) : base(clientFactory)
        {
            this._endpoints = endpoints;
            this._consentRequiredHandler = getConsentDetails;
        }

        internal ConsentRequiredAPI(ConsentRequiredHandler getConsentDetails, string consentID, Endpoints endpoints, HttpClientFactory clientFactory) : this(getConsentDetails, endpoints, clientFactory)
        {
            ConsentID = consentID;
        }

        protected override Task<T> GetAsync<T>(string requestUri)
        {
            if (this.ConsentID == null)
            {
                //await ObtainConsentFromPSUAsync();
            }

            return base.GetAsync<T>(requestUri);
        }

        protected override Task<TRP> PostAsync<TRQ, TRP>(string requestUri, TRQ requestContents = null)
        {
            return base.PostAsync<TRQ, TRP>(requestUri, requestContents);
        }
        
        private async Task ObtainConsentFromPSUAsync(string bankCode)
        {
            ConsentRequest consentRequest = await GetConsentDetails(bankCode);

            var response = base.PostAsync<ConsentRequest, ConsentResponse>(this._endpoints.CreateConsentV1, consentRequest);
        }

        private async Task<ConsentRequest> GetConsentDetails(string bankCode)
        {
            var consentDetails = await this._consentRequiredHandler(bankCode);

            IList<AccountReference> accountDetails = new List<AccountReference>(), accountBalances = new List<AccountReference>(), accountTransactions = new List<AccountReference>();

            foreach (var iban in consentDetails.IBAN)
            {
                if ((iban.Purpose & ConsentDetails.AccountReference.PurposeEnum.AccountDetails) != 0)
                    accountDetails.Add(new AccountReference(iban.Reference));

                if ((iban.Purpose & ConsentDetails.AccountReference.PurposeEnum.AccountBalance) != 0)
                    accountBalances.Add(new AccountReference(iban.Reference));

                if ((iban.Purpose & ConsentDetails.AccountReference.PurposeEnum.AccountTransactions) != 0)
                    accountTransactions.Add(new AccountReference(iban.Reference));
            }

            foreach (var bban in consentDetails.BBAN)
            {
                if ((bban.Purpose & ConsentDetails.AccountReference.PurposeEnum.AccountDetails) != 0)
                    accountDetails.Add(new AccountReference() { BBAN = bban.Reference });

                if ((bban.Purpose & ConsentDetails.AccountReference.PurposeEnum.AccountBalance) != 0)
                    accountBalances.Add(new AccountReference() { BBAN = bban.Reference });

                if ((bban.Purpose & ConsentDetails.AccountReference.PurposeEnum.AccountTransactions) != 0)
                    accountTransactions.Add(new AccountReference() { BBAN = bban.Reference });
            }

            foreach (var msisdn in consentDetails.MSISDN)
            {
                if ((msisdn.Purpose & ConsentDetails.AccountReference.PurposeEnum.AccountDetails) != 0)
                    accountDetails.Add(new AccountReference() { MSISDN = msisdn.Reference });

                if ((msisdn.Purpose & ConsentDetails.AccountReference.PurposeEnum.AccountBalance) != 0)
                    accountBalances.Add(new AccountReference() { MSISDN = msisdn.Reference });

                if ((msisdn.Purpose & ConsentDetails.AccountReference.PurposeEnum.AccountTransactions) != 0)
                    accountTransactions.Add(new AccountReference() { MSISDN = msisdn.Reference });
            }

            AccountAccess accountAccess = new AccountAccess
            {
                Accounts = accountDetails,
                Balances = accountBalances,
                Transactions = accountTransactions
            };

            return new ConsentRequest(accountAccess, consentDetails.Recurring, consentDetails.ValidUntil, consentDetails.AccessFrequency ?? 1, consentDetails.Combined ?? false);
        }
    }

    public delegate Task<ConsentDetails> ConsentRequiredHandler(string bankCode);

}
