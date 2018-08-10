using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiVariableSetRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVariableSetRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiVariableSetRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>22b0f417ba78c7fb4229c091b030cd40</Hash>
</Codenesium>*/