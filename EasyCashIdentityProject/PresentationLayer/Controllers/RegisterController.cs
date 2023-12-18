using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DtoLayer.Dtos.AppUserDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PresentationLayer.Controllers
{
    // [Route("[controller]")]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RegisterController> _logger;

        public RegisterController(UserManager<AppUser> userManager, ILogger<RegisterController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterRequest request)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = request.Username,
                    Email = request.Email,
                    Name = request.Name,
                    Surname = request.Surname,
                };

                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    return RedirectToAction("Index", "ConfirmMail");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View();
        }
    }
}