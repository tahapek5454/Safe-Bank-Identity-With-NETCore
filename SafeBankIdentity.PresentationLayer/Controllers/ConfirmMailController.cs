using Microsoft.AspNetCore.Mvc;
using SafeBankIdentity.BusinessLayer.Abstract;
using SafeBankIdentity.DtoLayer.Dtos.AppUserDtos;
using SafeBankIdentity.PresentationLayer.Models;

namespace SafeBankIdentity.PresentationLayer.Controllers
{
	public class ConfirmMailController : Controller
	{

		private readonly IUserRegisterService _userRegisterService;

        public ConfirmMailController(IUserRegisterService userRegisterService)
        {
            _userRegisterService = userRegisterService;
        }

        [HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(ConfirmMailViewModel confirmMailViewModel)
		{
			AppUserConfirmMailDTO appUserConfirmMailDTO = new AppUserConfirmMailDTO()
			{
				Email = TempData["Email"]?.ToString(),
				ConfirmCode= confirmMailViewModel.ConfirmCode,
			};

			bool isSuccess = await _userRegisterService.ConfirmMailAsync(appUserConfirmMailDTO);

			if (isSuccess)
				return RedirectToAction("Index", "Login");

			return View();
		}
	}
}
