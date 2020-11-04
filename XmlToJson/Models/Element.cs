using Newtonsoft.Json;

namespace XmlToJson
{
    public class Element : IElement
    {
        [JsonProperty("variable1")]
        public double Variable1 { get; set; }
        [JsonProperty("variable2")]
        public double Variable2 { get; set; }
    }
}
