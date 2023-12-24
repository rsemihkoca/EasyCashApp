using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Customer;

public class _ScriptPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}