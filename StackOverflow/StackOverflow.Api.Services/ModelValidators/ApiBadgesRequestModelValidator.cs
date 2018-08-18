using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiBadgesRequestModelValidator : AbstractApiBadgesRequestModelValidator, IApiBadgesRequestModelValidator
	{
		public ApiBadgesRequestModelValidator(IBadgesRepository badgesRepository)
			: base(badgesRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiBadgesRequestModel model)
		{
			this.DateRules();
			this.NameRules();
			this.UserIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBadgesRequestModel model)
		{
			this.DateRules();
			this.NameRules();
			this.UserIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>12c9b0d727833b4f21dc3256f20612fc</Hash>
</Codenesium>*/