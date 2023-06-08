using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SafeBankIdentity.BusinessLayer.Abstract;
using SafeBankIdentity.DtoLayer.Dtos.AppUserDtos;
using SafeBankIdentity.EntityLayer.Concrete;

namespace SafeBankIdentity.PresentationLayer.Controllers
{
    [Authorize]
    public class MyAccountsController : Controller
    {
        private readonly ICustomUserService _customUserService;

        public MyAccountsController(ICustomUserService customUserService)
        {
            _customUserService = customUserService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            AppUser user = await _customUserService.GetUserByUserNameAsync(User.Identity.Name);

            AppUserEditDto appUserEditDto = new AppUserEditDto()
            {
                City= user.City,
                District= user.District,
                Email = user.Email,
                ImageUrl= user.ImageUrl,
                Name= user.Name,
                PhoneNumber= user.PhoneNumber,
                Surname= user.Surname,
            };
            
            return View(appUserEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserEditDto appUserEditDto)
        {
            bool succees = await _customUserService.EditUserAsync(appUserEditDto, User.Identity.Name);

            if (succees)
                return RedirectToAction("Index", "Login");

            return View();
        }
    }
}
