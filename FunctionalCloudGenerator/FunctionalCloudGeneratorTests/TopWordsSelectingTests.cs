using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FunctionalCloudGenerator;

namespace FunctionalCloudGeneratorTests
{
    [TestClass]
    public class TopWordsSelectingTests
    {
        [TestMethod]
        public void BannedWords_shouldBeRemoved()
        {
            var words = new Dictionary<string, int>
            {
                {"one", 1},
                {"two", 2},
                {"three", 3}
            };
            var bannedWords = new Dictionary<string, int>
            {
                {"one", 5}
            };
            var expected = new List<string> { "three", "two" };
            var actual = Program.GetTopWords(words, bannedWords, 10);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RedundantWords_shouldBeRemoved()
        {
            var words = new Dictionary<string, int>
            {
                {"one", 1},
                {"two", 2},
                {"three", 3}
            };
            var bannedWords = new Dictionary<string, int>();
            var expected = new List<string> { "three" };
            var actual = Program.GetTopWords(words, bannedWords, 1);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TopWords_shouldBeSorted()
        {
            var words = new Dictionary<string, int>
            {
                {"one", 4},
                {"two", 2},
                {"three", 7}
            };
            var bannedWords = new Dictionary<string, int>();
            var expected = new List<string> { "three", "one", "two" };
            var actual = Program.GetTopWords(words, bannedWords, 3);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
