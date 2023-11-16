using healthApp.Models.Nutrition;
using Microsoft.AspNetCore.Mvc;

namespace healthApp.Controllers.Nutrition
{
    public class NutritionController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult PatientInfoForm()
        {
            return View();
        }

        public IActionResult FamilyHistoryForm()
        {
            // Create an instance of the model to pass to the view
            var model = new FamilyH();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(FamilyH model)
        {
            // Process the form submission here (e.g., save the data)
            // The model will contain the user's choices for each variable
            // Redirect or return a view as needed

            return View(model);
        }
    }
}
