using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractApiKeyAllocationRequestModelValidator : AbstractValidator<ApiKeyAllocationRequestModel>
        {
                private string existingRecordId;

                private IKeyAllocationRepository keyAllocationRepository;

                public AbstractApiKeyAllocationRequestModelValidator(IKeyAllocationRepository keyAllocationRepository)
                {
                        this.keyAllocationRepository = keyAllocationRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiKeyAllocationRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void AllocatedRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>730089719d22f3bd1e2677c08289344b</Hash>
</Codenesium>*/