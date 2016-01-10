using System.Collections.Generic;
using System.Linq;
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
                parameters.Content = _contentParser.GetTextFromHtml(parameters.Content);
            }

            result.OccurrencesInText = CalculateNumberOfOccurences(_contentParser.ParseText(parameters.Content));
            
            return result;
        }

        private Dictionary<string, int> CalculateNumberOfOccurences(List<string> text)
        {
            return text.GroupBy(c => c)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}