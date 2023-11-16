using healthApp.Areas.Identity.Data;
using healthApp.Models.FamilyPlanning;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace healthApp.Controllers.FamilyPlanning
{
    public class MenstrualCycleController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public MenstrualCycleController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(User).Result;
            var menstrualCycles = _context.MenstrualCycles.Where(c => c.UserId == user.Id).ToList();
            return View(menstrualCycles);
        }

        public IActionResult AddMenstrualCycle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMenstrualCycle(MenstrualCycleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    var menstrualCycle = new MenstrualCycle
                    {
                        UserId = user.Id,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };

                    _context.MenstrualCycles.Add(menstrualCycle);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("MenstrualCycleList");
                }
            }

            return View(model);
        }

        public IActionResult MenstrualCycleList()
        {
            var user = _userManager.GetUserAsync(User).Result;
            var menstrualCycles = _context.MenstrualCycles.Where(c => c.UserId == user.Id).ToList();
            return View(menstrualCycles);
        }
    }
}
