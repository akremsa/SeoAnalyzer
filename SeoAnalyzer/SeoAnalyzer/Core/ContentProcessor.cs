using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using Microsoft.Ajax.Utilities;
using SeoAnalyzer.Models;

namespace SeoAnalyzer.Core
{
    public class ContentProcessor
    {
        private ContentParser _contentParser;

        public ContentProcessor()
        {
            _contentParser = new ContentParser();
        }

        public AnalysisResult Process(AnalysisParameters parameters)
        {
            AnalysisResult result = new AnalysisResult();

            if (parameters.IsUrl)
            {
                HtmlDocument doc = new HtmlWeb().Load(parameters.Content);
                parameters.Content = _contentParser.GetTextFromHtml(doc);

                if (parameters.AnalyzeMetaTags)
                {
                    string metaTagsText = _contentParser.GetTextFromMetaTags(doc);

                    if (!String.IsNullOrEmpty(metaTagsText))
                    {
                        result.MetaTagsAnalysis = CalculateNumberOfOccurences(_contentParser.ParseText(metaTagsText));
                    }
                }
            }

            result.TextAnalysis = CalculateNumberOfOccurences(_contentParser.ParseText(parameters.Content));
            
            return result;
        }

        private Dictionary<string, int> CalculateNumberOfOccurences(List<string> text)
        {
            return text.GroupBy(c => c)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}