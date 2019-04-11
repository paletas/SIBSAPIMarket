namespace SIBSAPIMarket.Client.Model.API
{
    public class AccountReport
    {
        [Newtonsoft.Json.JsonProperty("booked")]
        public Transaction[] Booked { get; set; }

        [Newtonsoft.Json.JsonProperty("pending")]
        public Transaction[] Pending { get; set; }
    }
}
