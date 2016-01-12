using System.Collections.Generic;

namespace SeoAnalyzer.Models
{
    public class AnalysisResult
    {
        public Dictionary<string, int> TextAnalysis { get; set; }

        public Dictionary<string, int> MetaTagsAnalysis { get; set; }

        public int ExternalLinksCount { get; set; }
    }
}