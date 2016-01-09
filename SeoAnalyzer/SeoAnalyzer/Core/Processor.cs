using System.Linq;
using System.Text.RegularExpressions;
using SeoAnalyzer.Core.Parsers;
using SeoAnalyzer.Models;

namespace SeoAnalyzer.Core
{
    public class Processor
    {
        public AnalysisResult Process(AnalysisParameters parameters)
        {
            AnalysisResult result = new AnalysisResult();

            if (!parameters.IsUrl)
            {
                result.OccurrencesInText = new PlainTextParser().Parse(parameters.Text);
            }

            return result;
        }
    }
}