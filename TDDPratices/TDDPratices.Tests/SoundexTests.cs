using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDPractices.Tests
{
    [TestClass]
    public class SoundexTests
    {
        [TestMethod]
        public void ShouldRetainFirstLetter()
        {
            var actual = Soundex.Encode("A");
            Assert.AreEqual("A000",actual);
        }

        [TestMethod]
        public void ShouldPadWithZerosWhenLengthShorterThanFour()
        {
            var actual = Soundex.Encode("I");
            Assert.AreEqual(4,actual.Length);
            Assert.AreEqual("I000", actual);
        }

        [TestMethod]
        public void ShouldUseDigitsInsteadOfConsonant()
        {
            var actual = Soundex.Encode("Ib");
            Assert.AreEqual("I100",actual);
        }

        [TestMethod]
        public void ShouldReplaceMultipleConsonantWithDigits()
        {
            var actual = Soundex.Encode("Ibcm");
            Assert.AreEqual("I125", actual);
        }

        [TestMethod]
        public void ShouldLimitDigitLessThanThree()
        {
            var actual = Soundex.Encode("Ibcmr");
            Assert.AreEqual("I125", actual);
        }

        [TestMethod]
        public void ShouldAbandonVowelLikeLetters()
        {
            var actual = Soundex.Encode("Iaem");
            Assert.AreEqual("I500",actual);
        }

        [TestMethod]
        public void ShouldCombineNeighborDigitsWhenTheyAreSame()
        {
            var actual = Soundex.Encode("Icgb");
            Assert.AreEqual("I210",actual);
        }

        [TestMethod]
        public void ShouldCombineSameDigitsWhenTheyAreSeperatedByHorW()
        {
            var actual = Soundex.Encode("Ichg");
            Assert.AreEqual("I200", actual);
        }

        [TestMethod]
        public void ShouldNotCombineSameDigitsWhenTheyAreSeperatedByY()
        {
            var actual = Soundex.Encode("Icyg");
            Assert.AreEqual("I220", actual);
        }

        [TestMethod]
        public void ShouldNotCombineSameDigitsWhenTheyAreSeperatedByVowels()
        {
            var actual = Soundex.Encode("Icag");
            Assert.AreEqual("I220", actual);
        }

        [TestMethod]
        public void ShouldIgnoreNonLetter()
        {
            var actual = Soundex.Encode("I#ag");
            Assert.AreEqual("I200", actual);
        }

        [TestMethod]
        public void HeadShouldBeUpperCase()
        {
            var actual = Soundex.Encode("i");
            Assert.AreEqual("I000", actual);
        }
    }


}
