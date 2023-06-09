using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SafeBankIdentity.BusinessLayer.Abstract;
using SafeBankIdentity.DtoLayer.Dtos.AppUserDtos;
using SafeBankIdentity.EntityLayer.Concrete;
using SafeBankIdentity.PresentationLayer.Filters;

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
            IdentityResult result = null;

            if (ModelState.IsValid)
            {
                result = await _customUserService.EditUserAsync(appUserEditDto, User.Identity.Name);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Login");
            }

            ValidationModelStateFilter.GetErrors(ModelState, result?.Errors);

            return View();
        }
    }
}
