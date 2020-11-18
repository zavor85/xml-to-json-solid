using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace xmltojson
{
    [XmlRoot(ElementName = "element")]
    public class Element : IElement
    {
        [XmlElement(ElementName = "variable1")]
        [JsonIgnore]
        public double Variable1 { get; set; }
        [XmlElement(ElementName = "variable2")]
        [JsonIgnore]
        public double Variable2 { get; set; }
        [JsonProperty("multiplied")]
        public double Multiplied  => Variable1 * Variable2;
        [JsonProperty("divided")]
        public double Divided => Variable1 / Variable2;
    }

    [XmlRoot(ElementName = "root")]
    public class Root
    {
        [XmlElement(ElementName = "element")]
        public List<Element> Element { get; set; }
    }
}
