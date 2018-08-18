using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractApiTransactionStatusRequestModelValidator : AbstractValidator<ApiTransactionStatusRequestModel>
	{
		private int existingRecordId;

		private ITransactionStatusRepository transactionStatusRepository;

		public AbstractApiTransactionStatusRequestModelValidator(ITransactionStatusRepository transactionStatusRepository)
		{
			this.transactionStatusRepository = transactionStatusRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTransactionStatusRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>cfe819252bf206287d673e550846a09e</Hash>
</Codenesium>*/