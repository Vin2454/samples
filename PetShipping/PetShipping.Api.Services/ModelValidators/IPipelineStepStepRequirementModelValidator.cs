using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.Services
{
        public interface IApiPipelineStepStepRequirementRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepStepRequirementRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepStepRequirementRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>370af87b057e1ccf99756537b4345259</Hash>
</Codenesium>*/