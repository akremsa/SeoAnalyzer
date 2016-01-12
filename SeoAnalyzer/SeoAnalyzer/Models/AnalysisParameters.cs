
namespace SeoAnalyzer.Models
{
    public class AnalysisParameters
    {
        public string Content { get; set; }

        public bool IsUrl { get; set; }

        public bool AnalyzeMetaTags { get; set; }

        public bool CountExternalLinks { get; set; }
    }
}