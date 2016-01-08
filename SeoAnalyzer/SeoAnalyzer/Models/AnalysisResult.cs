using System.Collections.Generic;

namespace SeoAnalyzer.Models
{
    public class AnalysisResult
    {
        Dictionary<string, int> OccurrencesInText { get; set; }

        Dictionary<string, int> OccurrencesInMetaTags { get; set; }

        int ExternalLinksCount { get; set; }
    }
}