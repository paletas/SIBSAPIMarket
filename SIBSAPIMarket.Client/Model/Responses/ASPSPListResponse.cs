using System.Collections.Generic;

namespace SIBSAPIMarket.Client.Model.Responses
{
    public class ASPSPListResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "aspspList")]
        public IEnumerable<ASPSP> Banks { get; set; }
    }
}
