using System.Web.Mvc;
using SeoAnalyzer.Core;
using SeoAnalyzer.Models;

namespace SeoAnalyzer.Controllers
{
    public class AnalyzerController : Controller
    {   
        [HttpGet]
        public ViewResult Home()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Home(AnalysisParameters parameters)
        {
            if (ModelState.IsValid)
            {
                AnalysisResult result = new ContentProcessor().Process(parameters);

                return View("Result", result);
            }

            return View();
        }
    }
}
