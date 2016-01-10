using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace SeoAnalyzer.Core
{
    public class ContentParser
    {
        //hardcoded in order to keep application simple
        private string[] _stopWords = { "of", "and", "the", "a", "at", "or", "for", "on", "to" };

        private const string REGEX_PATTERN = @"[^\W\d](\w|[-`]{1}(?=\w))*";

        private const string XPATH_EXPR = "//text()[normalize-space(.)]";

        public List<string> ParseText(string text)
        {
            return new Regex(REGEX_PATTERN)
                .Matches(text)
                .Cast<Match>()
                .Select(c => c.Value.ToLowerInvariant())
                .Where(c => !_stopWords.Contains(c))
                .ToList();
        }

        public string GetTextFromHtml(string url)
        {
            StringBuilder result = new StringBuilder();

            HtmlDocument doc = new HtmlWeb().Load(url);

            doc.DocumentNode.Descendants()
                .Where(node => node.Name == "script" || node.Name == "style")
                .ToList()
                .ForEach(item => item.Remove());

            foreach (HtmlNode node in doc.DocumentNode.SelectNodes(XPATH_EXPR))
            {
                result.Append(node.InnerText.Trim()).Append(" ");
            }

            return result.ToString();
        }
    }
}