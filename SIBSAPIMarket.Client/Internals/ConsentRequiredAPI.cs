using SIBSAPIMarket.Client.Configuration;
using SIBSAPIMarket.Client.Exceptions;
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
                var consentID = await ObtainConsentFromPSUAsync(bankCode);
                if (consentID == null)
                    throw new SIBSAPIException(("Consent-ID", "Unable to obtain"));
                this.ConsentID = consentID;
            }

            var headers = new Dictionary<string, object>()
            {
                {  "Consent-ID", this.ConsentID }
            };
            return await base.GetAsync<T>(requestUri, headers);
        }

        protected override Task<TRP> PostAsync<TRQ, TRP>(string requestUri, TRQ requestContents = null, IDictionary<string, object> headers = null)
        {
            return base.PostAsync<TRQ, TRP>(requestUri, requestContents, headers);
        }

        private async Task<string> ObtainConsentFromPSUAsync(string bankCode)
        {
            var consentDetails = await this._consentRequiredHandler(bankCode);
            var consentRequest = GetConsentDetailsForEverything(consentDetails);

            var requestHeaders = new Dictionary<string, object>();
            if (consentDetails.RedirectUri != null) requestHeaders.Add("TPP-Redirect-URI", consentDetails.RedirectUri.AbsoluteUri);

            var response = await base.PostAsync<ConsentRequest, ConsentResponse>(this._endpoints.CreateConsent(bankCode, consentDetails.RedirectUri != null), consentRequest, requestHeaders);

            if (response.TransactionStatus == TransactionStatusEnum.Pending)
                return response.ConsentID;

            consentRequest = GetConsentDetailsForUserSelected(consentDetails);
            response = await base.PostAsync<ConsentRequest, ConsentResponse>(this._endpoints.CreateConsent(bankCode, consentDetails.RedirectUri != null), consentRequest, requestHeaders);

            if (response.TransactionStatus == TransactionStatusEnum.Pending)
                return response.ConsentID;
            else
                return null;
        }

        private ConsentRequest GetConsentDetailsForEverything(ConsentDetails consentDetails)
        {
            AccountAccess accountAccess;
            if (consentDetails.ConsentPurpose == ConsentDetails.PurposeEnum.AccountDetails)
            {
                accountAccess = new AccountAccess(AvailableAccountsEnum.All);
            }
            else
            {
                accountAccess = new AccountAccess(AllPSD2Enum.All);
            }

            return new ConsentRequest(accountAccess, consentDetails.Recurring, consentDetails.ValidUntil?.ToUniversalTime(), consentDetails.AccessFrequency ?? 1, consentDetails.Combined ?? false);
        }

        private ConsentRequest GetConsentDetailsForUserSelected(ConsentDetails consentDetails)
        {
            AccountAccess accountAccess;
            if (consentDetails.ConsentPurpose == ConsentDetails.PurposeEnum.AccountDetails)
            {
                accountAccess = new AccountAccess(
                    AvailableAccountsEnum.All
                    , consentDetails.GetAccountReferencesFor(ConsentDetails.PurposeEnum.AccountDetails)
                        .Select(@ref => new AccountReference(@ref.IBAN) { BBAN = @ref.BBAN, MSISDN = @ref.MSISDN })
                );
            }
            else
            {
                accountAccess = new AccountAccess(
                    AllPSD2Enum.All
                    , consentDetails.GetAccountReferencesFor(ConsentDetails.PurposeEnum.AccountBalances)
                        .Select(@ref => new AccountReference(@ref.IBAN) { BBAN = @ref.BBAN, MSISDN = @ref.MSISDN })
                    , consentDetails.GetAccountReferencesFor(ConsentDetails.PurposeEnum.AccountTransactions)
                        .Select(@ref => new AccountReference(@ref.IBAN) { BBAN = @ref.BBAN, MSISDN = @ref.MSISDN })
                );
            }

            return new ConsentRequest(accountAccess, consentDetails.Recurring, consentDetails.ValidUntil?.ToUniversalTime(), consentDetails.AccessFrequency ?? 1, consentDetails.Combined ?? false);
        }
    }
}
