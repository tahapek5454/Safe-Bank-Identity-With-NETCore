using Microsoft.AspNetCore.Mvc;

namespace SafeBankIdentity.PresentationLayer.ViewComponents.CustomerComponent
{
    public class _CustomerLayoutScriptPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
