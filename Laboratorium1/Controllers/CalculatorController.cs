using Laboratorium1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium1.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: con
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Result(Operator? op, double? a, double? b)
        {
            if (a is null || b is null)
            {
                ViewBag.ErrorMessage = "Niepoprawny format liczby w parametrze a lub b";
                return View("CustomError");
            }

            if (op is null)
            {
                ViewBag.ErrorMessage = "niedozwolone działanie";
                return View("CustomError");
            }

            ViewBag.a = a;
            ViewBag.b = b;
            switch (op)
            {
                case Operator.Add:
                    ViewBag.result = a + b;
                    ViewBag.op = "+";
                    break;
                case Operator.Sub:
                    ViewBag.result = a - b;
                    ViewBag.op = "-";
                    break;
                case Operator.Mul:
                    ViewBag.result = a * b;
                    ViewBag.op = "*";
                    break;
                case Operator.Div:
                    ViewBag.result = a / b;
                    ViewBag.op = ":";
                    break;
            }
            

            return View();
        }
        public IActionResult Form()
        {
            return View();
        }

        public enum Operator
        {
            Add,
            Sub,
            Mul,
            Div
        }
        [HttpPost]
        public IActionResult Result([FromForm] Calculator model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }
            return View(model);
        }
        
        

    }
    

}

