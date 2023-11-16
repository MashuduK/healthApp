using healthApp.Areas.Identity.Data;
using healthApp.Models.Nutrition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace healthApp.Controllers.Nutrition
{
    public class ScreeningsController : Controller
    {
        private readonly ApplicationDbContext _context;


        public ScreeningsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Screenings
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return _context.MacroNutrients != null ?
                         View(await _context.MacroNutrients.ToListAsync()) :
                         Problem("Entity set 'ApplicationDbContext.MacroNutrients'  is null.");

        }

        // GET: Screenings/Details/5
        public async Task<IActionResult> Details(int? PatientInfoID)
        {
            ViewData["PatientInfoID"] = PatientInfoID;
            ViewBag.PatientInfoID = PatientInfoID;
            if (PatientInfoID == null || _context.Screening == null)
            {
                return NotFound();
            }

            var screening = await _context.Screening
                .Include(s => s.PatientInfo)
                .FirstOrDefaultAsync(m => m.PatientInfoID == PatientInfoID);
            if (screening == null)
            {
                return RedirectToAction(nameof(Create), new { ViewBag.PatientInfoID });
            }

            return View(screening);
        }

        // GET: Screenings/Create
        public IActionResult Create(int? PatientInfoID)
        {

            ViewData["PatientInfoID"] = PatientInfoID;
            PatientInfoID = ViewBag.PatientInfoID;

            return View();
        }

        // POST: Screenings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? PatientInfoID, [Bind("ScreeningId,ExtremeBMI,WeightLoss,ReducedIntake,SevereIllness,RiskScore")] Screening? screening)
        {

            if (ModelState.IsValid)
            {
                ViewBag.PatientInfoID = PatientInfoID;
                //screening.PatientInfoID = PatientInfoID;
                screening.PatientInfoID = ViewBag.PatientInfoID;
                //screening.ReducedIntake = random.NextDouble()* 100;
                //screening.SevereIllness = random.NextDouble()* 100;
                //screening.WeightLoss = random.NextDouble()* 100;
                //screening.RiskScore = random.Next(11);
                //screening.ExtremeBMI = random.NextDouble()* 100;
                _context.Add(screening);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { screening.PatientInfoID });
            }

            return View(screening);
        }

        // GET: Screenings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Screening == null)
            {
                return NotFound();
            }

            var screening = await _context.Screening.FindAsync(id);
            if (screening == null)
            {
                return NotFound();
            }
            ViewBag.PatientInfoID = screening.PatientInfoID;
            //ViewData["PatientInfoID"] = new SelectList(_context.PatientInfos, "PatientInfoID", "Address", screening.PatientInfoID);
            return View(screening);
        }

        // POST: Screenings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScreeningId,ExtremeBMI,WeightLoss,ReducedIntake,SevereIllness,RiskScore,PatientInfoID")] Screening screening)
        {
            if (id != screening.ScreeningId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(screening);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScreeningExists(screening.ScreeningId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientInfoID"] = new SelectList(_context.PatientInfos, "PatientInfoID", "Address", screening.PatientInfoID);
            return View(screening);
        }

        // GET: Screenings/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Screening == null)
            {
                return NotFound();
            }

            var screening = await _context.Screening
                .Include(s => s.PatientInfo)
                .FirstOrDefaultAsync(m => m.ScreeningId == id);
            if (screening == null)
            {
                return NotFound();
            }

            return View(screening);
        }

        // POST: Screenings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Screening == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Screening'  is null.");
            }
            var screening = await _context.Screening.FindAsync(id);
            if (screening != null)
            {
                _context.Screening.Remove(screening);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScreeningExists(int id)
        {
            return (_context.Screening?.Any(e => e.ScreeningId == id)).GetValueOrDefault();
        }
    }
}
