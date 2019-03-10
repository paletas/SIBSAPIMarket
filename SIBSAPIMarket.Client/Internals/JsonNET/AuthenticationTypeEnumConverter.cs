using Newtonsoft.Json;
using SIBSAPIMarket.Client.Model.API;
using System;

namespace SIBSAPIMarket.Client.Internals.JsonNET
{
    public class AuthenticationTypeEnumConverter : Newtonsoft.Json.JsonConverter<AuthenticationTypeEnum>
    {
        public override AuthenticationTypeEnum ReadJson(JsonReader reader, Type objectType, AuthenticationTypeEnum existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string value = reader.ReadAsString();
            switch (value)
            {
                case "SMS_OTP": return AuthenticationTypeEnum.SMS;
                case "CHIP_OTP": return AuthenticationTypeEnum.CHIP;
                case "PHOTO_OTP": return AuthenticationTypeEnum.PHOTO;
                case "PUSH_OTP": return AuthenticationTypeEnum.PUSH;
                default: throw new InvalidOperationException();
            }
        }

        public override void WriteJson(JsonWriter writer, AuthenticationTypeEnum value, JsonSerializer serializer)
        {
            string serialized;
            switch (value)
            {
                case AuthenticationTypeEnum.SMS: serialized = "SMS_OTP"; break;
                case AuthenticationTypeEnum.CHIP: serialized = "CHIP_OTP"; break;
                case AuthenticationTypeEnum.PHOTO: serialized = "PHOTO_OTP"; break;
                case AuthenticationTypeEnum.PUSH: serialized = "PUSH_OTP"; break;
                default: throw new InvalidOperationException();
            }
            writer.WriteValue(serialized);
        }
    }
}
