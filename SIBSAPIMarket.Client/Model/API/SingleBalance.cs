using System;

namespace SIBSAPIMarket.Client.Model.API
{
    public class SingleBalance
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "amount", Required = Newtonsoft.Json.Required.Always)]
        public Amount Amount { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "lastActionDateTime", Required = Newtonsoft.Json.Required.Default)]
        public DateTime? LastAction { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "date", Required = Newtonsoft.Json.Required.Default)]
        public DateTime? Date { get; set; }
    }
}
