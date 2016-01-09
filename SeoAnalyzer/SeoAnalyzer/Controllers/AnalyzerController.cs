using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            return View(new AnalysisParameters { AnalyzeText = true });
        }

        [HttpPost]
        public ActionResult Home(AnalysisParameters parameters)
        {
            if (ModelState.IsValid)
            {
                AnalysisResult result = new Processor().Process(parameters);

                return View("Result", result);
            }

            return View();
        }
    }
}
