using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractApiTeamRequestModelValidator : AbstractValidator<ApiTeamRequestModel>
	{
		private int existingRecordId;

		private ITeamRepository teamRepository;

		public AbstractApiTeamRequestModelValidator(ITeamRepository teamRepository)
		{
			this.teamRepository = teamRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTeamRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiTeamRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void OrganizationIdRules()
		{
			this.RuleFor(x => x.OrganizationId).MustAsync(this.BeValidOrganizationByOrganizationId).When(x => x?.OrganizationId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidOrganizationByOrganizationId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.teamRepository.OrganizationByOrganizationId(id);

			return record != null;
		}

		private async Task<bool> BeUniqueByName(ApiTeamRequestModel model,  CancellationToken cancellationToken)
		{
			Team record = await this.teamRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(int) && record.Id == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>31aa7378f935ea3dc12134244b8919e5</Hash>
</Codenesium>*/