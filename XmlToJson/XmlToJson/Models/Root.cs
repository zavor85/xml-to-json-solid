using Newtonsoft.Json;

namespace XmlToJson
{
    public class Root : IRoot
    {
        public Root()
        {
            RootItems = new RootItems();
        }
        [JsonProperty("root")]
        public IRootItems RootItems { get; set; }
    }
}
