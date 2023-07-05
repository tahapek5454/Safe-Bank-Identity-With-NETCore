using Microsoft.AspNetCore.Mvc;

namespace SafeBankIdentity.PresentationLayer.Controllers
{
    public class MyLastProcessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
