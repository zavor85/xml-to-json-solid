using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace xmltojson.Tests
{
    [TestClass]
    public class ElementTest
    {
        private readonly IElement _element;
        private readonly IElement _variables;

        public ElementTest()
        {
            _element = new Item { Multiplied = 80, Divided = 5};
            _variables = new Element {Variable1 = 20, Variable2 = 4};
        }
        [TestMethod]
        public void MultiplyTest()
        {
            var multiply = _element.Multiplied;

            var expectedResult = _variables.Multiplied;

            Assert.AreEqual(expectedResult, multiply);
        }

        [TestMethod]
        public void DividedTest()
        {
            var divided = _element.Divided;

            var expectedResult = _variables.Divided;

            Assert.AreEqual(expectedResult, divided);
        }
    }
}
