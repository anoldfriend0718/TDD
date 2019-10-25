using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDPractices.Tests
{
    [TestClass]
    public class SoundexTests
    {
        private Soundex _soundex;

        [TestInitialize]
        public void Init()
        {
            _soundex = new Soundex();
        }

        [TestMethod]
        public void ShouldRetainFirstLetter()
        {
            var actual = _soundex.Encode("A");
            Assert.AreEqual("A000",actual);
        }

        [TestMethod]
        public void ShouldPadWithZerosWhenLengthShorterThanFour()
        {
            var actual = _soundex.Encode("I");
            Assert.AreEqual(4,actual.Length);
            Assert.AreEqual("I000", actual);

        }
    }


}
