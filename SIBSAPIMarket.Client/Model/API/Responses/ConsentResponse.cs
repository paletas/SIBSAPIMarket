using System.Collections.Generic;

namespace SIBSAPIMarket.Client.Model.API.Responses
{
    public class ConsentResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "transactionStatus", Required = Newtonsoft.Json.Required.Always)]
        public TransactionStatusEnum TransactionStatus { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "consentId", Required = Newtonsoft.Json.Required.Default)]
        public string ConsentID { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "scaMethods", Required = Newtonsoft.Json.Required.Default)]
        public IEnumerable<Authentication> CustomerAuthenticationMethods { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "chosenScanMethod", Required = Newtonsoft.Json.Required.Default)]
        public Authentication ChosenAuthenticationMethod { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "challengeData", Required = Newtonsoft.Json.Required.Default)]
        public Challenge ChallengeData { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "_Links", Required = Newtonsoft.Json.Required.Always)]
        public ConsentLinks Links { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "psuMessage", Required = Newtonsoft.Json.Required.Default)]
        public string Message { get; set; }
    }
}
