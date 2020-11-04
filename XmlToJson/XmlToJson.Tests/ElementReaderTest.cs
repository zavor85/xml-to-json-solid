using System.Collections.Generic;
using System.IO;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace XmlToJson.Tests
{
    [TestClass]
    public class ElementReaderTest
    {
        private readonly IElementReader _elementReader;
        private string _xmlFilePath = "../../../XmlToJson/XML.xml";

        public ElementReaderTest()
        {
            _elementReader = new ElementReader();
        }

        [TestMethod]
        public void AddElementsToListTest()
        {
            var root = new Root
            {
                RootItems = {ListElements = new List<Element>()
                {
                    new Element()
                    {
                        Variable1 = 4, 
                        Variable2 = 8
                    }
                }}
            };

            var list = _elementReader.AddElementsToList(root);
            
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void ReadXmlTest()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_xmlFilePath);
            string jsonText = JsonConvert.SerializeXmlNode(xmlDoc);
            var rootObject = JsonConvert.DeserializeObject<Root>(jsonText);
           
            var expected = _elementReader.ReadXml(_xmlFilePath);
            
            Assert.AreEqual(expected.RootItems.ListElements[0].Variable1, rootObject.RootItems.ListElements[0].Variable1);
        }

        [TestMethod]
        public void FileNotExistTest()
        {
            Assert.ThrowsException<FileNotExistException>(() =>
                _elementReader.ReadXml(null));
        }

        [TestMethod]
        public void DataNullTest()
        {
            Assert.ThrowsException<DataNullException>(() =>
                _elementReader.AddElementsToList(null));
        }

        [TestMethod]
        public void ReadTest()
        {
            var readFile = _elementReader.Read(_xmlFilePath);

            var rootObj = _elementReader.ReadXml(_xmlFilePath);
            var resultList = _elementReader.AddElementsToList(rootObj);
            
            Assert.IsTrue(File.Exists(_xmlFilePath));
            Assert.AreEqual(string.Join("", readFile), string.Join("", resultList));
        }
    }
}
