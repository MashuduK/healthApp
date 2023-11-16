using healthApp.Areas.Identity.Data;
using healthApp.Models.Nutrition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace healthApp.Controllers.Nutrition
{
    public class SGAController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;

        public SGAController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        // GET: SGA
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return _dbcontext.SGA != null ?
                         View(await _dbcontext.SGA.ToListAsync()) :
                         Problem("Entity set 'ApplicationDbContext.SGA'  is null.");

        }

        // GET: SGA/Details/5
        public async Task<IActionResult> Details(int? PatientInfoID)
        {
            if (PatientInfoID == null || _dbcontext.SGA == null)
            {
                return NotFound();
            }
            ViewBag.PatientInfoID = PatientInfoID;
            var sGA = await _dbcontext.SGA
                .Include(s => s.PatientInfo)
                .FirstOrDefaultAsync(m => m.PatientInfoID == PatientInfoID);
            if (sGA == null)
            {
                return RedirectToAction(nameof(Create), new { PatientInfoID });
            }

            return View(sGA);
        }

        // GET: SGA/Create
        public IActionResult Create(int? PatientInfoID)
        {
            ViewBag.PatientInfoID = PatientInfoID;
            ViewData["PatientInfoID"] = PatientInfoID;
            return View();
        }

        // POST: SGA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int PatientInfoID, [Bind("SgaID,WeightLoss,FoodIntake,GastrointestinalSymptom,FunctionalCapacity,NutritionalRequirementDisease,PhysicalExam,EdemaPresence,AlbuminSGA,BMI,TIC,TotalScore,PatientInfoID")] SGA sGA)
        {
            if (ModelState.IsValid)
            {
                ViewBag.PatientInfoID = PatientInfoID;
                sGA.PatientInfoID = PatientInfoID;

                _dbcontext.Add(sGA);
                await _dbcontext.SaveChangesAsync();

            }
            return RedirectToAction(nameof(Details), new { PatientInfoID });
            //ViewData["PatientInfoID"] =  sGA.PatientInfoID;
            //return View(sGA);
        }

        // GET: SGA/Edit/5
        public async Task<IActionResult> Edit(int? SgaID)
        {
            if (SgaID == null || _dbcontext.SGA == null)
            {
                return NotFound();
            }


            var sGA = await _dbcontext.SGA.FirstOrDefaultAsync(p => p.SgaID == SgaID);
            if (sGA == null)
            {
                return NotFound();
            }
            ViewBag.PatientInfoID = sGA.PatientInfoID;
            ViewData["PatientInfoID"] = sGA.PatientInfoID;
            return View(sGA);
        }

        // POST: SGA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int SgaID, [Bind("SgaID,WeightLoss,FoodIntake,GastrointestinalSymptom,FunctionalCapacity,NutritionalRequirementDisease,PhysicalExam,EdemaPresence,AlbuminSGA,BMI,TIC,TotalScore,PatientInfoID")] SGA sGA)
        {
            if (SgaID != sGA.SgaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbcontext.Update(sGA);
                    await _dbcontext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SGAExists(sGA.SgaID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details));
            }
            ViewBag.PatientInfoID = sGA.PatientInfoID;
            ViewData["PatientInfoID"] = sGA.PatientInfoID;
            return View(sGA);
        }

        // GET: SGA/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _dbcontext.SGA == null)
            {
                return NotFound();
            }

            var sGA = await _dbcontext.SGA
                .Include(s => s.PatientInfo)
                .FirstOrDefaultAsync(m => m.SgaID == id);
            if (sGA == null)
            {
                return NotFound();
            }

            return View(sGA);
        }

        // POST: SGA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_dbcontext.SGA == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SGA'  is null.");
            }
            var sGA = await _dbcontext.SGA.FindAsync(id);
            if (sGA != null)
            {
                _dbcontext.SGA.Remove(sGA);
            }

            await _dbcontext.SaveChangesAsync();
            return RedirectToAction(nameof(Details));
        }

        private bool SGAExists(int id)
        {
            return (_dbcontext.SGA?.Any(e => e.SgaID == id)).GetValueOrDefault();
        }
    }
}
