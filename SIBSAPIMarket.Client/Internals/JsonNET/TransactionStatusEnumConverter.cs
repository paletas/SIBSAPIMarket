using Newtonsoft.Json;
using SIBSAPIMarket.Client.Model.API;
using System;

namespace SIBSAPIMarket.Client.Internals.JsonNET
{
    public class TransactionStatusEnumConverter : Newtonsoft.Json.JsonConverter<TransactionStatusEnum>
    {
        public override TransactionStatusEnum ReadJson(JsonReader reader, Type objectType, TransactionStatusEnum existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string value = (string) reader.Value;
            switch (value)
            {
                case "RCVD": return TransactionStatusEnum.Received;
                case "PDNG": return TransactionStatusEnum.Pending;
                case "PATC": return TransactionStatusEnum.PartiallyAcceptedTechnicallyCorrect;
                case "ACTC": return TransactionStatusEnum.AcceptedTechnicalValidation;
                case "ACCP": return TransactionStatusEnum.AcceptedCustomerProfile;
                case "ACFC": return TransactionStatusEnum.AcceptedFundsChecked;
                case "ACWC": return TransactionStatusEnum.AcceptedWithChanges;
                case "ACSP": return TransactionStatusEnum.AcceptedSettlementInProgress;
                case "ACSC": return TransactionStatusEnum.AcceptedSettlementCompleted;
                case "ACCC": return TransactionStatusEnum.AcceptedSettlementCompleted;
                case "RJCT": return TransactionStatusEnum.Rejected;
                case "CANC": return TransactionStatusEnum.Cancelled;
                default: throw new InvalidOperationException($"{value} was not recognized as a valid {nameof(TransactionStatusEnum)}");
            }
        }

        public override void WriteJson(JsonWriter writer, TransactionStatusEnum value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
