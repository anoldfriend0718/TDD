using System;
using Xunit;
using Soundex;

namespace Sounder.Tests
{
    public class SounderTests
    {
        [Theory]
        [InlineData("Apple","Appl")]
        [InlineData("Inline","Inlin")]
        [InlineData("Outing","utng")]
        [InlineData("Year","r")]
        [InlineData("While","l")]
        public void Should_Abandon_A_E_I_O_U_Y_H_W(string input, string output)
        {
            var soundex =new Soundex.Soundex();
            string actual = soundex.AbandonLettersofAEIOUYHW();
            Assert.Equal(input,output);
        }
    }
}
