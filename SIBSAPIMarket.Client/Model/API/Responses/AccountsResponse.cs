using System;
using System.Collections.Generic;
using System.Text;

namespace SIBSAPIMarket.Client.Model.API.Responses
{
    public class AccountsResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "accountList", Required = Newtonsoft.Json.Required.Default)]
        public IEnumerable<AccountDetails> Accounts { get; set; }
    }
}
