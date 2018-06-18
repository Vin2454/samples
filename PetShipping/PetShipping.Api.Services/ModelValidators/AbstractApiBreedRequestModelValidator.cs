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
        public abstract class AbstractApiBreedRequestModelValidator: AbstractValidator<ApiBreedRequestModel>
        {
                private int existingRecordId;

                IBreedRepository breedRepository;

                public AbstractApiBreedRequestModelValidator(IBreedRepository breedRepository)
                {
                        this.breedRepository = breedRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiBreedRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 128);
                }

                public virtual void SpeciesIdRules()
                {
                        this.RuleFor(x => x.SpeciesId).MustAsync(this.BeValidSpecies).When(x => x ?.SpeciesId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidSpecies(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.breedRepository.GetSpecies(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>0a88906ae2032323e233261ad84906f3</Hash>
</Codenesium>*/