using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class AWBuildVersionModelValidator: AbstractAWBuildVersionModelValidator, IAWBuildVersionModelValidator
	{
		public AWBuildVersionModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(AWBuildVersionModel model)
		{
			this.Database_VersionRules();
			this.ModifiedDateRules();
			this.VersionDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, AWBuildVersionModel model)
		{
			this.Database_VersionRules();
			this.ModifiedDateRules();
			this.VersionDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>477e9acd1ff9edae04f3eac1be17ed3e</Hash>
</Codenesium>*/