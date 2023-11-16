using healthApp.Areas.Identity.Data;
using healthApp.Models.Nutrition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace healthApp.Controllers.Nutrition
{
    public class SocialHistoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public SocialHistoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       
        [Authorize(Roles = "Admin")]
        public IActionResult Index(int? patientInfoID)
        {
            // Get a single social history record associated with the specific PatientInfoID
            SocialH socialHistoryRecord = _dbContext.SocialHistory
                .FirstOrDefault(s => s.PatientInfoID == patientInfoID);

            if (socialHistoryRecord == null)
            {
                // Handle the case where no record is found
                return NotFound();
            }

            ViewBag.PatientInfoID = patientInfoID; // Pass the PatientInfoID to the view

            return View(socialHistoryRecord);
        }


        // GET: SocialHistory/Create
        public IActionResult Create(int? PatientInfoID)
        {
            var patientInfo = _dbContext.PatientInfos.FirstOrDefault(p => p.PatientInfoID == PatientInfoID);
            if (patientInfo == null)
            {
                return NotFound();
            }

            var socialHistory = new SocialH
            {
                PatientInfo = patientInfo
            };
            return View(socialHistory);
        }

        // POST: SocialHistory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SocialH model, int PatientInfoID)
        {
            if (ModelState.IsValid)
            {
                var patientInfo = _dbContext.PatientInfos.FirstOrDefault(p => p.PatientInfoID == PatientInfoID);
                if (patientInfo == null)
                {
                    return NotFound();
                }

                model.PatientInfo = patientInfo;
                _dbContext.SocialHistory.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "SocialHistory");
            }

            return View(model);
        }

        // GET: SocialHistory/Edit/1
        public IActionResult Edit(int SocialHistoryID)
        {
            var model = _dbContext.SocialHistory.Find(SocialHistoryID);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: SocialHistory/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int SocialHistoryID, SocialH model)
        {
            if (ModelState.IsValid)
            {
                var existingSocialHistory = _dbContext.SocialHistory.Find(SocialHistoryID);
                if (existingSocialHistory == null)
                {
                    return NotFound();
                }

                existingSocialHistory.SmokingFrequency = model.SmokingFrequency;
                existingSocialHistory.AlcoholType = model.AlcoholType;
                existingSocialHistory.AlcoholFrequency = model.AlcoholFrequency;
                existingSocialHistory.AlcoholQuantity = model.AlcoholQuantity;
                existingSocialHistory.PhysActivity = model.PhysActivity;

                _dbContext.SaveChanges();

                return RedirectToAction("Index", "SocialHistory");
            }

            return View(model);
        }
        public IActionResult Details(int patientInfoID)
        {
            // Get social history records associated with the specific PatientInfoID
            List<SocialH> socialHistoryRecord = _dbContext.SocialHistory
                .Where(s => s.PatientInfoID == patientInfoID)
                .ToList();

            ViewBag.PatientInfoID = patientInfoID; // Pass the PatientInfoID to the view

            return View(socialHistoryRecord);
        }

        //// GET: SocialHistory/Details/1
        //public IActionResult Details(int SocialHistoryID)
        //{
        //    var model = _dbContext.SocialHistory.Find(SocialHistoryID);
        //    if (model == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(model);
        //}

        // GET: SocialHistory/Delete/1
        public IActionResult Delete(int SocialHistoryID)
        {
            var model = _dbContext.SocialHistory.Find(SocialHistoryID);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: SocialHistory/Delete/1
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int SocialHistoryID)
        {
            var existingSocialHistory = _dbContext.SocialHistory.Find(SocialHistoryID);
            if (existingSocialHistory == null)
            {
                return NotFound();
            }

            _dbContext.SocialHistory.Remove(existingSocialHistory);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "SocialHistory");
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
