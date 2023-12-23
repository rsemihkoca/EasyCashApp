using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers;

[Route("[controller]")]
public class ConfirmMailController: Controller
{

    private readonly UserManager<AppUser> _userManager;
    
    public ConfirmMailController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    
    
    [HttpGet]
    public IActionResult Index()
    {
        var value = TempData["Mail"];
        ViewBag.v = value;
        //  confirmMailViewModel.Mail = value.ToString();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(ConfirmMailViewModel request)
    {
        var user = await _userManager.FindByEmailAsync(request.Mail);
        if (user.ConfirmCode == request.ConfirmCode)
        {
            user.EmailConfirmed = true;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Login");
        }

        return View();
    }
}