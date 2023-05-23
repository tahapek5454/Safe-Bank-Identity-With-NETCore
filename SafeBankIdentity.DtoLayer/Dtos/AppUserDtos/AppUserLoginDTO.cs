using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBankIdentity.DtoLayer.Dtos.AppUserDtos
{
    public class AppUserLoginDTO
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
