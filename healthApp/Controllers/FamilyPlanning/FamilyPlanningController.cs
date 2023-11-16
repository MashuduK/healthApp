using Microsoft.AspNetCore.Mvc;

namespace healthApp.Controllers.FamilyPlanning
{
    public class FamilyPlanningController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        // Action for displaying educational resources
        public ActionResult Education()
        {
            // You can add logic to fetch and display educational resources
            return View();
        }

        // Action for redirecting to the MenstrualCycleController
        public ActionResult MenstrualCycle()
        {
            // Redirect to the MenstrualCycleController's Index action
            return RedirectToAction("Index", "MenstrualCycle");
        }

        // Action for redirecting to the ContraceptionController
        public ActionResult Contraception()
        {
            // Redirect to the ContraceptionController's Index action
            return RedirectToAction("Index", "Contraception");
        }
    }
}
