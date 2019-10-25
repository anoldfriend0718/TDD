using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TDDPractices
{
    public class Soundex
    {
        private readonly int _maxCodeLength=4;
        private readonly IDictionary<char, int> _consonantDigitMap = new Dictionary<char, int>()
        {
            { 'b',1},{'f',1},{'p',1},{'v',1},
            { 'c',2},{'g',2},{'j',2},{'k',2},{'q',2},{'s',2},{'x',2},{'z',2},
            { 'd',3},{'t',3},
            { 'l',4},
            { 'm',5},{'n',5},
            { 'r',6}
        };
        private readonly char[] VowelLikeLetters = new[] { 'a', 'e', 'i', 'o', 'u', 'y', 'h', 'w' };

        public string Encode(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                throw new ArgumentException("Word should not be null or empty");
            }

            var head = GetHead(word);
            var tails = GetTails(word);
            var tailsWithoutVowelLikeLetters = AbandonVowelLikeLetters(tails);
            var digits = ReplaceConsonantWithDigits(tailsWithoutVowelLikeLetters);
            var combinedDigits = CombineSameNeighborDigits(digits);
            var topThreeDigits = LimitDigitsLessThanThree(combinedDigits);
            var code = $"{head}{topThreeDigits}";
            return PadWithZero(code);
        }

        private string LimitDigitsLessThanThree(string digits)
        {
            var topThree = digits.Take(3);
            return String.Concat(topThree);
        }

        private string GetTails(string word)
        {
            return word.Substring(1);
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



        private string AbandonVowelLikeLetters(string word)
        {
            return String.Concat(word.Where(c =>!VowelLikeLetters.Contains(c)));
        }

        private string ReplaceConsonantWithDigits(string tails)
        {
            var digits = tails
                .Select(c => _consonantDigitMap[c])
                .Select(i => Convert.ToString(i));
            return string.Concat(digits);
        }

        private string CombineSameNeighborDigits(string digits)
        {
            var length = digits.Length;
            var selected = new List<char>();
            selected.Add(digits[0]);
            for (int i = 1; i < length; i++)
            {
                var last = digits[i - 1];
                var current = digits[i];
                if (current != last)
                {
                    selected.Add(current);
                }
            }
            return String.Concat(selected);
        }
    }
}