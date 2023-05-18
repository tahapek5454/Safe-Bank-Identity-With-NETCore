using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBankIdentity.DtoLayer.Dtos.AppUserDtos
{
    public class AppUserConfirmMailDTO
    {
        public int? ConfirmCode { get; set; }
        public string? Email { get; set; }
    }
}
