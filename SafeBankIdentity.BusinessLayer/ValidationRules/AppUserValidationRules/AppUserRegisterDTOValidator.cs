using FluentValidation;
using SafeBankIdentity.DtoLayer.Dtos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBankIdentity.BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterDTOValidator: AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterDTOValidator()
        {
            RuleFor(aur => aur.Name)
                .NotEmpty()
                .WithMessage("Lutfe Ad Alanini Doldurunuz")
                .MinimumLength(2)
                .WithMessage("Ad Alani Minumum 2 Karakter Olmalidir");

            RuleFor(aur => aur.Email)
                .NotEmpty()
                .WithMessage("Lutfen Email Alanini Doldurunuz")
                .EmailAddress()
                .WithMessage("Lutfen Email Formatinda Giris Yapiniz.");

            RuleFor(aur => aur.Password)
                .NotEmpty()
                .WithMessage("Lutfen Sifre Alanini Doldurunuz");

            RuleFor(aur => aur.ConfirmPassword)
                .NotEmpty()
                .WithMessage("Lütfen Sifre Onay Alanini Doldurunuz")
                .Equal(aur => aur.Password)
                .WithMessage("Sifreniz Ve Sifre Onayiniz Eslesmiyor");

            RuleFor(aur => aur.Surname)
                .NotEmpty()
                .WithMessage("Lutfe Soyad Alanini Doldurunuz")
                .MinimumLength(2)
                .WithMessage("Soyad Alani Minumum 2 Karakter Olmalidir");

            RuleFor(aur => aur.UserName)
                .NotEmpty()
                .WithMessage("Lutfe Kullanici Adi Alanini Doldurunuz")
                .MinimumLength(2)
                .WithMessage("Kullanici Adi Alani Minumum 2 Karakter Olmalidir");

        }
    }
}
