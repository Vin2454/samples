using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractApiPaymentTypeRequestModelValidator : AbstractValidator<ApiPaymentTypeRequestModel>
	{
		private int existingRecordId;

		private IPaymentTypeRepository paymentTypeRepository;

		public AbstractApiPaymentTypeRequestModelValidator(IPaymentTypeRepository paymentTypeRepository)
		{
			this.paymentTypeRepository = paymentTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPaymentTypeRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>fc2c25effb13148bbdaac92196c1f8e9</Hash>
</Codenesium>*/