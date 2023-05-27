using Microsoft.AspNetCore.Mvc;

namespace SafeBankIdentity.PresentationLayer.ViewComponents.CustomerComponent
{
	public class _CustomerLayoutHeaderPartial: ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
