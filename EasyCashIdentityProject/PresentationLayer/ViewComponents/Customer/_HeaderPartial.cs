using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Customer;

public class _HeaderPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }   
}