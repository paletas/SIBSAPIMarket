namespace SIBSAPIMarket.Client.Model.API
{
    public class Authentication
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "authenticationType", Required = Newtonsoft.Json.Required.Always)]
        public AuthenticationTypeEnum Type { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "authenticationVersion", Required = Newtonsoft.Json.Required.Default)]
        public string Version { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "authenticationMethodId", Required = Newtonsoft.Json.Required.Always)]
        public string MethodID { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "name", Required = Newtonsoft.Json.Required.Default)]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "explanation", Required = Newtonsoft.Json.Required.Default)]
        public string Explanation { get; set; }
    }
}
