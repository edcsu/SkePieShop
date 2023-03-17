using Microsoft.AspNetCore.Mvc;

namespace SkePieShop.Controllers;

public class Contact : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}