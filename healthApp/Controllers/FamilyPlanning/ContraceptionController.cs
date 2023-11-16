using healthApp.Areas.Identity.Data;
using healthApp.Models.FamilyPlanning;
using Microsoft.AspNetCore.Mvc;

namespace healthApp.Controllers.FamilyPlanning
{
    public class ContraceptionController : Controller
    {
        private ApplicationDbContext dbContext;

        // Action to display the list of contraception reminders
        public ActionResult Index()
        {
            List<ContraceptionReminder> reminders = dbContext.ContraceptionReminders.ToList();
            return View(reminders);
        }

        // Action to set a new contraception reminder (GET)
        public ActionResult SetReminder()
        {
            return View();
        }

        // Action to set a new contraception reminder (POST)
        [HttpPost]
        public ActionResult SetReminder(ContraceptionReminder reminder)
        {
            if (ModelState.IsValid)
            {
                // For simplicity, add the reminder to the database
                dbContext.ContraceptionReminders.Add(reminder);
                dbContext.SaveChanges();

                // Redirect to the contraception reminders list page
                return RedirectToAction("Index");
            }

            // If the model state is not valid, return to the SetReminder view with validation errors
            return View(reminder);
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
