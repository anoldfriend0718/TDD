using System;

namespace TDDPractices
{
    public class Soundex
    {
        private readonly int _maxCodeLength=4;

        public string Encode(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                throw new ArgumentException("Word should not be null or empty");
            }

            var head = GetHead(word);
            return PadWithZero(head);
        }

        private string GetHead(string word)
        {
            return word.Substring(0, 1);
        }

        private string PadWithZero(string word)
        {
            if (word.Length >= _maxCodeLength) return word;
            var zeros=new string('0',_maxCodeLength-word.Length);
            return String.Concat(word,zeros);
        }
    }
}