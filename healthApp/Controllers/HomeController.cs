using healthApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E_NompiloHealth.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NutritionDeshboard()
        {
            return View();
        }
        //[Authorize(Roles = "Admin")]
        public ActionResult ReportDeshboard()
        {
            return View();
        }
        public ActionResult ToolsDashboard()
        {
            return View();
        }
        public ActionResult AnthropometricMeasurements()
        {
            return View();
        }
        public ActionResult MyFitnessManual()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(Reviews model)
        //{

        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}