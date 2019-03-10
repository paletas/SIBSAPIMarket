using SIBSAPIMarket.Client.Internals.JsonNET;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIBSAPIMarket.Client.Model.API
{
    public class AccountAccess
    {
        public AccountAccess()
        {
            this.AvailableAccounts = AvailableAccountsEnum.All;
            this.AllPSD2 = AllPSD2Enum.All;
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "accounts", Required = Newtonsoft.Json.Required.Default)]
        public IEnumerable<AccountReference> Accounts { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "balances", Required = Newtonsoft.Json.Required.Default)]
        public IEnumerable<AccountReference> Balances { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "transactions", Required = Newtonsoft.Json.Required.Default)]
        public IEnumerable<AccountReference> Transactions { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "availableAccounts", Required = Newtonsoft.Json.Required.Default)]
        [Newtonsoft.Json.JsonConverter(typeof(AvailableAccountsEnumConverter))]
        private AvailableAccountsEnum? AvailableAccounts { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "allPSD2", Required = Newtonsoft.Json.Required.Default)]
        [Newtonsoft.Json.JsonConverter(typeof(AllPSD2EnumConverter))]
        private AllPSD2Enum? AllPSD2 { get; set; }
    }
}
