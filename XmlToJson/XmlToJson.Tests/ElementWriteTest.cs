using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XmlToJson.Tests
{
    [TestClass]
    public class ElementWriteTest
    {
        private readonly IElementWriter _elementWriter;
        private string _jsonFilePath = "../../TestOutput.json";
        private string _jsonFilePath1 = "../../TestOutput1.json";

        public ElementWriteTest()
        {
            _elementWriter = new ElementWriter();
        }

        [TestMethod]
        public void AddOutputToListTest()
        {
            var listElement = new List<IElement>
            {
                new Element()
            };
            var list = _elementWriter.AddOutputToList(listElement);
            
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void WriteDataToJsonFileTest()
        {
            var dataOutput = new List<IOutput>()
            {
                new Output()
                {
                    divided = 2,
                    multiplied = 4
                }
            };

            string json = new JavaScriptSerializer().Serialize(dataOutput);
            File.WriteAllText(_jsonFilePath, json);
            var fileName = Path.GetFileName(_jsonFilePath);

            Assert.IsTrue(File.Exists(_jsonFilePath));
            Assert.AreEqual("TestOutput.json", fileName);
        }

        [TestMethod]
        public void OutputDataIsEmptyTest()
        {
            var outputList = new List<IOutput>();

            Assert.ThrowsException<OutputDataIsEmpty>(() =>
                _elementWriter.WriteDataToJsonFile(outputList, _jsonFilePath));
        }

        [TestMethod]
        public void ElementDataIsEmptyTest()
        {
            var elementList = new List<IElement>();

            Assert.ThrowsException<ElementDataIsEmptyException>(() =>
                _elementWriter.AddOutputToList(elementList));
        }

        [TestMethod]
        public void FilePathNullTest()
        {
            var outputList = new List<IOutput>();
            Assert.ThrowsException<FilePathNullException>(() =>
                _elementWriter.WriteDataToJsonFile(outputList, null));
        }

        [TestMethod]
        public void WriteTest()
        {
            var listElement = new List<IElement>
            {
                new Element()
                {
                    Variable1 = 5,
                    Variable2 = 10
                }
            };
      
            var outputList = _elementWriter.AddOutputToList(listElement);
            _elementWriter.WriteDataToJsonFile(outputList, _jsonFilePath1);
            outputList.Clear();

            _elementWriter.Write(listElement, _jsonFilePath);

            Assert.IsTrue(File.ReadAllBytes(_jsonFilePath1).SequenceEqual(File.ReadAllBytes(_jsonFilePath)));
        }
    }
}
