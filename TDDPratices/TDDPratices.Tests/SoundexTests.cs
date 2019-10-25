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

        [TestMethod]
        public void ShouldUseDigitsInsteadOfConsonant()
        {
            var actual = _soundex.Encode("Ib");
            Assert.AreEqual("I100",actual);
        }

        [TestMethod]
        public void ShouldReplaceMultipleConsonantWithDigits()
        {
            var actual = _soundex.Encode("Ibcm");
            Assert.AreEqual("I125", actual);
        }

        [TestMethod]
        public void ShouldLimitDigitLessThanThree()
        {
            var actual = _soundex.Encode("Ibcmr");
            Assert.AreEqual("I125", actual);
        }

        [TestMethod]
        public void ShouldAbandonVowelLikeLetters()
        {
            var actual = _soundex.Encode("Iaem");
            Assert.AreEqual("I500",actual);
        }

        [TestMethod]
        public void ShouldCombineNeighborDigitsWhenTheyAreSame()
        {
            var actual = _soundex.Encode("Icgb");
            Assert.AreEqual("I210",actual);
        }
    }


}
