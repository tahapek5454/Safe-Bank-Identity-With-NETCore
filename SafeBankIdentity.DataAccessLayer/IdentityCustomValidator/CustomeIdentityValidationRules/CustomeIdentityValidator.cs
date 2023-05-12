using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBankIdentity.DataAccessLayer.IdentityCustomValidator.CustomeIdentityValidationRules
{
	public class CustomeIdentityValidator : IdentityErrorDescriber
	{
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError()
			{
				Code = nameof(PasswordTooShort),
				Description = $"Şifre uzunluğu minumum {length} karakter olmalıdır."
			};
		}

		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError()
			{
				Code = nameof(PasswordRequiresUpper),
				Description = "En az bir büyük harf olmalıdır."
			};
		}

		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError()
			{
				Code = nameof(PasswordRequiresLower),
				Description = "En az bir küçük harf olmalıdır."
			};
		}

		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError()
			{
				Code = nameof(PasswordRequiresDigit),
				Description = "En az bir rakam olmalıdır."
			};
		}

		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError()
			{
				Code = nameof(PasswordRequiresNonAlphanumeric),
				Description = "En az bir sembol olmalıdır."
			};
		}
	}
}
