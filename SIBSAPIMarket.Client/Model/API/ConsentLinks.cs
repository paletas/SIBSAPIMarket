using System;

namespace SIBSAPIMarket.Client.Model.API
{
    public class ConsentLinks
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "redirect", Required = Newtonsoft.Json.Required.Default)]
        public Uri Redirect { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "updatePsuIdentification", Required = Newtonsoft.Json.Required.Default)]
        public Uri UpdatePsuIdentification { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "updatePsuAuthentication", Required = Newtonsoft.Json.Required.Default)]
        public Uri UpdatePsuAuthentication { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "selectAuthenticationMethod", Required = Newtonsoft.Json.Required.Default)]
        public Uri SelectAuthenticationMethod { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "authoriseTransaction", Required = Newtonsoft.Json.Required.Default)]
        public Uri AuthoriseTransaction { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "status", Required = Newtonsoft.Json.Required.Default)]
        public Uri Status { get; set; }
    }
}
