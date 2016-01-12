using System.ComponentModel.DataAnnotations;

namespace SeoAnalyzer.Models
{
    public class AnalysisParameters
    {
        [Required(ErrorMessage = "Please, insert text or URL")]
        public string Content { get; set; }

        public bool IsUrl { get; set; }

        public bool AnalyzeMetaTags { get; set; }

        public bool CountExternalLinks { get; set; }
    }
}