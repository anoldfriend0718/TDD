using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDPractices.Tests
{
    [TestClass]
    public class SoundexTests
    {
        [TestMethod]
        public void ShouldRetainFirstLetter()
        {
            var soundex = new Soundex();
            var actual = soundex.Encode("A");
            Assert.AreEqual("A",actual);
        }
    }


}
