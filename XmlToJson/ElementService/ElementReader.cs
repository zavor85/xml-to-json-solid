using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

namespace XmlToJson
{
    public class ElementReader : IElementReader
    {
        private readonly List<IElement> _elementList;
        public ElementReader()
        {
            _elementList = new List<IElement>();
        }

        public List<IElement> Read(string filePath)
        {
            var rootObject = ReadXml(filePath);
            return AddElementsToList(rootObject);
        }

        public IRoot ReadXml(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotExistException();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            string jsonText = JsonConvert.SerializeXmlNode(xmlDoc);
            var rootObject = JsonConvert.DeserializeObject<Root>(jsonText);
            return rootObject;
        }

        public List<IElement> AddElementsToList(IRoot rootObject)
        {
            if (rootObject == null)
                throw new DataNullException();

            _elementList.AddRange(rootObject.RootItems.ListElements);
            return _elementList;
        }
    }
}
