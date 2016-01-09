using System.Collections.Generic;

namespace SeoAnalyzer.Models
{
    public class AnalysisResult
    {
        public Dictionary<string, int> OccurrencesInText { get; set; }

        public Dictionary<string, int> OccurrencesInMetaTags { get; set; }

        public int ExternalLinksCount { get; set; }
    }
}