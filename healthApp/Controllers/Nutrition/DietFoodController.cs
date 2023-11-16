using healthApp.Areas.Identity.Data;
using healthApp.Models.Nutrition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Drawing.Printing;
//using DinkToPdf.Contracts;
//using DinkToPdf;
using Microsoft.AspNetCore.Mvc.Razor;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout;

namespace healthApp.Controllers.Nutrition
{
    public class DietFoodController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;

        public DietFoodController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
       
       

//public async Task<IActionResult> DetailsToPdf(int? PatientInfoID)
//    {
//        if (PatientInfoID == null || _dbcontext.FoodExchange == null)
//        {
//            return NotFound();
//        }

//        var DietFood = await _dbcontext.FoodExchange
//            .Include(s => s.PatientInfo)
//            .FirstOrDefaultAsync(m => m.PatientInfoID == PatientInfoID);

//        if (DietFood == null)
//        {
//            return RedirectToAction(nameof(Create), new { PatientInfoID });
//        }

//        // Render the view to a string
//        var viewHtml = await this.RenderViewToStringAsync("Details", DietFood);

//        // Convert the HTML to PDF
//        var converter = new BasicConverter(new PdfTools());
//        var pdfBytes = converter.Convert(new HtmlToPdfDocument()
//        {
//            GlobalSettings = {
//            PaperSize = System.Drawing.Printing.PaperKind.A4,
//            Orientation = Orientation.Portrait
//        },
//            Objects = {
//            new ObjectSettings() {
//                PagesCount = true,
//                HtmlContent = viewHtml,
//            }
//        }
//        });

//        // Return the PDF as a file
//        return File(pdfBytes, "application/pdf", "Details.pdf");
//    }

//    // Helper method to render view to string
//    private async Task<string> RenderViewToStringAsync(string viewName, object model)
//    {
//        ViewData.Model = model;

//        using (var sw = new StringWriter())
//        {
//            var viewResult = RazorViewEngine.FindView(ControllerContext, viewName, false);

//            if (viewResult.View == null)
//            {
//                throw new ArgumentNullException($"{viewName} does not match any available view");
//            }

//            var viewContext = new ViewContext(
//                ControllerContext,
//                viewResult.View,
//                ViewData,
//                TempData,
//                sw,
//                new HtmlHelperOptions()
//            );

//            await viewResult.View.RenderAsync(viewContext);

//            return sw.ToString();
//        }
//    }


    public async Task<IActionResult> Index()
        {
            var dietFood = await _dbcontext.DietFood
                
                .ToListAsync();

            return View(dietFood);
        }

        public async Task<IActionResult> GeneratePdf(int? PatientInfoID)
        {
            if (PatientInfoID == null || _dbcontext.FoodExchange == null)
            {
                return NotFound();
            }

            var DietFood = await _dbcontext.FoodExchange
                .Include(s => s.PatientInfo)
                .FirstOrDefaultAsync(m => m.PatientInfoID == PatientInfoID);

            if (DietFood == null)
            {
                return RedirectToAction(nameof(Create), new { PatientInfoID });
            }

            // Create a MemoryStream to hold the PDF content
            using (MemoryStream stream = new MemoryStream())
            {
                // Create a PdfWriter instance
                using (PdfWriter writer = new PdfWriter(stream))
                {
                    // Create a PdfDocument instance
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        // Create a Document instance
                        Document document = new Document(pdf);

                        // Add content to the PDF
                        // For example, you can add the properties of DietFood
                        document.Add(new Paragraph($"Patient ID: {DietFood.PatientInfoID}"));
                        document.Add(new Paragraph($"Patient Name: {DietFood.PatientInfo.FirstName}"));
                        // Add other properties as needed

                        // You can also add content from your existing view
                        // For example, if your existing view is a Razor view, you can render it to the PDF
                        // using the ViewRenderer class (assuming you have it in your project)
                        // ViewRenderer viewRenderer = new ViewRenderer(ControllerContext);
                        // string viewHtml = viewRenderer.RenderViewToString("Details", DietFood);
                        // document.Add(new Paragraph(viewHtml));
                    }
                }

                // Set the position of the stream back to the beginning
                stream.Seek(0, SeekOrigin.Begin);

                // Return the PDF as a file download
                return File(stream.ToArray(), "application/pdf", "PatientDetails.pdf");
            }
        }



        public async Task<IActionResult> Details(int? PatientInfoID)
        {
            if (PatientInfoID == null || _dbcontext.FoodExchange == null)
            {
                return NotFound();
            }
            ViewBag.PatientInfoID = PatientInfoID;
            var DietFood = await _dbcontext.FoodExchange
                .Include(s => s.PatientInfo)
                .FirstOrDefaultAsync(m => m.PatientInfoID == PatientInfoID);
            if (DietFood == null)
            {
                return RedirectToAction(nameof(Create), new { PatientInfoID });
            }

            return View(DietFood);
        }

        // GET: DietFood/Create
        public IActionResult Create(int PatientInfoID)
        {
            ViewBag.PatientInfoID = PatientInfoID;

            return View();
        }
        // POST: DietFood/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int PatientInfoID, [Bind("FoodExchangeID,DietDiscription,Breakfast,AMSnack,Lunch,PMSnack,DinnerSupper,TotalItems,PatientInfoID")] FoodExchange DietFood)
        {
            if (ModelState.IsValid)
            {
                ViewBag.PatientInfoID = PatientInfoID;
                DietFood.PatientInfoID = PatientInfoID;
                _dbcontext.Add(DietFood);
                await _dbcontext.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { PatientInfoID });
            }
            return View(DietFood);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var DietFood = await _dbcontext.FoodExchange.FindAsync(id);
            if (DietFood == null)
            {
                return NotFound();
            }

            return View(DietFood);
        }
        // POST: DietFood/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodExchangeID,DietDiscription,Breakfast,AMSnack,Lunch,PMSnack,DinnerSupper,TotalItems,PatientInfoID")] FoodExchange DietFood)
        {
            if (id != DietFood.FoodExchangeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbcontext.Update(DietFood);
                    await _dbcontext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DietFoodExists(DietFood.FoodExchangeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { DietFood.PatientInfoID });
            }
            return View(DietFood);
        }
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var DietFood = await _dbcontext.FoodExchange
                .FirstOrDefaultAsync(m => m.FoodExchangeID == id);
            if (DietFood == null)
            {
                return NotFound();
            }

            return View(DietFood);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var DietFood = await _dbcontext.FoodExchange.FindAsync(id);
            _dbcontext.FoodExchange.Remove(DietFood);
            await _dbcontext.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { DietFood.PatientInfoID });
        }

        private bool DietFoodExists(int id)
        {
            return _dbcontext.FoodExchange.Any(e => e.FoodExchangeID == id);
        }
    }
}
