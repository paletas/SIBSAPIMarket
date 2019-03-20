using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIBSAPIMarket.Client.Model
{
    public class ConsentDetails
    {
        public enum PurposeEnum
        {
            AccountDetails = 0x0,
            AccountBalances = 0x1,
            AccountTransactions = 0x10,
            AccountBalanceAndTransactions = 0x11
        }

        public class AccountReference
        {
            public string Reference { get; set; }

            public PurposeEnum Purpose { get; set; }
        }

        public ConsentDetails(PurposeEnum purpose, bool recurring, Uri redirectUri = null, DateTime? validUntil = null, int? accessFrequency = null, bool? combined = null)
        {
            this.ConsentPurpose = purpose;
            this.Recurring = recurring;
            this.ValidUntil = validUntil;
            this.AccessFrequency = accessFrequency;
            this.Combined = combined;
        }

        public Uri RedirectUri { get; set; }

        public IEnumerable<AccountReference> IBAN { get; set; }

        public IEnumerable<AccountReference> BBAN { get; set; }

        public IEnumerable<AccountReference> MSISDN { get; set; }

        public PurposeEnum ConsentPurpose { get; set; }

        public bool Recurring { get; set; }

        public DateTime? ValidUntil { get; set; }

        public int? AccessFrequency { get; set; }

        public bool? Combined { get; set; }

        internal IEnumerable<(string IBAN, string BBAN, string MSISDN)> GetAccountReferencesFor(PurposeEnum purpose)
        {
            var foundAccounts = new List<(string IBAN, string BBAN, string MSISDN)>();

            if (this.IBAN != null)
            {
                foreach (var iban in this.IBAN.Where(reference => (reference.Purpose & purpose) == purpose))
                {
                    foundAccounts.Add((iban.Reference, null, null));
                }
            }

            if (this.BBAN != null)
            {
                foreach (var bban in this.BBAN.Where(reference => (reference.Purpose & purpose) == purpose))
                {
                    foundAccounts.Add((null, bban.Reference, null));
                }
            }

            if (this.MSISDN != null)
            {
                foreach (var msisdn in this.MSISDN.Where(reference => (reference.Purpose & purpose) == purpose))
                {
                    foundAccounts.Add((null, null, msisdn.Reference));
                }
            }

            return foundAccounts;
        }
    }
}
