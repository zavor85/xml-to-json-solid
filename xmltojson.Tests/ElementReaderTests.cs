using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace xmltojson.Tests
{
    [TestClass]
    public class ElementReaderTests
    {
        private readonly IElementReader _elemetReader;
        private const string FilePath1 = @"J:\78fe9lk";
        private const string FilePath2 = "../../XML.xml";
        private const string FilePath3 = "../../IncorrectXML.xml";

        public ElementReaderTests()
        {
            _elemetReader = new ElementReader();
        }

        [TestMethod]
        public void FileNotFoundTest()
        {
            Assert.ThrowsException<FileNotFoundException>(() =>
                _elemetReader.Read(FilePath1));
        }

        [TestMethod]
        public void NullReferenceTest()
        {
            XmlSerializer serializer = null;
           Assert.ThrowsException<NullReferenceException>(() =>
               serializer.Deserialize(File.OpenRead(FilePath2)));
        }

        [TestMethod]
        public void InvalidOperationTest()
        {
            Assert.ThrowsException<InvalidOperationException>(() =>
                _elemetReader.Read(FilePath3));
        }

        [TestMethod]
        public void ReadTest()
        {
            var serializer = new XmlSerializer(typeof(Root));
            var xml = serializer.Deserialize(File.OpenRead(FilePath2)) as Root;
            var elementList = xml.Element.Select(e => e as IElement).ToList();

            var expected = _elemetReader.Read(FilePath2);

            Assert.AreEqual(expected[0].Divided, elementList[0].Divided);
            Assert.AreEqual(expected[0].Multiplied, elementList[0].Multiplied);
        }

        [TestMethod]
        public void DividingAndMultiplyingTests()
        {
            var serializer = new XmlSerializer(typeof(Root));
            var xml = serializer.Deserialize(File.OpenRead(FilePath2)) as Root;

            var firstElementDividing = xml.Element[0].Variable1 / xml.Element[0].Variable2;
            var firstElementMultiplying = xml.Element[0].Variable1 * xml.Element[0].Variable2;
            var expected = _elemetReader.Read(FilePath2);

            Assert.AreEqual(expected[0].Divided, firstElementDividing);
            Assert.AreEqual(expected[0].Multiplied, firstElementMultiplying);
        }
    }
}
