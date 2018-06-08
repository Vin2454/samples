using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services

{
        public abstract class AbstractApiPersonCreditCardRequestModelValidator: AbstractValidator<ApiPersonCreditCardRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiPersonCreditCardRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiPersonCreditCardRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ICreditCardRepository CreditCardRepository { get; set; }

                public virtual void CreditCardIDRules()
                {
                        this.RuleFor(x => x.CreditCardID).NotNull();
                        this.RuleFor(x => x.CreditCardID).MustAsync(this.BeValidCreditCard).When(x => x ?.CreditCardID != null).WithMessage("Invalid reference");
                }

                public virtual void ModifiedDateRules()
                {
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                private async Task<bool> BeValidCreditCard(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.CreditCardRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>165fed88c81aab421bd4b0282e6e454a</Hash>
</Codenesium>*/