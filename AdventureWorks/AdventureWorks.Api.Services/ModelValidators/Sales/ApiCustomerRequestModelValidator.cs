using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiCustomerRequestModelValidator : AbstractApiCustomerRequestModelValidator, IApiCustomerRequestModelValidator
	{
		public ApiCustomerRequestModelValidator(ICustomerRepository customerRepository)
			: base(customerRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCustomerRequestModel model)
		{
			this.AccountNumberRules();
			this.ModifiedDateRules();
			this.PersonIDRules();
			this.RowguidRules();
			this.StoreIDRules();
			this.TerritoryIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCustomerRequestModel model)
		{
			this.AccountNumberRules();
			this.ModifiedDateRules();
			this.PersonIDRules();
			this.RowguidRules();
			this.StoreIDRules();
			this.TerritoryIDRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>8f7999d27f277696048527c23f56f188</Hash>
</Codenesium>*/