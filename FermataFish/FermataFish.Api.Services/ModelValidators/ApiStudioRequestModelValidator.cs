using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public class ApiStudioRequestModelValidator : AbstractApiStudioRequestModelValidator, IApiStudioRequestModelValidator
	{
		public ApiStudioRequestModelValidator(IStudioRepository studioRepository)
			: base(studioRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiStudioRequestModel model)
		{
			this.Address1Rules();
			this.Address2Rules();
			this.CityRules();
			this.NameRules();
			this.StateIdRules();
			this.WebsiteRules();
			this.ZipRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudioRequestModel model)
		{
			this.Address1Rules();
			this.Address2Rules();
			this.CityRules();
			this.NameRules();
			this.StateIdRules();
			this.WebsiteRules();
			this.ZipRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>6cdf70c0f50f408af5f0d51605ed6017</Hash>
</Codenesium>*/