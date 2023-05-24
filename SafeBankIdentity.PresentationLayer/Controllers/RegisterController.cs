using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SafeBankIdentity.BusinessLayer.Abstract;
using SafeBankIdentity.DataAccessLayer.Concrete;
using SafeBankIdentity.DtoLayer.Dtos.AppUserDtos;
using SafeBankIdentity.EntityLayer.Concrete;
using SafeBankIdentity.PresentationLayer.Filters;

namespace SafeBankIdentity.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {

        private readonly IUserRegisterService _userRegisterService;

        public RegisterController(IUserRegisterService userRegisterService)
        {
            _userRegisterService = userRegisterService;
        }

		[HttpGet]
		public IActionResult Index()
		{
            return View();
		}

		[HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            var result =await _userRegisterService.RegisterAsync(appUserRegisterDto);

            if(result.Succeeded && ModelState.IsValid)
            {
                TempData["Email"] = appUserRegisterDto.Email;
                return RedirectToAction("Index", "ConfirmMail");
            }
                
            ValidationModelStateFilter.GetErrors(ModelState, result.Errors);
			return View();
        }

	}
 
}
