using healthApp.Areas.Identity.Data;
using healthApp.Models.Nutrition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace healthApp.Controllers.Nutrition
{
    public class Screening2Controller : Controller
    {

        private readonly ApplicationDbContext _context;
        private static Random random = new Random();

        public Screening2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return _context.Screening2 != null ?
                         View(await _context.Screening2.ToListAsync()) :
                         Problem("Entity set 'ApplicationDbContext.Screening'  is null.");

        }

        public async Task<IActionResult> Details(int? PatientInfoID)
        {
            ViewData["PatientInfoID"] = PatientInfoID;
            ViewBag.PatientInfoID = PatientInfoID;
            //if (PatientInfoID == null || _context.Screening == null)
            //{
            //    return NotFound();
            //}

            var screening = await _context.Screening2
                .Include(s => s.PatientInfo)
                .FirstOrDefaultAsync(m => m.PatientInfoID == PatientInfoID);
            if (screening == null)
            {
                return RedirectToAction(nameof(Create), new { ViewBag.PatientInfoID });
            }

            return View(screening);
        }
        public IActionResult Create(int? PatientInfoID)
        {

            ViewData["PatientInfoID"] = PatientInfoID;
            PatientInfoID = ViewBag.PatientInfoID;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? PatientInfoID, [Bind("ScreeningId,ExtremeBMI,WeightLoss,ReducedIntake,SevereIllness,RiskScore")] Screening2? screening)
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Screening2 == null)
            {
                return NotFound();
            }

            var screening = await _context.Screening2.FindAsync(id);
            if (screening == null)
            {
                return NotFound();
            }
            ViewBag.PatientInfoID = screening.PatientInfoID;
            //ViewData["PatientInfoID"] = new SelectList(_context.PatientInfos, "PatientInfoID", "Address", screening.PatientInfoID);
            return View(screening);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScreeningId,ExtremeBMI,WeightLoss,ReducedIntake,SevereIllness,RiskScore,PatientInfoID")] Screening2 screening)
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

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Screening2 == null)
            {
                return NotFound();
            }

            var screening = await _context.Screening2
                .Include(s => s.PatientInfo)
                .FirstOrDefaultAsync(m => m.ScreeningId == id);
            if (screening == null)
            {
                return NotFound();
            }

            return View(screening);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Screening2 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Screening2'  is null.");
            }
            var screening = await _context.Screening2.FindAsync(id);
            if (screening != null)
            {
                _context.Screening2.Remove(screening);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScreeningExists(int id)
        {
            return (_context.Screening2?.Any(e => e.ScreeningId == id)).GetValueOrDefault();
        }
    }
}
