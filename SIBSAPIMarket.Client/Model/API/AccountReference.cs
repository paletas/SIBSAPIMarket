namespace SIBSAPIMarket.Client.Model.API
{
    public class AccountReference
    {
        public AccountReference() : this("PT0000")
        {
        }

        public AccountReference(string iban)
        {
            this.IBAN = iban;
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "iban", Required = Newtonsoft.Json.Required.Always)]
        public string IBAN { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bban", Required = Newtonsoft.Json.Required.Default)]
        public string BBAN { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "pan", Required = Newtonsoft.Json.Required.Default)]
        public string PAN { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "maskedPan", Required = Newtonsoft.Json.Required.Default)]
        public string MaskedPAN { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "msisdn", Required = Newtonsoft.Json.Required.Default)]
        public string MSISDN { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "currency", Required = Newtonsoft.Json.Required.Default)]
        public string Currency { get; set; }
    }
}
