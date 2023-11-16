using healthApp.Areas.Identity.Data;
using healthApp.Models.FamilyPlanning;
using Microsoft.AspNetCore.Mvc;

namespace healthApp.Controllers.FamilyPlanning
{
    public class MenstrualCycleController : Controller
    {
        private ApplicationDbContext dbContext;

        // Action to display the list of menstrual cycles
        public ActionResult Index()
        {
            // Retrieve and display menstrual cycle data from the database
            List<MenstrualCycle> cycles = dbContext.MenstrualCycles.ToList();
            return View(cycles);
        }

        // Action to add a new menstrual cycle (GET)
        public ActionResult AddCycle()
        {
            return View();
        }

        // Action to add a new menstrual cycle (POST)
        [HttpPost]
        public ActionResult AddCycle(MenstrualCycle cycle)
        {
            if (ModelState.IsValid)
            {
                // For simplicity, add the cycle to the database
                dbContext.MenstrualCycles.Add(cycle);
                dbContext.SaveChanges();

                // Redirect to the menstrual cycle list page
                return RedirectToAction("Index");
            }

            // If the model state is not valid, return to the AddCycle view with validation errors
            return View(cycle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
