using System;

namespace TDDPractices
{
    public class Soundex
    {
        public string Encode(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                throw new ArgumentException("Word should not be null or empty");
            }

            return PadWithZero(GetHead(word));
        }

        private string GetHead(string word)
        {
            return word.Substring(0, 1);
        }

        private string PadWithZero(string word)
        {
            if (word.Length >= 4) return word;
            var zeros=new string('0',4-word.Length);
            return String.Concat(word,zeros);
        }
    }
}