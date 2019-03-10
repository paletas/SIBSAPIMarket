namespace SIBSAPIMarket.Client.Model.API
{
    public class ErrorMessage
    {
        public class TppMessage
        {
            public enum CategoryEnum
            {
                ERROR,
                WARNING
            }

            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
            [Newtonsoft.Json.JsonProperty(PropertyName = "category")]
            public CategoryEnum Category { get; set; } 

            [Newtonsoft.Json.JsonProperty(PropertyName = "code")]
            public string Code { get; set; }

            [Newtonsoft.Json.JsonProperty(PropertyName = "text")]
            public string Description { get; set; }

            [Newtonsoft.Json.JsonProperty(PropertyName = "path")]
            public string Path { get; set; }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "tppMessages")]
        public TppMessage[] Messages { get; set; }
    }
}
