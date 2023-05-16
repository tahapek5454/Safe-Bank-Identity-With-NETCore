using Microsoft.Extensions.Configuration;
using SafeBankIdentity.BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SafeBankIdentity.DtoLayer.Dtos.AppUserDtos;

namespace SafeBankIdentity.BusinessLayer.Concrete
{
	public class MailManager : IMailService
	{
		private readonly IConfiguration _configuration;

		public MailManager(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task SendConfirimCodeAsync(AppUserRegisterDto appUserRegisterDto, int confirimCode)
		{
			string mail = $"Merhabalar <strong>{appUserRegisterDto.Name} {appUserRegisterDto.Surname} </strong>. <br> " +
				$"<strong> Safe Bank </strong>' a yapmış olduğunuz kayıt işlemi için onay kodunuz : <strong> {confirimCode} </strong> <br>" +
				$"Sizlere iyi gunler dileriz. <br>" +
				$"<strong> SafeBank - created by Taha Pek </strong>" +
				$"<strong> Egitim Amacli Yapilmis Bir Deneme Projesidir. İtibar  Etmeyiniz. </strong>";

			await SendMessageAsync(appUserRegisterDto.Email, "Kayıt Onay Kodu", mail);


		}

		public async Task SendMessageAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
		{
			MailMessage mail = new MailMessage();
			// olusturulan objede html var mı
			mail.IsBodyHtml = isBodyHtml;
			// kime gidecegi belirtilmis
			foreach (var to in tos)
			{
				mail.To.Add(to);

			}
			// subject ve bodylerini yazdik
			mail.Subject = subject;
			mail.Body = body;

			// kimin gonderecegini belirtelim
			mail.From = new MailAddress(_configuration["EMailService:UserName"], "SafeBank", System.Text.Encoding.UTF8);

			// GONDERME ISLEMI
			SmtpClient smtp = new SmtpClient();
			smtp.Credentials = new NetworkCredential(_configuration["EMailService:UserName"], _configuration["EMailService:ApplicationPassword"]);
			smtp.Port = Int32.Parse(_configuration["EMailService:Port"]);
			smtp.EnableSsl = true;
			smtp.Host = _configuration["EMailService:Host"];
			await smtp.SendMailAsync(mail);

		}

		public async Task SendMessageAsync(string to, string subject, string body, bool isBodyHtml = true)
		{
			await SendMessageAsync(new string[] { to }, subject, body, isBodyHtml);
		}

	}
}
