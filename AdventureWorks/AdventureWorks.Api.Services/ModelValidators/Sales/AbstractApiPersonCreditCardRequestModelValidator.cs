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
	public abstract class AbstractApiPersonCreditCardRequestModelValidator : AbstractValidator<ApiPersonCreditCardRequestModel>
	{
		private int existingRecordId;

		private IPersonCreditCardRepository personCreditCardRepository;

		public AbstractApiPersonCreditCardRequestModelValidator(IPersonCreditCardRepository personCreditCardRepository)
		{
			this.personCreditCardRepository = personCreditCardRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPersonCreditCardRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CreditCardIDRules()
		{
			this.RuleFor(x => x.CreditCardID).MustAsync(this.BeValidCreditCard).When(x => x?.CreditCardID != null).WithMessage("Invalid reference");
		}

		public virtual void ModifiedDateRules()
		{
		}

		private async Task<bool> BeValidCreditCard(int id,  CancellationToken cancellationToken)
		{
			var record = await this.personCreditCardRepository.GetCreditCard(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>4c18a52fa619d8c62967a4022eacf49a</Hash>
</Codenesium>*/