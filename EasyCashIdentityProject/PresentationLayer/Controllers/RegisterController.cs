using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DtoLayer.Dtos.AppUserDtos;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using MailKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace PresentationLayer.Controllers
{
    [Route("[controller]")]
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
                Random random = new Random();
                String code = random.Next(100000, 999999).ToString();
                AppUser user = new AppUser
                {
                    UserName = request.Username,
                    Email = request.Email,
                    Name = request.Name,
                    Surname = request.Surname,
                    City = "İstanbul",
                    District = "Kadıköy",
                    ImageUrl = "default.png",
                    ConfirmCode = code
                };

                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {

                    string? senderEmail = Environment.GetEnvironmentVariable("EMAIL_ADDRESS");
                    string? senderPassword = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");
                    var email = new MimeMessage();

                    email.From.Add(new MailboxAddress("EasyCashApp", senderEmail));
                    email.To.Add(new MailboxAddress($"{user.Name} {user.Surname}", user.Email));

                    email.Subject = "EasyCashApp";
                    email.Body = new TextPart(MimeKit.Text.TextFormat.Html) {
                        Text = $"<h1>Email Verification</h1><br><p>Verification code: {code}</p>"
                    };

                    using (var smtp = new SmtpClient())
                    {
                        smtp.Connect("smtp.gmail.com", 587, false);

                        smtp.Authenticate(senderEmail, senderPassword);

                        smtp.Send(email);
                        smtp.Disconnect(true);
                    }


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