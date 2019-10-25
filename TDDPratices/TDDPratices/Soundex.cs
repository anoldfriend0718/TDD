using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using static System.String;

namespace TDDPractices
{
    public static class Soundex
    {
        private static readonly int _maxCodeLength=4;
        private static readonly IDictionary<char, int> _consonantDigitMap = new Dictionary<char, int>()
        {
            { 'b',1},{'f',1},{'p',1},{'v',1},
            { 'c',2},{'g',2},{'j',2},{'k',2},{'q',2},{'s',2},{'x',2},{'z',2},
            { 'd',3},{'t',3},
            { 'l',4},
            { 'm',5},{'n',5},
            { 'r',6}
        };
        private static readonly char[] VowelLikeLetters = new[] { 'a', 'e', 'i', 'o', 'u', 'y', 'h', 'w' };

        public static string Encode(string word)
        {
            if (IsNullOrEmpty(word))
            {
                throw new ArgumentException("Word should not be null or empty");
            }

            var head = word
                .GetHeadWithHigherCase();
            var digits = word
                .GetTailsWithLowerCase()
                .ReplaceConsonantWithDigits()
                .CombineSameNeighborDigits()
                .AbandonVowelLikeLetters()
                .LimitDigitsLessThanThree();
            var code = $"{head}{digits}";
            return PadWithZero(code);
        }

        private static string LimitDigitsLessThanThree(this string digits)
        {
            var topThree = digits.Take(3);
            return Concat(topThree);
        }

        private static string GetTailsWithLowerCase(this string word)
        {
            return word.Substring(1).ToLower();
        }

        private static string GetHeadWithHigherCase(this string word)
        {
            return word.Substring(0, 1).ToUpper();
        }

        private static string PadWithZero(this string word)
        {
            if (word.Length >= _maxCodeLength) return word;
            var zeros=new string('0',_maxCodeLength-word.Length);
            return Concat(word,zeros);
        }

        private static string AbandonVowelLikeLetters(this string word)
        {
            return Concat(word.Where(c =>!VowelLikeLetters.Contains(c)));
        }

        private static string ReplaceConsonantWithDigits(this string tails)
        {
            var digits = tails
                .Where(c=>Char.IsLetter(c))
                .Select(c =>
                {
                    if (_consonantDigitMap.ContainsKey(c))
                    {
                        var intDigit = _consonantDigitMap[c];
                        return Convert.ToString(intDigit);
                    }
                    return c.ToString();
                });
            return Concat(digits);
        }

        private static string CombineSameNeighborDigits(this string digits)
        {
            var length = digits.Length;
            if (string.IsNullOrEmpty(digits)) return string.Empty;
            var selected = new List<char> {digits[0]};
            for (var i = 1; i < length; i++)
            {
                var last = digits[i - 1];
                var current = digits[i];
                if (!IsHorW(last) && current != last)
                {
                    selected.Add(current);
                    continue;
                }

                if (IsHorW(last) && i > 2 && current != digits[i - 2])
                {
                    selected.Add(current);
                }
            }
            return Concat(selected);
        }

        private static bool IsHorW(char letter)
        {
            return letter == 'h' || letter == 'w';
        }
    }
}