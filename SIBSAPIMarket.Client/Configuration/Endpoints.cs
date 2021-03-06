﻿using System;

namespace SIBSAPIMarket.Client.Configuration
{
    internal class Endpoints
    {
        private Uri _basePath;

        public Endpoints(Uri basePath)
        {
            _basePath = basePath;
        }

        private static string Relative_BankListV1 { get; } = "v1/available-aspsp";

        public Uri BankList() { return new Uri(_basePath, Relative_BankListV1); }

        private static string Relative_CreateConsentV1 { get; } = "{bank-cde}/v1/consents";

        public Uri CreateConsent(string bankCode, bool? redirectPreferred = null)
        {
            var uriBuilder = new UriBuilder(new Uri(_basePath, Relative_CreateConsentV1.Replace("{bank-cde}", bankCode)));
            if (redirectPreferred != null) AppendQueryParameter(uriBuilder, "tppRedirectPreferred", redirectPreferred);
            return uriBuilder.Uri;
        }

        private static string Relative_ListAccountsV1 { get; } = "{aspsp-cde}/v1/accounts";

        public Uri ListAccounts(string bankCode, bool? withBalance = null, bool? psuInvolved = null)
        {
            var uriBuilder = new UriBuilder(new Uri(_basePath, Relative_ListAccountsV1.Replace("{aspsp-cde}", bankCode)));
            if (withBalance != null) AppendQueryParameter(uriBuilder, nameof(withBalance), withBalance);
            if (psuInvolved != null) AppendQueryParameter(uriBuilder, nameof(psuInvolved), psuInvolved);
            return uriBuilder.Uri;
        }
        
        private static string Relative_AccountDetailsV1 { get; } = "{aspsp-cde}/v1/accounts/{account-id}";

        public Uri AccountDetails(string bankCode, string accountID, bool? withBalance = null, bool? psuInvolved = null)
        {
            var uriBuilder = new UriBuilder(new Uri(_basePath, Relative_AccountDetailsV1.Replace("{aspsp-cde}", bankCode).Replace("{account-id}", accountID)));
            if (withBalance != null) AppendQueryParameter(uriBuilder, nameof(withBalance), withBalance);
            if (psuInvolved != null) AppendQueryParameter(uriBuilder, nameof(psuInvolved), psuInvolved);
            return uriBuilder.Uri;
        }
        
        private static string Relative_AccountBalancesV1 { get; } = "{aspsp-cde}/v1/accounts/{account-id}/balances";

        public Uri AccountBalances(string bankCode, string accountID, bool? psuInvolved = null)
        {
            var uriBuilder = new UriBuilder(new Uri(_basePath, Relative_AccountBalancesV1.Replace("{aspsp-cde}", bankCode).Replace("{account-id}", accountID)));
            if (psuInvolved != null) AppendQueryParameter(uriBuilder, nameof(psuInvolved), psuInvolved);
            return uriBuilder.Uri;
        }

        private static string Relative_AccountTransactionsV1 { get; } = "{aspsp-cde}/v1/accounts/{account-id}/transactions";

        public Uri AccountTransactions(string bankCode, string accountID, bool? psuInvolved = null)
        {
            var uriBuilder = new UriBuilder(new Uri(_basePath, Relative_AccountTransactionsV1.Replace("{aspsp-cde}", bankCode).Replace("{account-id}", accountID)));
            if (psuInvolved != null) AppendQueryParameter(uriBuilder, nameof(psuInvolved), psuInvolved);
            return uriBuilder.Uri;
        }


        private static void AppendQueryParameter(UriBuilder uriBuilder, string parameterName, object parameterValue)
        {
            var parameter = $"{parameterName}={parameterValue}";
            if (string.IsNullOrEmpty(uriBuilder.Query) == false)
                uriBuilder.Query += "&" + parameter;
            else
                uriBuilder.Query = parameter;
        }
    }
}
