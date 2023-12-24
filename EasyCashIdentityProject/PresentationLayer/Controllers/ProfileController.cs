using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class ProfileController : Controller
    {
        // GET: ProfileController
        public IActionResult Index()
        {
            return View();
        }

    }
}
