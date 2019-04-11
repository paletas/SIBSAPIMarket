namespace SIBSAPIMarket.Client.Model.API.Responses
{
    public class AccountTransactionsResponse
    {
        [Newtonsoft.Json.JsonProperty("transactions")]
        public AccountReport Transactions { get; set; }
    }
}
