using SafeBankIdentity.DtoLayer.Dtos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBankIdentity.BusinessLayer.Abstract
{
    public interface IUserRegisterService
    {
        Task<bool> RegisterAsync(AppUserRegisterDto appUserRegisterDto);
    }
}
