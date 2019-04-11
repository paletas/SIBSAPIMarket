namespace SIBSAPIMarket.Client.Model.API.Responses
{
    public class AccountBalancesResponse
    {
        [Newtonsoft.Json.JsonProperty("balances")]
        public Balance[] Balances { get; set; }
    }
}
