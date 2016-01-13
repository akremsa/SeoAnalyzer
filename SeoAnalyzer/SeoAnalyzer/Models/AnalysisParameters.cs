using System.ComponentModel.DataAnnotations;

namespace SeoAnalyzer.Models
{
    public class AnalysisParameters
    {
        [Required(ErrorMessage = "Please, insert text or URL")]
        public string Content { get; set; }

        public bool IsUrl { get; set; }

        public bool IsAnalyzeMetaTags { get; set; }

        public bool IsCountExternalLinks { get; set; }
    }
}