using healthApp.Areas.Identity.Data;
using healthApp.Models.Nutrition;
//using iText.Html2pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using iText.Commons.Actions.Contexts;

namespace healthApp.Controllers.Nutrition
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;
        public ReportController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SGARisk()
        {
            var SGARiskList = await _dbcontext.SGA
                .Where(Q => Q.TotalScore <= 5).Include(sga => sga.PatientInfo)
                .ToListAsync();

            return View(SGARiskList);
        }
        public async Task<IActionResult> SGAPhysicalExamRisk()
        {
            var SGAWeightRiskList = await _dbcontext.SGA
                .Where(Q => Q.PhysicalExam == "Underweight").Include(sga => sga.PatientInfo)
                .ToListAsync();

            return View(SGAWeightRiskList);
        }
        public async Task<IActionResult> SGAPhysicalExamNOTRisk()
        {
            var SGAWeightNOTRiskList = await _dbcontext.SGA
                .Where(Q => Q.PhysicalExam == "Normal").Include(sga => sga.PatientInfo)
                .ToListAsync();

            return View(SGAWeightNOTRiskList);
        }
        public async Task<IActionResult> Screen1Risk()
        {
            var Screen1RiskList = await _dbcontext.Screening
                .Where(Q => Q.RiskScore <= 5).Include(screen => screen.PatientInfo)
                .ToListAsync();

            return View(Screen1RiskList);
        }
        public async Task<IActionResult> Screen1NOTRisk()
        {
            var Screen1NOTRiskList = await _dbcontext.Screening
                .Where(Q => Q.RiskScore > 5).Include(screen => screen.PatientInfo)
                .ToListAsync();

            return View(Screen1NOTRiskList);
        }
        public async Task<IActionResult> Screen2Risk()
        {
            var Screen2RiskList = await _dbcontext.Screening2
                .Where(Q => Q.RiskScore <= 5).Include(screen => screen.PatientInfo)
                .ToListAsync();

            return View(Screen2RiskList);
        }
        public async Task<IActionResult> Screen2NOTRisk()
        {
            var Screen2NOTRiskList = await _dbcontext.Screening2
                .Where(Q => Q.RiskScore > 5).Include(screen => screen.PatientInfo)
                .ToListAsync();

            return View(Screen2NOTRiskList);
        }
        public async Task<IActionResult> FoodExchangeReport()
        {
			// Fetching FoodExchanges along with PatientInfo
			var foodExchangesWithPatientInfo = _dbcontext.FoodExchange.Include(fe => fe.PatientInfo).ToList();


			return View(foodExchangesWithPatientInfo);
        }
        public async Task<IActionResult> GetUnassociatedPatients()
        {
            var unassociatedPatients = await _dbcontext.PatientInfos
                .Where(patient => !_dbcontext.FoodExchange.Any(fe => fe.PatientInfoID == patient.PatientInfoID))
                .ToListAsync();

            return View(unassociatedPatients);
        }

        public async Task<IActionResult> BioProteinRisk()
        {
            var report = await _dbcontext.Biochemicals
                .Where(Q => Q.totalProtein <= 7)
                .Include(bio => bio.PatientInfo)
                .ToListAsync();

            return View(report);
        }
        public async Task<IActionResult> BioBleedingRisk()
        {
            var report = await _dbcontext.Biochemicals
                .Where(Q => Q.bleedingTime <= 5).Include(bio => bio.PatientInfo)
                .ToListAsync();

            return View(report);
        }
        public async Task<IActionResult> AnthroBMIRisk()
        {
            var report = await _dbcontext.Antropometry
                .Where(Q => Q.bmi <= 25).Include(anth => anth.PatientInfo)
                .ToListAsync();

            return View(report);
        }
        public async Task<IActionResult> AnthroBMINOTRisk()
        {
            var report = await _dbcontext.Antropometry
                .Where(Q => Q.bmi > 25).Include(anth => anth.PatientInfo)
                .ToListAsync();

            return View(report);
        }

    }
}
