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
    public class UserLoginManager : IUserLoginService
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;


        public UserLoginManager(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> LoginAsync(AppUserLoginDTO appUserLoginDTO)
        {
            AppUser user = await _userManager.FindByNameAsync(appUserLoginDTO.UserNameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(appUserLoginDTO.UserNameOrEmail);

            SignInResult result = await _signInManager.PasswordSignInAsync(
                    user: user,
                    password: appUserLoginDTO.Password,
                    isPersistent: false,
                    lockoutOnFailure: true
                );
            // Not: isPersistent -> google da cookie sakla ve kisiyi hatirla
            //      lockOutOnFailıre -> Birden fazla yanlis giriste kullaniciyi kitle

            return result.Succeeded;
        }
    }
}
