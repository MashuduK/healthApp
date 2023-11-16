using healthApp.Areas.Identity.Data;
using healthApp.Models.Nutrition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace healthApp.Controllers.Nutrition
{
    public class DietaryInfoController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;

        public DietaryInfoController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        // GET: DietaryInfoController
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> Index()
        {
            return _dbcontext.DietaryInfo != null ?
                            View(await _dbcontext.DietaryInfo.ToListAsync()) :
                            Problem("Entity set 'ApplicationDbContext.DietaryInfo'  is null.");
        }

        // GET: DietaryInfoController/Details/5
        public async Task<IActionResult> Details(int PatientInfoID)
        {
            //if (PatientInfoID == null || _dbcontext.SocialHistory == null)
            //{
            //    return NotFound();
            //}
            ViewBag.PatientInfoID = PatientInfoID;
            var Dinfo = await _dbcontext.DietaryInfo
                .FirstOrDefaultAsync(m => m.PatientInfoID == PatientInfoID);
            if (Dinfo == null)
            {
                return RedirectToAction(nameof(Create), new { PatientInfoID });
            }

            return View(Dinfo);
        }

        // GET: DietaryInfoController/Create
        public IActionResult Create(int? PatientInfoID)
        {
            ViewBag.PatientInfoID = PatientInfoID;
           
            return View();
        }

        // POST: DietaryInfoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int PatientInfoID, [Bind("DietaryInfoID,BreakfastFood,BreakfastMethod,BreakfastAmount,BreakfastTotalCalories,AMSnackFood,AMSnackMethod,AMSnackAmount,AMSnacktotalclories,LunchFood,LunchMethod,LunchAmount,LunchTotalCalories,PMSnackFood,PMSnackMethod,PMSnackAmout,PMSnackTotalCalories,DinnerFood,DinnerMethod,DinnerAmount,DinnerTotalCalories,PatientInfoID")] DietaryInfo dietaryInfo)
        {
            if (ModelState.IsValid)
            {
                ViewBag.PatientInfoID = PatientInfoID;
                dietaryInfo.PatientInfoID = PatientInfoID;
                _dbcontext.Add(dietaryInfo);
                await _dbcontext.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { PatientInfoID });
            }
           
            return View(dietaryInfo);
        }

        // GET: DietaryInfoController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietaryInfo = await _dbcontext.DietaryInfo.FindAsync(id);
            if (dietaryInfo == null)
            {
                return NotFound();
            }

            return View(dietaryInfo);
        }

        // POST: DietaryInfoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DietaryInfoID,BreakfastFood,BreakfastMethod,BreakfastAmount,BreakfastTotalCalories,AMSnackFood,AMSnackMethod,AMSnackAmount,AMSnacktotalclories,LunchFood,LunchMethod,LunchAmount,LunchTotalCalories,PMSnackFood,PMSnackMethod,PMSnackAmout,PMSnackTotalCalories,DinnerFood,DinnerMethod,DinnerAmount,DinnerTotalCalories,PatientInfoID")] DietaryInfo dietaryInfo)
        {
            ViewBag.PatientInfoID = dietaryInfo.PatientInfoID;
            if (id != dietaryInfo.DietaryInfoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbcontext.Update(dietaryInfo);
                    await _dbcontext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!DietaryExists(dietaryInfo.DietaryInfoID))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Details), new { dietaryInfo.PatientInfoID });
            }
            return View(dietaryInfo);
        }

        // GET: DietaryInfoController/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietary = await _dbcontext.DietaryInfo
                .FirstOrDefaultAsync(m => m.DietaryInfoID == id);
            if (dietary == null)
            {
                return NotFound();
            }

            return View(dietary);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dietary = await _dbcontext.DietaryInfo.FindAsync(id);
            _dbcontext.DietaryInfo.Remove(dietary);
            await _dbcontext.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { PatientInfoID = dietary.PatientInfoID });
        }
        private bool DietaryExists(int id)
        {
            return (_dbcontext.DietaryInfo?.Any(e => e.DietaryInfoID == id)).GetValueOrDefault();
        }
    }
}
