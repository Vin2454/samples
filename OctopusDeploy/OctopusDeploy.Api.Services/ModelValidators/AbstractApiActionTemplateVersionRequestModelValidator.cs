using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractApiActionTemplateVersionRequestModelValidator: AbstractValidator<ApiActionTemplateVersionRequestModel>
        {
                private string existingRecordId;

                public ValidationResult Validate(ApiActionTemplateVersionRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiActionTemplateVersionRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IActionTemplateVersionRepository ActionTemplateVersionRepository { get; set; }
                public virtual void ActionTypeRules()
                {
                        this.RuleFor(x => x.ActionType).NotNull();
                        this.RuleFor(x => x.ActionType).Length(0, 50);
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void LatestActionTemplateIdRules()
                {
                        this.RuleFor(x => x.LatestActionTemplateId).NotNull();
                        this.RuleFor(x => x.LatestActionTemplateId).Length(0, 50);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetNameVersion).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiActionTemplateVersionRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void VersionRules()
                {
                        this.RuleFor(x => x.Version).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetNameVersion).When(x => x ?.Version != null).WithMessage("Violates unique constraint").WithName(nameof(ApiActionTemplateVersionRequestModel.Version));
                }

                private async Task<bool> BeUniqueGetNameVersion(ApiActionTemplateVersionRequestModel model,  CancellationToken cancellationToken)
                {
                        ActionTemplateVersion record = await this.ActionTemplateVersionRepository.GetNameVersion(model.Name, model.Version);

                        if (record == null || record.Id == this.existingRecordId)
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
    <Hash>c967e147e472ecba6d8557a7319c5ded</Hash>
</Codenesium>*/