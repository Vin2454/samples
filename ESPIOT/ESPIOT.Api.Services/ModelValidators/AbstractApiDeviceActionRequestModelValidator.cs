using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
namespace ESPIOTNS.Api.Services

{
	public abstract class AbstractApiDeviceActionRequestModelValidator: AbstractValidator<ApiDeviceActionRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiDeviceActionRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiDeviceActionRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public IDeviceRepository DeviceRepository { get; set; }
		public virtual void DeviceIdRules()
		{
			this.RuleFor(x => x.DeviceId).NotNull();
			this.RuleFor(x => x.DeviceId).MustAsync(this.BeValidDevice).When(x => x ?.DeviceId != null).WithMessage("Invalid reference");
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 90);
		}

		public virtual void @ValueRules()
		{
			this.RuleFor(x => x.@Value).NotNull();
			this.RuleFor(x => x.@Value).Length(0, 4000);
		}

		private async Task<bool> BeValidDevice(int id,  CancellationToken cancellationToken)
		{
			var record = await this.DeviceRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>a9affd01bed18c04234bd313ef42fab6</Hash>
</Codenesium>*/