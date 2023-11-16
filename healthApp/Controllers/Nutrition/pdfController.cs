using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using healthApp.Areas.Identity.Data; // Add the appropriate namespace for your DbContext
using healthApp.Models.Nutrition;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;
using iText.Layout.Properties;

public class PdfController : Controller
{
	private readonly ApplicationDbContext _context;

	public PdfController(ApplicationDbContext context)
	{
		_context = context;
	}

	//[HttpPost]
	//public IActionResult GenerateFoodExchangePdf()
	//{
	//       // Create a new PDF document
	//       PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument();

	//       // Add a page to the document
	//       PdfSharp.Pdf.PdfPage page = document.AddPage();
	//	XGraphics gfx = XGraphics.FromPdfPage(page);
	//	XFont font = new XFont("Arial", 12);

	//	// Get the HTML content of the view
	//	string htmlContent = GetViewHtml("FoodExchangeReport");

	//	// Draw the HTML content on the PDF page
	//	XRect layout = new XRect(40, 40, page.Width, page.Height);
	//	XTextFormatter tf = new XTextFormatter(gfx);
	//	tf.DrawString(htmlContent, font, XBrushes.Black, layout);

	//	// Create a MemoryStream to hold the PDF content
	//	MemoryStream ms = new MemoryStream();
	//	document.Save(ms, false);

	//	// Set the position in the stream where the PDF content starts
	//	ms.Position = 0;

	//	// Return the PDF as a FileResult
	//	return File(ms, "application/pdf", "FoodExchangeReport.pdf");
	//}

	//// Helper method to render a view to string
	//public string GetViewHtml(string viewName)
	//{
	//	var viewResult = this.ViewToString(viewName);
	//	return viewResult;
	//}

	//// Helper method to render a view to string
	//public string ViewToString(string viewName)
	//{
	//	var httpContext = new DefaultHttpContext { RequestServices = this.HttpContext.RequestServices };
	//	var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

	//	using (var sw = new StringWriter())
	//	{
	//		var viewEngineResult = _viewEngine.FindView(actionContext, viewName, false);
	//		var viewContext = new ViewContext(actionContext, viewEngineResult.View, ViewData, TempData, sw, new HtmlHelperOptions());

	//		viewEngineResult.View.RenderAsync(viewContext).GetAwaiter().GetResult();
	//		return sw.ToString();
	//	}
	//}

	public async Task<IActionResult> GenerateFoodExchangePdf()
	{
		try
		{
			var foodExchangeData = await _context.FoodExchange.ToListAsync();

			byte[] pdfBytes = await GenerateFoodExchangePdfDocument(foodExchangeData);

			return File(pdfBytes, "application/pdf", "FoodExchangeReport.pdf");
		}
		catch (Exception ex)
		{
			// Log the exception
			// Handle the exception (return an error view, for example)
			return StatusCode(500, $"An error occurred: {ex.Message}");
		}
	}

	private static async Task<byte[]> GenerateFoodExchangePdfDocument(List<FoodExchange> foodExchangeData)
	{
		byte[] pdfBytes;
		try
		{
			using (MemoryStream ms = new MemoryStream())
			{
				PdfWriter pdfWriter = new PdfWriter(ms);
				PdfDocument pdf = new PdfDocument(pdfWriter);
				Document document = new Document(pdf);

				Table table = new Table(8);

				// Define styles for table cells
				Style cellStyle = new Style()
					.SetTextAlignment(TextAlignment.CENTER)
					.SetPadding(5);

				// Adding column headers
				AddCell(table, "Diet Description", cellStyle);
				AddCell(table, "Breakfast", cellStyle);
				AddCell(table, "AM Snack", cellStyle);
				AddCell(table, "Lunch", cellStyle);
				AddCell(table, "PM Snack", cellStyle);
				AddCell(table, "Dinner/Supper", cellStyle);
				AddCell(table, "Total Items", cellStyle);
				AddCell(table, "Patient Info ID", cellStyle);

				// Adding data rows
				foreach (var item in foodExchangeData)
				{
					AddCell(table, item.DietDiscription ?? "N/A", cellStyle);
					AddCell(table, item.Breakfast ?? "N/A", cellStyle);
					AddCell(table, item.AMSnack ?? "N/A", cellStyle);
					AddCell(table, item.Lunch ?? "N/A", cellStyle);
					AddCell(table, item.PMSnack ?? "N/A", cellStyle);
					AddCell(table, item.DinnerSupper ?? "N/A", cellStyle);
					AddCell(table, item.TotalItems.ToString(), cellStyle);
					AddCell(table, item.PatientInfoID.ToString(), cellStyle);
				}

				document.Add(table);

				pdfBytes = ms.ToArray();
			}

			return pdfBytes;
		}
		catch (Exception ex)
		{
			// Log the exception details for debugging
			// Handle the exception (return an error view, for example)
			throw new Exception($"An error occurred while generating the PDF: {ex.Message}");
		}
	}

	// Helper method to add cell to the table with specified style
	private static void AddCell(Table table, string text, Style style)
	{
		Cell cell = new Cell().Add(new Paragraph(text)).AddStyle(style);
		table.AddCell(cell);
	}

}
