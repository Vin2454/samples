using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public class ApiDeviceRequestModelValidator : AbstractApiDeviceRequestModelValidator, IApiDeviceRequestModelValidator
	{
		public ApiDeviceRequestModelValidator(IDeviceRepository deviceRepository)
			: base(deviceRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiDeviceRequestModel model)
		{
			this.NameRules();
			this.PublicIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceRequestModel model)
		{
			this.NameRules();
			this.PublicIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>6039b2f6125921bec31b431b8dabcee3</Hash>
</Codenesium>*/