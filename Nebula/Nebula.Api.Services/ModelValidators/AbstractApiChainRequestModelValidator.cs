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
	public abstract class AbstractApiChainRequestModelValidator : AbstractValidator<ApiChainRequestModel>
	{
		private int existingRecordId;

		private IChainRepository chainRepository;

		public AbstractApiChainRequestModelValidator(IChainRepository chainRepository)
		{
			this.chainRepository = chainRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiChainRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ChainStatusIdRules()
		{
			this.RuleFor(x => x.ChainStatusId).MustAsync(this.BeValidChainStatusByChainStatusId).When(x => x?.ChainStatusId != null).WithMessage("Invalid reference");
		}

		public virtual void ExternalIdRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByExternalId).When(x => x?.ExternalId != null).WithMessage("Violates unique constraint").WithName(nameof(ApiChainRequestModel.ExternalId));
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void TeamIdRules()
		{
			this.RuleFor(x => x.TeamId).MustAsync(this.BeValidTeamByTeamId).When(x => x?.TeamId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidChainStatusByChainStatusId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.chainRepository.ChainStatusByChainStatusId(id);

			return record != null;
		}

		private async Task<bool> BeValidTeamByTeamId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.chainRepository.TeamByTeamId(id);

			return record != null;
		}

		private async Task<bool> BeUniqueByExternalId(ApiChainRequestModel model,  CancellationToken cancellationToken)
		{
			Chain record = await this.chainRepository.ByExternalId(model.ExternalId);

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
    <Hash>94c73e698600c5ad8af3a3e979090964</Hash>
</Codenesium>*/