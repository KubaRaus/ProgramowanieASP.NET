using Laboratorium1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium1.Controllers;

public class ContactController : Controller
{
    // rozwiazanie tymczasowe
    static private Dictionary<int, ContactModel> _contacts = new Dictionary<int, ContactModel>()
    {
        {1, new() {Id = 1, Email = "st@mail.ecu.pl", FirstName = "Jan", LastName = "Elo", BirthDate = new DateOnly(1980, 01, 01), PhoneNumber = "123-456-789"}},
        
    };
    private static int currentId = 0;
    // Lista kontaktów
    public IActionResult Index()
    {
        return View(_contacts);
    }
    
    // formularz dodawania kontaktu
    public IActionResult Add()
    {
        return View();
    }
    
    // odebranie danych z formularza i zapisanie w kontaktach
    [HttpPost]
    public ActionResult Add(ContactModel model)
    {
        if (ModelState.IsValid)
        {
            return View(model);
        }
        model.Id = ++currentId;
        _contacts.Add(model.Id, model);
        return View("Index", _contacts);
        
    }
    public ActionResult Delete(int id)
    {
        _contacts.Remove(id);
        return View("Index", _contacts);
    }
    public ActionResult Details(int id)
    {
        return View(_contacts[id]);
    }
}