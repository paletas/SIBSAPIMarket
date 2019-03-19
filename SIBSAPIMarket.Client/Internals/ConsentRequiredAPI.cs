using SIBSAPIMarket.Client.Configuration;
using SIBSAPIMarket.Client.Model;
using SIBSAPIMarket.Client.Model.API;
using SIBSAPIMarket.Client.Model.API.Requests;
using SIBSAPIMarket.Client.Model.API.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        protected Task<T> GetAsync<T>(string bankCode, Uri requestUri)
        {
            return GetAsync<T>(bankCode, requestUri.AbsoluteUri);
        }

        protected async Task<T> GetAsync<T>(string bankCode, string requestUri)
        {
            if (this.ConsentID == null)
            {
                await ObtainConsentFromPSUAsync(bankCode);
            }

            return await base.GetAsync<T>(requestUri);
        }

        protected override Task<TRP> PostAsync<TRQ, TRP>(string requestUri, TRQ requestContents = null, IDictionary<string, object> headers = null)
        {
            return base.PostAsync<TRQ, TRP>(requestUri, requestContents, headers);
        }
        
        private async Task ObtainConsentFromPSUAsync(string bankCode)
        {
            var consentDetails = await this._consentRequiredHandler(bankCode);
            var consentRequest = GetConsentDetails(consentDetails);

            var requestHeaders = new Dictionary<string, object>();
            if (consentDetails.RedirectUri != null) requestHeaders.Add("TPP-Redirect-URI", consentDetails.RedirectUri.AbsoluteUri);

            var response = await base.PostAsync<ConsentRequest, ConsentResponse>(this._endpoints.CreateConsent(bankCode, consentDetails.RedirectUri != null), consentRequest, requestHeaders);
        }

        private ConsentRequest GetConsentDetails(ConsentDetails consentDetails)
        {
            IList<AccountReference> accountDetails = new List<AccountReference>(), accountBalances = new List<AccountReference>(), accountTransactions = new List<AccountReference>();

            if (consentDetails.IBAN != null)
            {
                foreach (var iban in consentDetails.IBAN)
                {
                    if ((iban.Purpose & ConsentDetails.AccountReference.PurposeEnum.AccountDetails) != 0)
                        accountDetails.Add(new AccountReference(iban.Reference));

                    if ((iban.Purpose & ConsentDetails.AccountReference.PurposeEnum.AccountBalance) != 0)
                        accountBalances.Add(new AccountReference(iban.Reference));

                    if ((iban.Purpose & ConsentDetails.AccountReference.PurposeEnum.AccountTransactions) != 0)
                        accountTransactions.Add(new AccountReference(iban.Reference));
                }
            }

            if (consentDetails.BBAN != null)
            {
                foreach (var bban in consentDetails.BBAN)
                {
                    if ((bban.Purpose & ConsentDetails.AccountReference.PurposeEnum.AccountDetails) != 0)
                        accountDetails.Add(new AccountReference() { BBAN = bban.Reference });

                    if ((bban.Purpose & ConsentDetails.AccountReference.PurposeEnum.AccountBalance) != 0)
                        accountBalances.Add(new AccountReference() { BBAN = bban.Reference });

                    if ((bban.Purpose & ConsentDetails.AccountReference.PurposeEnum.AccountTransactions) != 0)
                        accountTransactions.Add(new AccountReference() { BBAN = bban.Reference });
                }
            }

            if (consentDetails.MSISDN != null)
            {
                foreach (var msisdn in consentDetails.MSISDN)
                {
                    if ((msisdn.Purpose & ConsentDetails.AccountReference.PurposeEnum.AccountDetails) != 0)
                        accountDetails.Add(new AccountReference() { MSISDN = msisdn.Reference });

                    if ((msisdn.Purpose & ConsentDetails.AccountReference.PurposeEnum.AccountBalance) != 0)
                        accountBalances.Add(new AccountReference() { MSISDN = msisdn.Reference });

                    if ((msisdn.Purpose & ConsentDetails.AccountReference.PurposeEnum.AccountTransactions) != 0)
                        accountTransactions.Add(new AccountReference() { MSISDN = msisdn.Reference });
                }
            }

            AccountAccess accountAccess = new AccountAccess
            {
                Accounts = accountDetails,
                Balances = accountBalances,
                Transactions = accountTransactions
            };

            return new ConsentRequest(accountAccess, consentDetails.Recurring, consentDetails.ValidUntil?.ToUniversalTime(), consentDetails.AccessFrequency ?? 1, consentDetails.Combined ?? false);
        }
    }
}
