using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            return View();
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