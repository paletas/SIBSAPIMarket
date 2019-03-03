using System;

namespace SIBSAPIMarket.Client.Model
{
    public class ASPSP
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public string ID { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bic")]
        public string BIC { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bank-code")]
        public string BankCode { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "aspsp-cde")]
        public string Code { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "logoLocation")]
        public Uri LogoLocation { get; set; }
    }
}
