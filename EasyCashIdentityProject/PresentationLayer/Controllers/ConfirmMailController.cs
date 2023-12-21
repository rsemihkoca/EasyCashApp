using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("[controller]")]
    public class ConfirmMailController : Controller
    {
        private readonly ILogger<ConfirmMailController> _logger;

        public ConfirmMailController(ILogger<ConfirmMailController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var value = TempData["Mail"];
            return View(value);
        }

        [HttpPost]
        public IActionResult Index(string code)
        {
            if (code == "123456")
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }
    }
}