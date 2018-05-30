using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects

{
	public abstract class AbstractApiSpaceXSpaceFeatureRequestModelValidator: AbstractValidator<ApiSpaceXSpaceFeatureRequestModel>
	{
		public new ValidationResult Validate(ApiSpaceXSpaceFeatureRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiSpaceXSpaceFeatureRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ISpaceFeatureRepository SpaceFeatureRepository { get; set; }
		public ISpaceRepository SpaceRepository { get; set; }
		public virtual void SpaceFeatureIdRules()
		{
			this.RuleFor(x => x.SpaceFeatureId).NotNull();
			this.RuleFor(x => x.SpaceFeatureId).MustAsync(this.BeValidSpaceFeature).When(x => x ?.SpaceFeatureId != null).WithMessage("Invalid reference");
		}

		public virtual void SpaceIdRules()
		{
			this.RuleFor(x => x.SpaceId).NotNull();
			this.RuleFor(x => x.SpaceId).MustAsync(this.BeValidSpace).When(x => x ?.SpaceId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidSpaceFeature(int id,  CancellationToken cancellationToken)
		{
			var record = await this.SpaceFeatureRepository.Get(id);

			return record != null;
		}

		private async Task<bool> BeValidSpace(int id,  CancellationToken cancellationToken)
		{
			var record = await this.SpaceRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>be3de4c227968260ba38e35332291b91</Hash>
</Codenesium>*/