using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers;

public class AccountsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}