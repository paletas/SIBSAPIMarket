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
    public class AccountInformationTest
    {
        private ITestOutputHelper _output;

        public AccountInformationTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async void CanListUserAccounts()
        {
            using (var api = new SIBSMarketAPI(Configuration.DevelopmentPath, Configuration.DeveloperAccountKey, bankCode => Task.FromResult(new ConsentDetails(ConsentDetails.PurposeEnum.AccountDetails, false, validUntil: DateTime.Now.AddMinutes(5)))))
            {
                var accounts = await api.AccountInformation.ListAccounts("NVB");

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

        [Fact]
        public async void CanListUserAccountsWithBalances()
        {
            using (var api = new SIBSMarketAPI(Configuration.DevelopmentPath, Configuration.DeveloperAccountKey, bankCode => Task.FromResult(new ConsentDetails(ConsentDetails.PurposeEnum.AccountDetails, false, validUntil: DateTime.Now.AddMinutes(5)))))
            {
                var accounts = await api.AccountInformation.ListAccounts("NVB", withBalances: true);

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
                Assert.True(accounts.Accounts.All(acc => acc.Balances != null));
            }
        }

        [Fact]
        public async void CanListUserAccountsAndGetDetailsWithBalances()
        {
            using (var api = new SIBSMarketAPI(Configuration.DevelopmentPath, Configuration.DeveloperAccountKey, bankCode => Task.FromResult(new ConsentDetails(ConsentDetails.PurposeEnum.AccountBalances, false, validUntil: DateTime.Now.AddMinutes(5)))))
            {
                var accounts = await api.AccountInformation.ListAccounts("NVB");

                foreach (var account in accounts.Accounts)
                {
                    var accountDetails = await api.AccountInformation.GetAccountDetails("NVB", account.ID);

                    _output.WriteLine($"{accountDetails.Account.IBAN} - {accountDetails.Account.Name}");

                    if (accountDetails.Account.Balances == null)
                        _output.WriteLine("   » NO BALANCES");
                    else
                    {
                        foreach (var balance in accountDetails.Account.Balances)
                        {
                            _output.WriteLine($"   » {balance.Authorised?.Amount} + {balance.Expected?.Amount}");
                        }
                    }

                    Assert.True(accountDetails.Account.Balances != null);
                }

                Assert.NotEmpty(accounts.Accounts);
            }
        }

        [Fact]
        public async void CanListAccountBalances()
        {
            using (var api = new SIBSMarketAPI(Configuration.DevelopmentPath, Configuration.DeveloperAccountKey, bankCode => Task.FromResult(new ConsentDetails(ConsentDetails.PurposeEnum.AccountBalances, false, validUntil: DateTime.Now.AddMinutes(5)))))
            {
                var accounts = await api.AccountInformation.ListAccounts("NVB");

                foreach (var account in accounts.Accounts)
                {
                    var accountBalances = await api.AccountInformation.GetAccountBalances("NVB", account.ID);

                    if (accountBalances.Balances == null)
                        _output.WriteLine("   » NO BALANCES");
                    else
                    {
                        foreach (var balance in accountBalances.Balances)
                        {
                            _output.WriteLine($"   » {balance.Authorised?.Amount} + {balance.Expected?.Amount}");
                        }
                    }

                    Assert.True(accountBalances.Balances != null);
                }

                Assert.NotEmpty(accounts.Accounts);
            }
        }

        [Fact]
        public async void CanListAccountTransactions()
        {
            using (var api = new SIBSMarketAPI(Configuration.DevelopmentPath, Configuration.DeveloperAccountKey, bankCode => Task.FromResult(new ConsentDetails(ConsentDetails.PurposeEnum.AccountBalances, false, validUntil: DateTime.Now.AddMinutes(5)))))
            {
                var accounts = await api.AccountInformation.ListAccounts("NVB");

                foreach (var account in accounts.Accounts)
                {
                    var accountTransactions = await api.AccountInformation.GetAccountTransactions("NVB", account.ID);

                    Assert.True(accountTransactions.Transactions != null);

                    foreach (var transaction in accountTransactions.Transactions.Booked ?? new Model.API.Transaction[0])
                    {
                        _output.WriteLine($"   BOOKED » {transaction.ValueDate} - {transaction.Amount} - {transaction.BookingDate}");
                        _output.WriteLine($"          » {transaction.UnstructuredData}");
                    }

                    foreach (var transaction in accountTransactions.Transactions.Pending ?? new Model.API.Transaction[0])
                    {
                        _output.WriteLine($"  PENDING » {transaction.ValueDate} - {transaction.Amount}");
                        _output.WriteLine($"          » {transaction.UnstructuredData}");
                    }
                }

                Assert.NotEmpty(accounts.Accounts);
            }
        }
    }
}
