using System;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.Service
{
	public class ChainStatusFilter: ActionFilterAttribute
	{
		IChainStatusModelValidator validator { get; set; }

		public ChainStatusFilter(IChainStatusModelValidator validator)
		{
			this.validator = validator;
		}

		public override void OnActionExecuting(ActionExecutingContext actionContext)
		{
			if (actionContext.ActionArguments.Any(kv => kv.Value == null))
			{
				actionContext.Result = new BadRequestObjectResult("Null model is invalid");

				return;
			}

			var items = actionContext.ActionArguments.Values.OfType<ChainStatusModel>().ToList();

			if (items.Any())
			{
				if(actionContext.HttpContext.Request.Method == "POST")
				{
					this.validator.CreateMode();
				}
				else if (actionContext.HttpContext.Request.Method == "PUT")
				{
					this.validator.UpdateMode();
				}
				else if (actionContext.HttpContext.Request.Method == "DELETE")
				{
					this.validator.DeleteMode();
				}
				else
				{
					return;
				}

				Action<ValidationResult> addError = (result) =>
				{
					foreach (var error in result.Errors)
					{
						actionContext.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
					}
				};

				bool validationFailure = false;
				items.ForEach(x =>
				{
					ValidationResult result = this.validator.Validate(x);
					if (!result.IsValid)
					{
					        validationFailure = true;
					        addError(result);
					}
				});

				if (validationFailure)
				{
					actionContext.Result = new BadRequestObjectResult(actionContext.ModelState);
				}
			}
		}
	}
}

/*<Codenesium>
    <Hash>cb2a66ad01790d885cc7be3f3692d31f</Hash>
</Codenesium>*/