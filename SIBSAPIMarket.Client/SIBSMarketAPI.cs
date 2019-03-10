using SIBSAPIMarket.Client.Configuration;
using SIBSAPIMarket.Client.Internals;
using System;

namespace SIBSAPIMarket.Client
{
    public class SIBSMarketAPI : IDisposable
    {
        public SIBSMarketAPI(string apiPath, string clientID)
            : this(new Uri(apiPath), clientID)
        { }

        public SIBSMarketAPI(Uri apiPath, string clientID)
        {
            BasePath = apiPath;

            HttpClientFactory = new HttpClientFactory(clientID);
            var endpoints = new Endpoints(apiPath);

            InformationProduct = new InformationProductAPI(endpoints, HttpClientFactory);
        }

        public Uri BasePath { get; private set; }

        internal HttpClientFactory HttpClientFactory { get; private set; }

        public InformationProductAPI InformationProduct { get; private set; }

        public void Dispose()
        {
            InformationProduct = null;

            HttpClientFactory.Dispose();
        }
    }
}
