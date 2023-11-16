using healthApp.Areas.Identity.Data;
using healthApp.Models.Nutrition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace healthApp.Controllers.Nutrition
{
	public class AntropometryController : Controller
	{
		private readonly ApplicationDbContext _dbContext;

		public AntropometryController(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IActionResult Index()
		{
			return View( _dbContext.Antropometry);
		}
		public async Task<IActionResult> Details(int PatientInfoID)
		{
			//if (PatientInfoID == null || _dbContext.Antropometry == null)
			//{
			//	return NotFound();
			//}
			ViewBag.PatientInfoID = PatientInfoID;
			var antro
				= await _dbContext.Antropometry
				.FirstOrDefaultAsync(m => m.PatientInfoID == PatientInfoID);
			if (antro == null)
			{
				return RedirectToAction(nameof(Create), new { PatientInfoID });
			}

			return View(antro);
		}
		public IActionResult Create(int PatientInfoID)
		{
			ViewBag.PatientInfoID = PatientInfoID;
			
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(int PatientInfoID, [Bind("anthroID,height,currentWeight,bmi,usualWeight,waistCircumference,hipCircumference,armCircumference,calfCircumference,tricepSkinFold,subscapularSkinFold,PatientInfoID")] Anthropometry anthropometry)
		{
			if (ModelState.IsValid)
			{
				ViewBag.PatientInfoID = PatientInfoID;
				anthropometry.PatientInfoID = PatientInfoID;

				_dbContext.Add(anthropometry);
				await _dbContext.SaveChangesAsync();

			}
			return RedirectToAction(nameof(Details), new { PatientInfoID });
		
		}
		public async Task<IActionResult> Edit(int? anthroID)
		{
			if (anthroID == null || _dbContext.Antropometry == null)
			{
				return NotFound();
			}


			var antro = await _dbContext.Antropometry.FirstOrDefaultAsync(p => p.anthroID == anthroID);
			if (antro == null)
			{
				return NotFound();
			}
			ViewBag.PatientInfoID = antro.PatientInfoID;

			return View(antro);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int anthroID, [Bind("anthroID,height,currentWeight,bmi,usualWeight,waistCircumference,hipCircumference,armCircumference,calfCircumference,tricepSkinFold,subscapularSkinFold,PatientInfoID")] Anthropometry anthropometry)
		{
			if (anthroID != anthropometry.anthroID)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_dbContext.Update(anthropometry);
					await _dbContext.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!AntroExists(anthropometry.anthroID))
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
			ViewBag.PatientInfoID = anthropometry.PatientInfoID;
			ViewData["PatientInfoID"] = anthropometry.PatientInfoID;
			return View(anthropometry);
		}
		public async Task<IActionResult> Delete(int anthroID)
		{
			if (anthroID == null || _dbContext.Antropometry == null)
			{
				return NotFound();
			}

			var anthropometry = await _dbContext.Antropometry
				.Include(s => s.PatientInfo)
				.FirstOrDefaultAsync(m => m.anthroID == anthroID);
			if (anthropometry == null)
			{
				return NotFound();
			}

			return View(anthropometry);
		}
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int anthroID)
		{
			if (_dbContext.Antropometry == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Anthropometry'  is null.");
			}
			var anthropometry = await _dbContext.Antropometry.FindAsync(anthroID);
			if (anthropometry != null)
			{
				_dbContext.Antropometry.Remove(anthropometry);
			}

			await _dbContext.SaveChangesAsync();
			return RedirectToAction(nameof(Details));
		}
		private bool AntroExists(int anthroID)
		{
			return (_dbContext.Antropometry?.Any(e => e.anthroID == anthroID)).GetValueOrDefault();
		}
	}
}
