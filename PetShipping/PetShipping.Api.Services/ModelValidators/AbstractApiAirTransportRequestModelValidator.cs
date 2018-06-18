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
        public abstract class AbstractApiAirTransportRequestModelValidator: AbstractValidator<ApiAirTransportRequestModel>
        {
                private int existingRecordId;

                IAirTransportRepository airTransportRepository;

                public AbstractApiAirTransportRequestModelValidator(IAirTransportRepository airTransportRepository)
                {
                        this.airTransportRepository = airTransportRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiAirTransportRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void FlightNumberRules()
                {
                        this.RuleFor(x => x.FlightNumber).NotNull();
                        this.RuleFor(x => x.FlightNumber).Length(0, 12);
                }

                public virtual void HandlerIdRules()
                {
                        this.RuleFor(x => x.HandlerId).MustAsync(this.BeValidHandler).When(x => x ?.HandlerId != null).WithMessage("Invalid reference");
                }

                public virtual void IdRules()
                {
                }

                public virtual void LandDateRules()
                {
                }

                public virtual void PipelineStepIdRules()
                {
                }

                public virtual void TakeoffDateRules()
                {
                }

                private async Task<bool> BeValidHandler(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.airTransportRepository.GetHandler(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>7035234c55e235e106ed45dc9d41ff43</Hash>
</Codenesium>*/