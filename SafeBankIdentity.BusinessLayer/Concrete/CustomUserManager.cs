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

        public async Task<bool> EditUserAsync(AppUserEditDto appUserEditDto, string userName)
        {
           AppUser user = await _userManager.FindByNameAsync(userName);

            if (user == null)
                throw new Exception("Kullanıcı Bulunamadı.");


            if(appUserEditDto.Password != null)
                if (!appUserEditDto.Password.Equals(appUserEditDto.RePassword))
                    throw new Exception("Şifreler Uyuşmadı Tekrar Deneyiniz.");
                else
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserEditDto.Password);


            user.PhoneNumber = appUserEditDto.PhoneNumber;
            user.Surname = appUserEditDto.Surname;
            user.City = appUserEditDto.City;
            user.District = appUserEditDto.District;
            user.Name = appUserEditDto.Name;
            user.Email = appUserEditDto.Email;

            IdentityResult result = await _userManager.UpdateAsync(user);

            return result.Succeeded;

        }


        public async Task<AppUser> GetUserByUserNameAsync(string userName)
            => await _userManager.FindByNameAsync(userName);
    }
}
