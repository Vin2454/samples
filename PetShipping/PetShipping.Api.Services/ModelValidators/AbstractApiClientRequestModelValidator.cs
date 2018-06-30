using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractApiClientRequestModelValidator : AbstractValidator<ApiClientRequestModel>
        {
                private int existingRecordId;

                private IClientRepository clientRepository;

                public AbstractApiClientRequestModelValidator(IClientRepository clientRepository)
                {
                        this.clientRepository = clientRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiClientRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void EmailRules()
                {
                        this.RuleFor(x => x.Email).NotNull();
                        this.RuleFor(x => x.Email).Length(0, 128);
                }

                public virtual void FirstNameRules()
                {
                        this.RuleFor(x => x.FirstName).NotNull();
                        this.RuleFor(x => x.FirstName).Length(0, 128);
                }

                public virtual void LastNameRules()
                {
                        this.RuleFor(x => x.LastName).NotNull();
                        this.RuleFor(x => x.LastName).Length(0, 128);
                }

                public virtual void NotesRules()
                {
                        this.RuleFor(x => x.Notes).Length(0, 2147483647);
                }

                public virtual void PhoneRules()
                {
                        this.RuleFor(x => x.Phone).NotNull();
                        this.RuleFor(x => x.Phone).Length(0, 10);
                }
        }
}

/*<Codenesium>
    <Hash>3924fa807fb8b38a86158c07081d9802</Hash>
</Codenesium>*/