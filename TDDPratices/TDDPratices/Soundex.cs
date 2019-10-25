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

            return GetHead(word);
        }

        private string GetHead(string word)
        {
            return word.Substring(0, 1);
        }
    }
}