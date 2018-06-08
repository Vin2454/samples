using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class ApiOtherTransportRequestModelValidator: AbstractApiOtherTransportRequestModelValidator, IApiOtherTransportRequestModelValidator
        {
                public ApiOtherTransportRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiOtherTransportRequestModel model)
                {
                        this.HandlerIdRules();
                        this.PipelineStepIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiOtherTransportRequestModel model)
                {
                        this.HandlerIdRules();
                        this.PipelineStepIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>7ef9392ffbab27ee89066b4bb6d72bec</Hash>
</Codenesium>*/