using System.Collections.Generic;
using Newtonsoft.Json;

namespace XmlToJson
{
    public class RootItems : IRootItems
    {
        [JsonProperty("element")]
        public List<Element> ListElements { get; set; }
    }
}
