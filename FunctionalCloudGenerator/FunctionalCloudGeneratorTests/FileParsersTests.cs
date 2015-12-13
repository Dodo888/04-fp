using System.Collections.Generic;
using FunctionalCloudGenerator.FileParsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalCloudGeneratorTests
{
    [TestClass]
    public class FileParsersTests
    {
        [TestMethod]
        public void SimpleParser_shouldParse()
        {
            var expected = new Dictionary<string, int>
            {
                {"one", 3},
                {"two", 3},
                {"three", 1}
            };
            var actual = SimpleFileParser.GetWordsDictionaryFromFile("tests/test.txt");
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
