namespace SIBSAPIMarket.Client.Model.API
{
    public class Challenge
    {
        public enum OTPFormatEnum
        {
            Characters,
            Integer
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "image", Required = Newtonsoft.Json.Required.Default)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.BinaryConverter))]
        public byte[] Image { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "data", Required = Newtonsoft.Json.Required.Default)]
        public string Data { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "imageLink", Required = Newtonsoft.Json.Required.Default)]
        public string ImageLink { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "otpMaxLength", Required = Newtonsoft.Json.Required.Default)]
        public int OTPMaxLength { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "otpFormat", Required = Newtonsoft.Json.Required.Default)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public OTPFormatEnum OTPFormat { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "additionalInformation", Required = Newtonsoft.Json.Required.Default)]
        public string AdditionalInformation { get; set; }
    }
}
