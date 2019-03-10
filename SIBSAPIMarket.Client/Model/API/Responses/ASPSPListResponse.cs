using System.Collections.Generic;

namespace SIBSAPIMarket.Client.Model.API.Responses
{
    public class ASPSPListResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "aspsp-list")]
        public IEnumerable<ASPSP> Banks { get; set; }
    }
}
