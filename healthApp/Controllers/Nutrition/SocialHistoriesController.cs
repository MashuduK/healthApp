using healthApp.Areas.Identity.Data;
using healthApp.Models.Nutrition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace healthApp.Controllers.Nutrition
{
    public class SocialHistoriesController : Controller
    {

        private readonly ApplicationDbContext _dbcontext;

        public SocialHistoriesController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        // GET: SocialH
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return _dbcontext.SocialHistory != null ?
                         View(await _dbcontext.SocialHistory.ToListAsync()) :
                         Problem("Entity set 'ApplicationDbContext.SocialHistory'  is null.");

        }

        public async Task<IActionResult> Details(int? PatientInfoID)
        {
            //if (PatientInfoID == null || _dbcontext.SocialHistory == null)
            //{
            //    return NotFound();
            //}
            ViewBag.PatientInfoID = PatientInfoID;
            var socialHistory = await _dbcontext.SocialHistory
                .Include(s => s.PatientInfo)
                .FirstOrDefaultAsync(m => m.PatientInfoID == PatientInfoID);
            if (socialHistory == null)
            {
                return RedirectToAction(nameof(Create), new { ViewBag.PatientInfoID });
            }

            return View(socialHistory);
        }

        // GET: SocialH/Create
        public IActionResult Create(int? PatientInfoID)
        {
            ViewBag.PatientInfoID = PatientInfoID;
            //ViewData["PatientInfoID"] = PatientInfoID;
            return View();
        }

        // POST: SocialH/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? PatientInfoID, [Bind("SocialHistoryID,SmokingFrequency,AlcoholType,AlcoholFrequency,AlcoholQuantity,PhysActivity,PatientInfoID")] SocialH? socialH)
        {
            if (ModelState.IsValid)
            {
                ViewBag.PatientInfoID = PatientInfoID;
                socialH.PatientInfoID = PatientInfoID;
                _dbcontext.Add(socialH);
                await _dbcontext.SaveChangesAsync();

            }
            return RedirectToAction(nameof(Details), new { socialH.PatientInfoID });
            //return View(socialH);
        }

        // GET: SocialH/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialH = await _dbcontext.SocialHistory.FindAsync(id);
            if (socialH == null)
            {
                return NotFound();
            }

            return View(socialH);
        }

        // POST: SocialH/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SocialHistoryID,SmokingFrequency,AlcoholType,AlcoholFrequency,AlcoholQuantity,PhysActivity")] SocialH socialH)
        {
            ViewBag.PatientInfoID = socialH.PatientInfoID;
            if (id != socialH.SocialHistoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbcontext.Update(socialH);
                    await _dbcontext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialHExists(socialH.SocialHistoryID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { PatientInfoID = socialH.PatientInfoID });
            }
            return View(socialH);
        }

        // GET: SocialH/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialH = await _dbcontext.SocialHistory
                .FirstOrDefaultAsync(m => m.SocialHistoryID == id);
            if (socialH == null)
            {
                return NotFound();
            }

            return View(socialH);
        }

        // POST: SocialH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var socialH = await _dbcontext.SocialHistory.FindAsync(id);
            _dbcontext.SocialHistory.Remove(socialH);
            await _dbcontext.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { PatientInfoID = socialH.PatientInfoID });
        }

        private bool SocialHExists(int id)
        {
            return _dbcontext.SocialHistory.Any(e => e.SocialHistoryID == id);
        }
    }
}
