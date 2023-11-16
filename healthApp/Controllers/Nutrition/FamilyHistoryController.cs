using healthApp.Areas.Identity.Data;
using healthApp.Models.Nutrition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using System.Data;

namespace healthApp.Controllers.Nutrition
{
    public class FamilyHistoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public FamilyHistoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: FamilyHistory
        //public IActionResult Index()
        //{
        //    var familyHistories = _dbContext.FamilyHistory.ToList();
        //    return View(familyHistories);
        //}
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            

            var familyHistory = await _dbContext.FamilyHistory
               
                .ToListAsync();

          
            return View(familyHistory);
        }
        // GET: FamilyHistory/Create
        public IActionResult Create(int? PatientInfoID)
        {
            ViewBag.PatientInfoID = PatientInfoID;
            //ViewData["PatientInfoID"] = PatientInfoID;
            return View();
            //var patientInfo = _dbContext.PatientInfos.FirstOrDefault(p => p.PatientInfoID == PatientInfoID);
            //if (patientInfo == null)
            //{
            //    return NotFound();
            //}

            //var familyHistory = new FamilyH
            //{
            //    PatientInfo = patientInfo
            //};

            //return View(familyHistory);
        }

        // POST: FamilyHistory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int PatientInfoID, FamilyH model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.PatientInfoID = PatientInfoID;
                model.PatientInfoID = PatientInfoID;
                _dbContext.Add(model);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { PatientInfoID });
            }
            return View(model);
        }

        // GET: FamilyHistory/Edit/1
        public IActionResult Edit(int FamilyHistoryID, int PatientInfoID)
        {
            var model = _dbContext.FamilyHistory.Find(FamilyHistoryID);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: FamilyHistory/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int FamilyHistoryID, FamilyH model)
        {
            if (ModelState.IsValid)
            {
                var existingFamilyHistory = _dbContext.FamilyHistory.Find(FamilyHistoryID);
                if (existingFamilyHistory == null)
                {
                    return NotFound();
                }

                existingFamilyHistory.CardiovascularDisease = model.CardiovascularDisease;
                existingFamilyHistory.NeuromuscularDisease = model.NeuromuscularDisease;
                existingFamilyHistory.DiabetesMellitusType1 = model.DiabetesMellitusType1;
                existingFamilyHistory.DiabetesMellitusType2 = model.DiabetesMellitusType2;
                existingFamilyHistory.Cancer = model.Cancer;
                existingFamilyHistory.GastrointestinalDisease = model.GastrointestinalDisease;
                existingFamilyHistory.KidneyDisease = model.KidneyDisease;
                existingFamilyHistory.EndocrineDisease = model.EndocrineDisease;
                existingFamilyHistory.PulmonaryDisease = model.PulmonaryDisease;
                // Update other properties...

                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Details), new { model.PatientInfoID });
            }

            return View(model);
        }

        // GET: FamilyHistory/Details/1
        public async Task<IActionResult> Details(int? PatientInfoID)
        {
            if (PatientInfoID == null || _dbContext.FamilyHistory == null)
            {
                return NotFound();
            }
            PatientInfoID = ViewBag.PatientInfoID;
            var familyHistory = await _dbContext.FamilyHistory
                .FirstOrDefaultAsync(m => m.PatientInfoID == PatientInfoID);
            if (familyHistory == null)
            {
                return RedirectToAction(nameof(Create), new { PatientInfoID });
            }

            return View(familyHistory);
        }
        //public IActionResult Details(int FamilyHistoryID)
        //{
        //    var model = _dbContext.FamilyHistory.Find(FamilyHistoryID);
        //    if (model == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(model);
        //}

        // GET: FamilyHistory/Delete/1
        //[Authorize(Roles = "Admin")]
        public IActionResult Delete(int FamilyHistoryID)
        {
            var model = _dbContext.FamilyHistory.Find(FamilyHistoryID);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: FamilyHistory/Delete/1
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int FamilyHistoryID)
        {
            var existingFamilyHistory = _dbContext.FamilyHistory.Find(FamilyHistoryID);
            if (existingFamilyHistory == null)
            {
                return NotFound();
            }

            _dbContext.FamilyHistory.Remove(existingFamilyHistory);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "FamilyHistory");
        }
        //    public IActionResult Index()
        //    {
        //        return View();
        //    }
        //}
    }
}
