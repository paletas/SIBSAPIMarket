using Newtonsoft.Json;
using SIBSAPIMarket.Client.Model.API;
using System;

namespace SIBSAPIMarket.Client.Internals.JsonNET
{
    public class AvailableAccountsEnumConverter : Newtonsoft.Json.JsonConverter<AvailableAccountsEnum>
    {
        public override AvailableAccountsEnum ReadJson(JsonReader reader, Type objectType, AvailableAccountsEnum existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string value = (string)reader.Value;
            switch (value)
            {
                case "all-accounts": return AvailableAccountsEnum.All;
                default: throw new InvalidOperationException();
            }
        }

        public override void WriteJson(JsonWriter writer, AvailableAccountsEnum value, JsonSerializer serializer)
        {
            string serialized;
            switch (value)
            {
                case AvailableAccountsEnum.All: serialized = "all-accounts"; break;
                default: throw new InvalidOperationException();
            }
            writer.WriteValue(serialized);
        }
    }
}
