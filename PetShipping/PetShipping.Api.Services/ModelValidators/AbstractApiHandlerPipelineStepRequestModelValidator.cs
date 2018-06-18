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
        public abstract class AbstractApiHandlerPipelineStepRequestModelValidator: AbstractValidator<ApiHandlerPipelineStepRequestModel>
        {
                private int existingRecordId;

                IHandlerPipelineStepRepository handlerPipelineStepRepository;

                public AbstractApiHandlerPipelineStepRequestModelValidator(IHandlerPipelineStepRepository handlerPipelineStepRepository)
                {
                        this.handlerPipelineStepRepository = handlerPipelineStepRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiHandlerPipelineStepRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void HandlerIdRules()
                {
                        this.RuleFor(x => x.HandlerId).MustAsync(this.BeValidHandler).When(x => x ?.HandlerId != null).WithMessage("Invalid reference");
                }

                public virtual void PipelineStepIdRules()
                {
                        this.RuleFor(x => x.PipelineStepId).MustAsync(this.BeValidPipelineStep).When(x => x ?.PipelineStepId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidHandler(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.handlerPipelineStepRepository.GetHandler(id);

                        return record != null;
                }

                private async Task<bool> BeValidPipelineStep(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.handlerPipelineStepRepository.GetPipelineStep(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>c9c4e1cf83236cd4b82e33ee121706c5</Hash>
</Codenesium>*/