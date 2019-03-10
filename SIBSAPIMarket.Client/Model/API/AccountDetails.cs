using System;
using System.Collections.Generic;
using System.Text;

namespace SIBSAPIMarket.Client.Model.API
{
    public class AccountDetails : AccountReference
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id", Required = Newtonsoft.Json.Required.Default)]
        public string ID { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "name", Required = Newtonsoft.Json.Required.Default)]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "accountType", Required = Newtonsoft.Json.Required.Default)]
        public string AccountType { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "cashAccountType", Required = Newtonsoft.Json.Required.Default)]
        public string CashAccountType { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bic", Required = Newtonsoft.Json.Required.Default)]
        public string BIC { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "balances", Required = Newtonsoft.Json.Required.Default)]
        public IEnumerable<Balance> Balances { get; set; }
    }
}
