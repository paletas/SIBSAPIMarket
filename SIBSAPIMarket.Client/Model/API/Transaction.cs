using System;

namespace SIBSAPIMarket.Client.Model.API
{
    public class Transaction
    {
        [Newtonsoft.Json.JsonProperty("transactionID")]
        public string ID { get; set; }

        [Newtonsoft.Json.JsonProperty("endToEndID")]
        public string EndToEndID { get; set; }

        [Newtonsoft.Json.JsonProperty("mandateID")]
        public string MandateID { get; set; }

        [Newtonsoft.Json.JsonProperty("bookingDate")]
        public DateTime? BookingDate { get; set; }

        [Newtonsoft.Json.JsonProperty("valueDate")]
        public DateTime ValueDate { get; set; }

        [Newtonsoft.Json.JsonProperty("amount")]
        public Amount Amount { get; set; }

        [Newtonsoft.Json.JsonProperty("creditorID")]
        public string CreditorID { get; set; }

        [Newtonsoft.Json.JsonProperty("creditorName")]
        public string CreditorName { get; set; }

        [Newtonsoft.Json.JsonProperty("creditorAccount")]
        public AccountReference CreditorAccount { get; set; }

        [Newtonsoft.Json.JsonProperty("ultimateCreditor")]
        public string UltimateCreditor { get; set; }

        [Newtonsoft.Json.JsonProperty("debtorName")]
        public string DebtorName { get; set; }

        [Newtonsoft.Json.JsonProperty("debtorAccount")]
        public AccountReference DebtorAccount { get; set; }

        [Newtonsoft.Json.JsonProperty("ultimateDebtor")]
        public string UltimateDebtor { get; set; }

        [Newtonsoft.Json.JsonProperty("purposeCode")]
        public string PurposeCode { get; set; }
        
        [Newtonsoft.Json.JsonProperty("remittanceInformationUnstructured")]
        public string UnstructuredData { get; set; }
    }
}
