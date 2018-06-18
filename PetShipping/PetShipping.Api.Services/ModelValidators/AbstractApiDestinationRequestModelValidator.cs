using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractApiDestinationRequestModelValidator: AbstractValidator<ApiDestinationRequestModel>
        {
                private int existingRecordId;

                IDestinationRepository destinationRepository;

                public AbstractApiDestinationRequestModelValidator(IDestinationRepository destinationRepository)
                {
                        this.destinationRepository = destinationRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiDestinationRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void CountryIdRules()
                {
                        this.RuleFor(x => x.CountryId).MustAsync(this.BeValidCountry).When(x => x ?.CountryId != null).WithMessage("Invalid reference");
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 128);
                }

                public virtual void OrderRules()
                {
                }

                private async Task<bool> BeValidCountry(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.destinationRepository.GetCountry(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>5b8dd305e40ac976a23d4a1850af5a4b</Hash>
</Codenesium>*/