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
        private string[] _stopWords = { "is", "of", "and", "the", "a", "at", "or", "for", "on", "to", "in", "nbsp" };

        private const string REGEX_PATTERN = @"[^\W\d](\w|[-`]{1}(?=\w))+";

        private const string TEXT_XPATH = "//text()[normalize-space(.)]";

        private const string META_XPATH = "//meta[@name='description']";

        private const string EXTERNAL_LINKS_XPATH = "//a[starts-with(@href,'http://') or starts-with(@href,'https://')]";

        public List<string> ParseText(string text)
        {
            return new Regex(REGEX_PATTERN)
                .Matches(text)
                .Cast<Match>()
                .Select(c => c.Value.ToLowerInvariant())
                .Where(c => !_stopWords.Contains(c))
                .ToList();
        }

        public string GetTextFromHtml(HtmlDocument doc)
        {
            StringBuilder result = new StringBuilder();

            if (doc.DocumentNode != null)
            {
                doc.DocumentNode.Descendants()
                    .Where(node => node.Name == "script" || node.Name == "style")
                    .ToList()
                    .ForEach(item => item.Remove());

                foreach (HtmlNode node in doc.DocumentNode.SelectNodes(TEXT_XPATH))
                {
                    result.Append(node.InnerText.Trim()).Append(" ");
                }
            }

            return result.ToString();
        }

        public string GetTextFromMetaTags(HtmlDocument doc)
        {
            HtmlNode node = doc.DocumentNode.SelectSingleNode(META_XPATH);

            if (node != null)
            {
                return node.Attributes["content"].Value;
            }

            return string.Empty;
        }

        public int CountExternalLinks(HtmlDocument doc, string baseUrl)
        {
            return doc.DocumentNode
                .SelectNodes(EXTERNAL_LINKS_XPATH)
                .Count(node => !node.Attributes["href"].Value.Contains(baseUrl));
        }
    }
}