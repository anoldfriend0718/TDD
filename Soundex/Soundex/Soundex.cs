using System;
using System.Collections.Generic;
using System.Linq;

namespace TDDPractices
{
    public class Soundex
    {
        private readonly List<char> _abandonedLetters=new List<char>()
        {
            'a','e','i','o','u','y','h','w'
        };
        public string AbandonLettersofAEIOUYHW(string input)
        {
            if(string.IsNullOrEmpty(input))
                throw new ArgumentException("input should not be empty or null");
            var retainedChars = new List<Char>();
            retainedChars.Add(input[0]);
            retainedChars.AddRange(
                input.Skip(1)
                .Where(x => !_abandonedLetters.Contains(x)));
            var retainedOutputStr = new String(retainedChars.ToArray());
            return retainedOutputStr;
        }

        private readonly IDictionary<char, int> _cononantNumberMap = new Dictionary<char, int>()
        {
            {'b', 1},{'f',1},{'p',1},{'v',1},
            { 'c',2},{'g',2},{'j',2},{'k',2},{'q',2},{'s',2},{'x',2},{'z',2},
            { 'd',3},{'t',3},
            { 'l',4},
            { 'm',5},{'n',5},
            { 'r',6}
        };

        public int ReplaceCononantWithNumber(char c)
        {
            return _cononantNumberMap[c];
        }
    }
}