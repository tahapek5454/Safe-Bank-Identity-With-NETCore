using Microsoft.AspNetCore.Mvc;
using SafeBankIdentity.BusinessLayer.Abstract;
using SafeBankIdentity.PresentationLayer.Models;

namespace SafeBankIdentity.PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserLoginService _userLoginService;

        public LoginController(IUserLoginService userLoginService)
        {
            _userLoginService = userLoginService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            bool result = await _userLoginService.LoginAsync(loginViewModel.appUserLoginDTO);

            if (!result)
                return View();

            return RedirectToAction("Index", "MyProfile");
        }
    }
}
