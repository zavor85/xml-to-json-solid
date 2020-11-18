using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace xmltojson
{
    public class ElementReader : IElementReader
    {
        public List<IElement> Read(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"file at {filePath} does not exist");
            
            var serializer = new XmlSerializer(typeof(Root));
            var xml = serializer.Deserialize(File.OpenRead(filePath)) as Root;

            if (xml == null)
                throw new NullReferenceException("Incorrect xml file");
            foreach (var el in xml.Element)
            {
                if (string.IsNullOrEmpty(el.Variable1.ToString()) || string.IsNullOrEmpty(el.Variable2.ToString()))
                    throw new InvalidOperationException("Incorrect elements in file");
            }

            return xml.Element.Select(e => e as IElement).ToList();
        }
    }
}
