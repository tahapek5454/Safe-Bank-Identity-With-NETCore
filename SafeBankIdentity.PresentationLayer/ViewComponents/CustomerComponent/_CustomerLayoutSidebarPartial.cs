using Microsoft.AspNetCore.Mvc;

namespace SafeBankIdentity.PresentationLayer.ViewComponents.CustomerComponent
{
	public class _CustomerLayoutSidebarPartial: ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
