using Microsoft.AspNetCore.Identity;
using SafeBankIdentity.BusinessLayer.Abstract;
using SafeBankIdentity.DtoLayer.Dtos.AppUserDtos;
using SafeBankIdentity.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBankIdentity.BusinessLayer.Concrete
{
    public class UserRegisterManager : IUserRegisterService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserRegisterManager(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> RegisterAsync(AppUserRegisterDto appUserRegisterDto)
        {
            AppUser appUser = new AppUser()
            {
                UserName = appUserRegisterDto.UserName,
                Name = appUserRegisterDto.Name,
                Email = appUserRegisterDto.Email,
                Surname = appUserRegisterDto.Surname,
            };

            IdentityResult identityResult = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);

            return identityResult.Succeeded;
        }
    }
}
