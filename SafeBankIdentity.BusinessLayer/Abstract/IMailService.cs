using SafeBankIdentity.DtoLayer.Dtos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBankIdentity.BusinessLayer.Abstract
{
	public interface IMailService
	{
		Task SendMessageAsync(string to, string subject, string body, bool isBodyHtml = true);
		Task SendMessageAsync(string[] tos, string subject, string body, bool isBodyHtml = true);
		Task SendConfirimCodeAsync(AppUserRegisterDto appUserRegisterDto, int confirimCode);

	}
}
