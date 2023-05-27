using Microsoft.AspNetCore.Mvc;

namespace SafeBankIdentity.PresentationLayer.ViewComponents.CustomerComponent
{
    public class _CustomerLayoutFooterPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
