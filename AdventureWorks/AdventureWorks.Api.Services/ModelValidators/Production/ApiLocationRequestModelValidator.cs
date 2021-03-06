using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiLocationRequestModelValidator : AbstractApiLocationRequestModelValidator, IApiLocationRequestModelValidator
	{
		public ApiLocationRequestModelValidator(ILocationRepository locationRepository)
			: base(locationRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiLocationRequestModel model)
		{
			this.AvailabilityRules();
			this.CostRateRules();
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(short id, ApiLocationRequestModel model)
		{
			this.AvailabilityRules();
			this.CostRateRules();
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(short id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>939eec70e0992f1d57558890a6205ef1</Hash>
</Codenesium>*/