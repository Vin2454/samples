using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiMachineRequestModelValidator : AbstractApiMachineRequestModelValidator, IApiMachineRequestModelValidator
	{
		public ApiMachineRequestModelValidator(IMachineRepository machineRepository)
			: base(machineRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiMachineRequestModel model)
		{
			this.DescriptionRules();
			this.JwtKeyRules();
			this.LastIpAddressRules();
			this.MachineGuidRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiMachineRequestModel model)
		{
			this.DescriptionRules();
			this.JwtKeyRules();
			this.LastIpAddressRules();
			this.MachineGuidRules();
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>0f25aefe2082a232d28624d6fe8fcd13</Hash>
</Codenesium>*/