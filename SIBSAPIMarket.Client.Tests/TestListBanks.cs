using System;
using Xunit;

namespace SIBSAPIMarket.Client.Tests
{
    public class TestListBanks
    {
        private SIBSMarketAPI _marketAPI;

        public TestListBanks()
        {
            _marketAPI = new SIBSMarketAPI(Configuration.DevelopmentPath, "9034a3c4-243e-430a-97e5-5f302f114306");
        }

        [Fact]
        public async void List()
        {
            var response = await _marketAPI.InformationProduct.ListBanks();

            Assert.NotNull(response);
            Assert.NotEmpty(response.Banks);
        }
    }
}
