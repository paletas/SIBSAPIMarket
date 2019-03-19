using SIBSAPIMarket.Client.Configuration;
using SIBSAPIMarket.Client.Internals;
using SIBSAPIMarket.Client.Model;
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
            Endpoints = new Endpoints(apiPath);

            InformationProduct = new InformationProductAPI(Endpoints, HttpClientFactory);
        }

        public SIBSMarketAPI(Uri apiPath, string clientID, ConsentRequiredHandler consentRequired)
            : this(apiPath, clientID)
        {
            AccountInformation = new AccountInformationAPI(consentRequired, Endpoints, HttpClientFactory);
        }

        internal Endpoints Endpoints { get; private set; }
        
        internal HttpClientFactory HttpClientFactory { get; private set; }

        public Uri BasePath { get; private set; }

        public InformationProductAPI InformationProduct { get; private set; }

        public AccountInformationAPI AccountInformation { get; private set; }

        public void Dispose()
        {
            InformationProduct = null;

            HttpClientFactory.Dispose();
        }
    }
}
