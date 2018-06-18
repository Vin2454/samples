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
        public abstract class AbstractApiUnitMeasureRequestModelValidator: AbstractValidator<ApiUnitMeasureRequestModel>
        {
                private string existingRecordId;

                IUnitMeasureRepository unitMeasureRepository;

                public AbstractApiUnitMeasureRequestModelValidator(IUnitMeasureRepository unitMeasureRepository)
                {
                        this.unitMeasureRepository = unitMeasureRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiUnitMeasureRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiUnitMeasureRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                private async Task<bool> BeUniqueByName(ApiUnitMeasureRequestModel model,  CancellationToken cancellationToken)
                {
                        UnitMeasure record = await this.unitMeasureRepository.ByName(model.Name);

                        if (record == null || (this.existingRecordId != default (string) && record.UnitMeasureCode == this.existingRecordId))
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>0e5255393023c853225b2943850d6556</Hash>
</Codenesium>*/