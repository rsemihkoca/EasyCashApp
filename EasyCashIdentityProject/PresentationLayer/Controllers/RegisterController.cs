using DtoLayer.Dtos.AppUserDtos;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace PresentationLayer.Controllers;

[Route("[controller]")]
public class RegisterController : Controller
{
    private readonly ILogger<RegisterController> _logger;
    private readonly UserManager<AppUser> _userManager;

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
            var random = new Random();
            var code = random.Next(100000, 999999);
            var user = new AppUser
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
                var senderEmail = Environment.GetEnvironmentVariable("EMAIL_ADDRESS");
                var senderPassword = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");
                var email = new MimeMessage();

                email.From.Add(new MailboxAddress("EasyCashApp", senderEmail));
                email.To.Add(new MailboxAddress($"{user.Name} {user.Surname}", user.Email));

                email.Subject = "EasyCashApp";
                email.Body = new TextPart(TextFormat.Html)
                {
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

                TempData["Mail"] = request.Email;

                return RedirectToAction("Index", "ConfirmMail");
            }

            foreach (var error in result.Errors) ModelState.AddModelError("", error.Description);
        }

        return View();
    }
}