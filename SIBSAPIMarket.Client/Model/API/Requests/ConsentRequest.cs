using System;
using System.Collections.Generic;
using System.Text;

namespace SIBSAPIMarket.Client.Model.API.Requests
{
    internal class ConsentRequest
    {
        public ConsentRequest(AccountAccess access, bool recurring = false, DateTime? validUntil = null, int accessFrequencyPerDay = 1, bool combinedService = false)
        {
            this.Access = access;
            this.Recurring = recurring;
            this.ValidUntil = validUntil ?? DateTime.Now.AddMinutes(30);
            this.AccessFrequencyPerDay = accessFrequencyPerDay;
            this.CombinedService = combinedService;
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "access", Required = Newtonsoft.Json.Required.Always)]
        public AccountAccess Access { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "recurringIndicator", Required = Newtonsoft.Json.Required.Always)]
        public bool Recurring { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "validUntil", Required = Newtonsoft.Json.Required.Always)]
        public DateTime ValidUntil { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "frequencyPerDay", Required = Newtonsoft.Json.Required.Always)]
        public int AccessFrequencyPerDay { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "combinedServiceIndicator", Required = Newtonsoft.Json.Required.Always)]
        public bool CombinedService { get; set; }
    }
}
