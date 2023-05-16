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
        private readonly IMailService _mailService;

		public UserRegisterManager(UserManager<AppUser> userManager, IMailService mailService)
		{
			_userManager = userManager;
			_mailService = mailService;
		}

		public async Task<IdentityResult> RegisterAsync(AppUserRegisterDto appUserRegisterDto)
        {
            Random random= new Random();
            int confirmCode = random.Next(100000, 1000000);

			AppUser appUser = new AppUser()
            {
                UserName = appUserRegisterDto.UserName,
                Name = appUserRegisterDto.Name,
                Email = appUserRegisterDto.Email,
                Surname = appUserRegisterDto.Surname,
                ConfirmCode = confirmCode
			};

            IdentityResult identityResult = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);

            if (identityResult.Succeeded)
                await _mailService.SendConfirimCodeAsync(appUserRegisterDto, confirmCode);

            return identityResult;
        }
    }
}
