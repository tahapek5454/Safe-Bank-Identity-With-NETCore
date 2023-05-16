﻿using Microsoft.AspNetCore.Identity;
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

        public async Task<IdentityResult> RegisterAsync(AppUserRegisterDto appUserRegisterDto)
        {
            Random random= new Random();
            AppUser appUser = new AppUser()
            {
                UserName = appUserRegisterDto.UserName,
                Name = appUserRegisterDto.Name,
                Email = appUserRegisterDto.Email,
                Surname = appUserRegisterDto.Surname,
                ConfirmCode = random.Next(100000, 1000000)
            };

            IdentityResult identityResult = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);

            return identityResult;
        }
    }
}
