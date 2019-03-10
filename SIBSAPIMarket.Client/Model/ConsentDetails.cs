using System;
using System.Collections.Generic;
using System.Text;

namespace SIBSAPIMarket.Client.Model
{
    public class ConsentDetails
    {
        public class AccountReference
        {
            [Flags]
            public enum PurposeEnum
            {
                AccountDetails = 0x1,
                AccountBalance = 0x10,
                AccountTransactions = 0x100
            }

            public string Reference { get; set; }

            public PurposeEnum Purpose { get; set; }
        }

        public ConsentDetails(bool recurring, DateTime? validUntil = null, int? accessFrequency = null, bool? combined = null)
        {
            this.Recurring = recurring;
            this.ValidUntil = validUntil;
            this.AccessFrequency = accessFrequency;
            this.Combined = combined;
        }

        public IEnumerable<AccountReference> IBAN { get; set; }

        public IEnumerable<AccountReference> BBAN { get; set; }

        public IEnumerable<AccountReference> MSISDN { get; set; }

        public bool Recurring { get; set; }

        public DateTime? ValidUntil { get; set; }

        public int? AccessFrequency { get; set; }

        public bool? Combined { get; set; }
    }
}
