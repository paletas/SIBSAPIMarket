using System;

namespace SIBSAPIMarket.Client.Configuration
{
    internal class Endpoints
    {
        private Uri _basePath;

        public Endpoints(Uri basePath)
        {
            _basePath = basePath;
        }

        private static Uri Relative_BankListV1 { get; } = new Uri("v1/available-aspsp", UriKind.Relative);

        public Uri BankListV1 { get { return new Uri(_basePath, Relative_BankListV1); } }

        private static Uri Relative_CreateConsentV1 { get; } = new Uri("{bank-cde}/v1/consents", UriKind.Relative);

        public Uri CreateConsentV1 { get { return new Uri(_basePath, Relative_CreateConsentV1); } }
    }
}
