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
    public class CustomUserManager : ICustomUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public CustomUserManager(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task EditUserAsync(AppUserEditDto appUserEditDto, string userName)
        {
           AppUser user = await _userManager.FindByNameAsync(userName);
        }
        

        public async Task<AppUser> GetUserByUserNameAsync(string userName)
            => await _userManager.FindByNameAsync(userName);
    }
}
