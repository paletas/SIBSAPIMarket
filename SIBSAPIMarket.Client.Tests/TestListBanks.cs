using System;
using Xunit;

namespace SIBSAPIMarket.Client.Tests
{
    public class TestListBanks : IDisposable
    {
        private SIBSMarketAPI _marketAPI;

        public TestListBanks()
        {
            _marketAPI = new SIBSMarketAPI(Configuration.DevelopmentPath, "9034a3c4-243e-430a-97e5-5f302f114306");
        }

        [Fact]
        public async void CanList()
        {
            var response = await _marketAPI.InformationProduct.ListBanks();

            Assert.NotNull(response);
            Assert.NotEmpty(response.Banks);
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
