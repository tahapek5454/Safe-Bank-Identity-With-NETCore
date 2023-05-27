using Microsoft.AspNetCore.Mvc;

namespace SafeBankIdentity.PresentationLayer.ViewComponents.CustomerComponent
{
    public class _CustomerLayoutNavbarPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
