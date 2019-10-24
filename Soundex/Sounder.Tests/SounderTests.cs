using System;
using Xunit;

namespace TDDPractices.Classes.Tests
{
    public class SounderTests
    {
        [Theory]
        [InlineData("Apple","Appl")]
        [InlineData("Inline","Inln")]
        [InlineData("Outing", "Otng")]
        [InlineData("Year","Yr")]
        [InlineData("While","Wl")]
        public void Should_Abandon_A_E_I_O_U_Y_H_W(string input, string expectedOutput)
        {
            var soundex =new Soundex();
            string actualOutput = soundex.AbandonLettersofAEIOUYHW(input);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Theory]
        [InlineData('b', 1)]
        [InlineData('c', 2)]
        [InlineData('d', 3)]
        [InlineData('l', 4)]
        [InlineData('m', 5)]
        [InlineData('r', 6)]
        public void Should_Replace_Cononant_With_Number(char c,int expectedNum)
        {
            var soundex = new Soundex();
            int actualNum=soundex.ReplaceCononantWithNumber(c);
            Assert.Equal(expectedNum,actualNum);
        }
    }
}
