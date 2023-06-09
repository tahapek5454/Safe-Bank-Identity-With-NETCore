using FluentValidation;
using SafeBankIdentity.DtoLayer.Dtos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBankIdentity.BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserEditDTOValidator: AbstractValidator<AppUserEditDto>
    {
        public AppUserEditDTOValidator()
        {
            RuleFor(ue => ue.City)
                .NotEmpty()
                .WithMessage("Şehir İsmi Girilmelidir.")
                .MinimumLength(2)
                .WithMessage("Şehir İsmi Minumum 2 Karakter Olmalıdır");

            RuleFor(ue => ue.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Mail Boş Geçilemez.")
                .EmailAddress()
                .WithMessage("Lütfen Doğru Bir Mail Formatı Giriniz.");

            RuleFor(ue => ue.Surname)
                .NotNull()
                .NotEmpty()
                .WithMessage("Lütfen Soy İsminizi Giriniz.")
                .MinimumLength(2)
                .WithMessage("Soy İsmi Minumum 2 Karakter Olmalıdır");

            RuleFor(ue => ue.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Lütfen İsminizi Giriniz.")
                .MinimumLength(2)
                .WithMessage("İsmi Minumum 2 Karakter Olmalıdır");

            RuleFor(ue => ue.Password)
                .Equal(ue => ue.RePassword)
                .WithMessage("Parola, Parola Tekrar İle Uymalı.")
                .Must((model, Password) => PasswordRule(Password, model.RePassword))
                .WithMessage($"Parola Minumum 9 Karakter Olamalıdır.\n" +
                $"Parola En Az Bir Büyük Bir Küçük Harf İçermelidir.\n" +
                $"Parola En Az Bir Rakam İçermelidir.\n" +
                $"Parola En Az Bir Özel Karakter İçermelidir.");

        }

        private  bool PasswordRule(string password, string rePassword)
        {
            if (password == null && rePassword == null)
                return true;

            if (password.Length<9)
                return false;

            int validConditions = 0;
            foreach (char c in password)
            {
                if (c >= 'a' && c <= 'z')
                {
                    validConditions++;
                    break;
                }
            }
            foreach (char c in password)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions == 0) return false;
            foreach (char c in password)
            {
                if (c >= '0' && c <= '9')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions == 1) return false;
            if (validConditions == 2)
            {
                char[] special = { '@', '#', '$', '%', '^', '&', '+', '=', '*' }; // or whatever    
                if (password.IndexOfAny(special) == -1) return false;
            }
            return true;

        }
    }
}
