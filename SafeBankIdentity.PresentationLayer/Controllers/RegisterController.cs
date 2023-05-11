using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SafeBankIdentity.BusinessLayer.Abstract;
using SafeBankIdentity.DtoLayer.Dtos.AppUserDtos;
using SafeBankIdentity.EntityLayer.Concrete;

namespace SafeBankIdentity.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {

        private readonly IUserRegisterService _userRegisterService;

        public RegisterController(IUserRegisterService userRegisterService)
        {
            _userRegisterService = userRegisterService;
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            bool result =await _userRegisterService.RegisterAsync(appUserRegisterDto);

            if(result)
                return RedirectToAction("Index", "ConfirmMail");

            return View();
        }
    }
}
