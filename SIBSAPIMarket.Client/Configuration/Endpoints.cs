using System;

namespace SIBSAPIMarket.Client.Configuration
{
    public class Endpoints
    {
        private Uri _basePath;

        public Endpoints(Uri basePath)
        {
            _basePath = basePath;
        }

        private static Uri  Relative_BankListV1 { get; } = new Uri("v1/available-aspsp", UriKind.Relative);

        public Uri BankListV1 { get { return new Uri(_basePath, Relative_BankListV1); } }
    }
}
