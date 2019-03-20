using Newtonsoft.Json;
using SIBSAPIMarket.Client.Model.API;
using System;

namespace SIBSAPIMarket.Client.Internals.JsonNET
{
    public class AllPSD2EnumConverter : Newtonsoft.Json.JsonConverter<AllPSD2Enum>
    {
        public override AllPSD2Enum ReadJson(JsonReader reader, Type objectType, AllPSD2Enum existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string value = (string)reader.Value;
            switch (value)
            {
                case "all-accounts": return AllPSD2Enum.All;
                default: throw new InvalidOperationException();
            }
        }

        public override void WriteJson(JsonWriter writer, AllPSD2Enum value, JsonSerializer serializer)
        {
            string serialized;
            switch (value)
            {
                case AllPSD2Enum.All: serialized = "all-accounts"; break;
                default: throw new InvalidOperationException();
            }
            writer.WriteValue(serialized);
        }
    }
}
