using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiCurrencyRequestModelValidator : AbstractValidator<ApiCurrencyRequestModel>
	{
		private string existingRecordId;

		private ICurrencyRepository currencyRepository;

		public AbstractApiCurrencyRequestModelValidator(ICurrencyRepository currencyRepository)
		{
			this.currencyRepository = currencyRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCurrencyRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCurrencyRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		private async Task<bool> BeUniqueByName(ApiCurrencyRequestModel model,  CancellationToken cancellationToken)
		{
			Currency record = await this.currencyRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(string) && record.CurrencyCode == this.existingRecordId))
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
    <Hash>7e9f62b009f87fbea54234fa208266c8</Hash>
</Codenesium>*/