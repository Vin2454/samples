using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiDeploymentProcessRequestModelValidator : AbstractApiDeploymentProcessRequestModelValidator, IApiDeploymentProcessRequestModelValidator
	{
		public ApiDeploymentProcessRequestModelValidator(IDeploymentProcessRepository deploymentProcessRepository)
			: base(deploymentProcessRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiDeploymentProcessRequestModel model)
		{
			this.IsFrozenRules();
			this.JSONRules();
			this.OwnerIdRules();
			this.RelatedDocumentIdsRules();
			this.VersionRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiDeploymentProcessRequestModel model)
		{
			this.IsFrozenRules();
			this.JSONRules();
			this.OwnerIdRules();
			this.RelatedDocumentIdsRules();
			this.VersionRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>ef91bb121e2f6f40428b50c37e357c2a</Hash>
</Codenesium>*/