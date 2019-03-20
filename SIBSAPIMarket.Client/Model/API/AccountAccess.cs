using SIBSAPIMarket.Client.Internals.JsonNET;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIBSAPIMarket.Client.Model.API
{
    public class AccountAccess
    {
        public AccountAccess(AvailableAccountsEnum availableAccounts)
        {
            AvailableAccounts = availableAccounts;
        }

        public AccountAccess(AllPSD2Enum availableAccounts)
        {
            AllPSD2 = availableAccounts;
        }

        public AccountAccess(AvailableAccountsEnum availableAccounts, IEnumerable<AccountReference> accountDetails)
        {
            Accounts = accountDetails;
        }

        public AccountAccess(AllPSD2Enum availableAccounts, IEnumerable<AccountReference> accountBalances = null, IEnumerable<AccountReference> accountTransactions = null)
        {
            Balances = accountBalances;
            Transactions = accountTransactions;
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "accounts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IEnumerable<AccountReference> Accounts { get; private set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "balances", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IEnumerable<AccountReference> Balances { get; private set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "transactions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IEnumerable<AccountReference> Transactions { get; private set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "availableAccounts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(AvailableAccountsEnumConverter))]
        public AvailableAccountsEnum? AvailableAccounts { get; private set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "allPsd2", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(AllPSD2EnumConverter))]
        public AllPSD2Enum? AllPSD2 { get; private set; }
    }
}
