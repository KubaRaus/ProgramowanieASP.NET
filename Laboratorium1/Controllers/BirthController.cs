using Microsoft.AspNetCore.Mvc;
using Laboratorium1.Models;

namespace Laboratorium1.Controllers
{
    public class BirthController : Controller
    {
        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Result(Birth model)
        {
            if (!model.IsValid())
            {
                ViewBag.ErrorMessage = "Niepoprawne dane.";
                return View("CustomError");
            }

            int age = model.CalculateAge();
            ViewBag.Message = $"Cześć {model.Name}, masz {age} lat(a).";
            return View();
        }
    }
}