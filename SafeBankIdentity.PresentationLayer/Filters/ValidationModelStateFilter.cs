using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SafeBankIdentity.PresentationLayer.Filters
{
	public static class ValidationModelStateFilter
	{
		public static void GetErrors(ModelStateDictionary modelState, IEnumerable<IdentityError> addedErrors = null) {

			var errors = modelState.Values.SelectMany(v => v.Errors);

			foreach (var error in errors)
			{
				modelState.AddModelError("", error.ErrorMessage);
			}

			if(addedErrors != null)
			{
				foreach (var error in addedErrors)
				{
					modelState.AddModelError("", error.Description);
				}
			}
		}
	}
}
