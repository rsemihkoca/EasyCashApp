using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Customer;

public class _NavbarPartial : ViewComponent
{
     public IViewComponentResult Invoke()
     { 
          return View();
     }
    
}