using SafeBankIdentity.DtoLayer.Dtos.AppUserDtos;
using SafeBankIdentity.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBankIdentity.BusinessLayer.Abstract
{
    public interface ICustomUserService
    {
        Task<bool> EditUserAsync(AppUserEditDto appUserEditDto, string userName);
        Task<AppUser> GetUserByUserNameAsync(string userName);
    }
}
