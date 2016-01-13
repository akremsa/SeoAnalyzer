using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using HtmlAgilityPack;
using SeoAnalyzer.Models;

namespace SeoAnalyzer.Core
{
    public class ContentProcessor
    {
        private readonly ContentParser _contentParser;

        public ContentProcessor()
        {
            _contentParser = new ContentParser();
        }

        public AnalysisResult Process(AnalysisParameters parameters)
        {
            AnalysisResult result = new AnalysisResult();

            string textForAnalysis = parameters.Content;

            if (parameters.IsUrl)
            {
                HtmlDocument doc = new HtmlWeb().Load(parameters.Content);

                textForAnalysis = _contentParser.GetTextFromHtml(doc);

                if (parameters.IsAnalyzeMetaTags)
                {
                    string metaTagsText = _contentParser.GetTextFromMetaTags(doc);

                    if (!String.IsNullOrEmpty(metaTagsText))
                    {
                        result.MetaTagsAnalysis = CalculateNumberOfOccurences(_contentParser.ParseText(metaTagsText));
                    }
                }

                if (parameters.IsCountExternalLinks)
                {
                    result.ExternalLinksCount = _contentParser.CountExternalLinks(doc, new Uri(parameters.Content).Host);
                }
            }

            result.TextAnalysis = CalculateNumberOfOccurences(_contentParser.ParseText(textForAnalysis));
            
            return result;
        }

        private Dictionary<string, int> CalculateNumberOfOccurences(List<string> wordsList)
        {
            return wordsList.GroupBy(c => c)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}