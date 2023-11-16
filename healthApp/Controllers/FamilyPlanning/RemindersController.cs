using healthApp.Areas.Identity.Data;
using healthApp.Models.FamilyPlanning;
using Microsoft.AspNetCore.Mvc;

namespace healthApp.Controllers.FamilyPlanning
{
    public class RemindersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RemindersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var reminders = _context.ContraceptionReminders.ToList();
            return View(reminders);
        }

        public IActionResult AddReminder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddReminder(ContraceptionReminder reminder)
        {
            if (ModelState.IsValid)
            {
                _context.ContraceptionReminders.Add(reminder);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reminder);
        }
    }
}
