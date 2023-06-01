using Microsoft.AspNetCore.Mvc;

namespace SafeBankIdentity.PresentationLayer.Controllers
{
    public class CustomerLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
