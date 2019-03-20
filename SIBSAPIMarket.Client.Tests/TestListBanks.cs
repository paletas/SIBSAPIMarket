using System;
using Xunit;
using Xunit.Abstractions;

namespace SIBSAPIMarket.Client.Tests
{
    public class TestListBanks : IDisposable
    {
        private ITestOutputHelper _output;
        private SIBSMarketAPI _marketAPI;

        public TestListBanks(ITestOutputHelper output)
        {
            _output = output;
            _marketAPI = new SIBSMarketAPI(Configuration.DevelopmentPath, Configuration.DeveloperAccountKey);
        }

        [Fact]
        public async void CanList()
        {
            var response = await _marketAPI.InformationProduct.ListBanks();

            Assert.NotNull(response);
            Assert.NotEmpty(response.Banks);

            foreach (var bank in response.Banks)
            {
                _output.WriteLine($"Available Bank » {bank.Code} - {bank.BankCode} - {bank.Name}");
            }
        }


        [Fact]
        public async void CanListTwiceWithSameClient()
        {
            var response = await _marketAPI.InformationProduct.ListBanks();

            Assert.NotNull(response);
            Assert.NotEmpty(response.Banks);

            var response2 = await _marketAPI.InformationProduct.ListBanks();

            Assert.NotNull(response2);
            Assert.NotEmpty(response2.Banks);
        }

        public void Dispose()
        {
            _marketAPI.Dispose();
        }
    }
}
