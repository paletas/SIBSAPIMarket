namespace SIBSAPIMarket.Client.Model.API
{
    public class Amount
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "content", Required = Newtonsoft.Json.Required.Always)]
        public decimal Value { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "currency", Required = Newtonsoft.Json.Required.Always)]
        public string Currency { get; set; }

        public override string ToString()
        {
            return $"{Value}[{Currency}]";
        }
    }
}
