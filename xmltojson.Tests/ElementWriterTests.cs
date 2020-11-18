using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace xmltojson.Tests
{
    [TestClass]
    public class ElementWriterTests
    {
        private readonly IElementWriter _elementWriter;
        private const string FilePath1 = @"J:\78fe9lk";
        private const string FilePath2 = "../../XML.xml";
        private const string FilePath3 = "../../Output1.json";
        private const string FilePath4 = "../../Outpu2.json";



        public ElementWriterTests()
        {
            _elementWriter = new ElementWriter();
        }

        [TestMethod]
        public void OutputDataCanNotBeNullTest()
        {
            List<IElement> elements = null;
            Assert.ThrowsException<OutputDataCanNotBeNull>(() =>
                _elementWriter.Write(elements, FilePath2));
        }

        [TestMethod]
        public void OutputDataIsEmptyTest()
        {
            List<IElement> elements = new List<IElement>();
            Assert.ThrowsException<OutputDataIsEmpty>(() =>
                _elementWriter.Write(elements, FilePath2));

        }

        [TestMethod]
        public void DirectoryNotFoundTest()
        {
            List<IElement> elements = new List<IElement>
                { new Element { Variable1 = 5, Variable2 = 10 } };
            Assert.ThrowsException<DirectoryNotFoundException>(() =>
                _elementWriter.Write(elements, FilePath1));

        }

        [TestMethod]
        public void WriteTest()
        {
            List<IElement> elements = new List<IElement>
                { new Element { Variable1 = 5, Variable2 = 10 } };
            var jsonExpected = JsonConvert.SerializeObject(elements, Formatting.Indented);
            File.WriteAllText(FilePath3, jsonExpected);

            _elementWriter.Write(elements, FilePath4);

            Assert.IsTrue(File.ReadAllBytes(FilePath3).SequenceEqual(File.ReadAllBytes(FilePath4)));
        }
    }
}
