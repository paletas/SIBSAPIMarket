using SIBSAPIMarket.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace SIBSAPIMarket.Client.Tests
{
    public class TestListAccounts
    {
        private ITestOutputHelper _output;

        public TestListAccounts(ITestOutputHelper output)
        {
            _output = output;
        }
        
        [Fact]
        public async void CanListUserAccounts()
        {
            using (var api = new SIBSMarketAPI(Configuration.DevelopmentPath, Configuration.DeveloperAccountKey, bankCode => Task.FromResult(new ConsentDetails(ConsentDetails.PurposeEnum.AccountDetails, false, validUntil: DateTime.Now.AddMinutes(5)))))
            {
                var accounts = await api.AccountInformation.ListAccounts("NVB", false, false);

                foreach (var account in accounts.Accounts)
                {
                    _output.WriteLine($"{account.IBAN} - {account.Name}");

                    if (account.Balances == null)
                        _output.WriteLine("   » NO BALANCES");
                    else
                    {
                        foreach (var balance in account.Balances)
                        {
                            _output.WriteLine($"   » {balance.Authorised?.Amount} + {balance.Expected?.Amount}");
                        }
                    }
                }

                Assert.NotEmpty(accounts.Accounts);
                Assert.True(accounts.Accounts.All(acc => acc.Balances == null));
            }
        }
    }
}
