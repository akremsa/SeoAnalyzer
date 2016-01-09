using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SeoAnalyzer.Core.Parsers
{
    public class PlainTextParser
    {
        private string[] _stopWords = { "of", "and", "the", "a", "at", "or" };

        private string pattern = @"[^\W\d](\w|[-`]{1}(?=\w))*";

        public Dictionary<string, int> Parse(string text)
        {
            var wordsCollection = new Regex(pattern)
                .Matches(text)
                .Cast<Match>()
                .Select(c => c.Value.ToLowerInvariant())
                .Where(c => !_stopWords.Contains(c))
                .GroupBy(c => c)
                .ToDictionary(g => g.Key, g => g.Count());

            return wordsCollection;
        }
    }
}