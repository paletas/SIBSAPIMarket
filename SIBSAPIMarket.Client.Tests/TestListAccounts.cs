using SIBSAPIMarket.Client.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SIBSAPIMarket.Client.Tests
{
    public class TestListAccounts : IDisposable
    {
        private SIBSMarketAPI _api;

        public TestListAccounts()
        {
            _api = new SIBSMarketAPI(Configuration.DevelopmentPath, Configuration.DeveloperAccountKey, ProvideConsentDetailsAsync);
        }

        private Task<ConsentDetails> ProvideConsentDetailsAsync(string bankCode)
        {
            return Task.FromResult(new ConsentDetails(false, validUntil: DateTime.Now.AddMinutes(5)));
        }

        [Fact]
        public async void CanListUserAccounts()
        {
            await _api.AccountInformation.ListAccounts("0007", false, false);
        }

        public void Dispose()
        {
            _api.Dispose();
        }
    }
}
