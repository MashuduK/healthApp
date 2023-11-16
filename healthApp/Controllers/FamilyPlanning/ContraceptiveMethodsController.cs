using Microsoft.AspNetCore.Mvc;

namespace healthApp.Controllers.FamilyPlanning
{
    public class ContraceptiveMethodsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
