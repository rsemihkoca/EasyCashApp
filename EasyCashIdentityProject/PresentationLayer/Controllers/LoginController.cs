using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers;

public class LoginController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;

    public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet]
    public ActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(LoginViewModel request)
    {
        var result =
            await _signInManager.PasswordSignInAsync(request.Username, request.Password, request.RememberMe, true);
        if (result.Succeeded)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user.EmailConfirmed)
            {
                return RedirectToAction("Index", "Profile");
            }
            else
            {
                TempData["Mail"] = user.Email;
                return RedirectToAction("Index", "ConfirmMail");
            }
        }

        return View();
    }
}