namespace SIBSAPIMarket.Client.Model.API
{
    public class Balance
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "openingBooked", Required = Newtonsoft.Json.Required.Default)]
        public SingleBalance OpeningBooked { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "closingBooked", Required = Newtonsoft.Json.Required.Default)]
        public SingleBalance ClosingBooked { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "expected", Required = Newtonsoft.Json.Required.Default)]
        public SingleBalance Expected { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "authorised", Required = Newtonsoft.Json.Required.Default)]
        public SingleBalance Authorised { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "interimAvailable", Required = Newtonsoft.Json.Required.Default)]
        public SingleBalance InterimAvailable { get; set; }
    }
}
