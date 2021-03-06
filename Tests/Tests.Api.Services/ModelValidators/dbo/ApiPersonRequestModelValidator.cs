using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiPersonRequestModelValidator : AbstractApiPersonRequestModelValidator, IApiPersonRequestModelValidator
	{
		public ApiPersonRequestModelValidator(IPersonRepository personRepository)
			: base(personRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPersonRequestModel model)
		{
			this.PersonNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonRequestModel model)
		{
			this.PersonNameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>c054ed46771581a37ab893b5c9a16843</Hash>
</Codenesium>*/