using SIBSAPIMarket.Client.Configuration;
using SIBSAPIMarket.Client.Internals;
using System;

namespace SIBSAPIMarket.Client
{
    public class SIBSMarketAPI
    {
        public SIBSMarketAPI(string apiPath, string clientID)
            : this(new Uri(apiPath), clientID)
        {
        }

        public SIBSMarketAPI(Uri apiPath, string clientID)
        {
            var httpClientFactory = new HttpClientFactory(clientID);
            var endpoints = new Endpoints(apiPath);

            InformationProduct = new InformationProductAPI(endpoints, httpClientFactory);
        }

        public InformationProductAPI InformationProduct { get; private set; }
    }
}
