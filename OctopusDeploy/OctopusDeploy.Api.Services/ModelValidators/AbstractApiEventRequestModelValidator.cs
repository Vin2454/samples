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
        public abstract class AbstractApiEventRequestModelValidator: AbstractValidator<ApiEventRequestModel>
        {
                private string existingRecordId;

                public ValidationResult Validate(ApiEventRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiEventRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void AutoIdRules()
                {
                        this.RuleFor(x => x.AutoId).NotNull();
                }

                public virtual void CategoryRules()
                {
                        this.RuleFor(x => x.Category).NotNull();
                        this.RuleFor(x => x.Category).Length(0, 50);
                }

                public virtual void EnvironmentIdRules()
                {
                        this.RuleFor(x => x.EnvironmentId).Length(0, 50);
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void MessageRules()
                {
                        this.RuleFor(x => x.Message).NotNull();
                }

                public virtual void OccurredRules()
                {
                        this.RuleFor(x => x.Occurred).NotNull();
                }

                public virtual void ProjectIdRules()
                {
                        this.RuleFor(x => x.ProjectId).Length(0, 50);
                }

                public virtual void RelatedDocumentIdsRules()
                {
                        this.RuleFor(x => x.RelatedDocumentIds).NotNull();
                }

                public virtual void TenantIdRules()
                {
                        this.RuleFor(x => x.TenantId).Length(0, 50);
                }

                public virtual void UserIdRules()
                {
                        this.RuleFor(x => x.UserId).NotNull();
                        this.RuleFor(x => x.UserId).Length(0, 50);
                }

                public virtual void UsernameRules()
                {
                        this.RuleFor(x => x.Username).NotNull();
                        this.RuleFor(x => x.Username).Length(0, 200);
                }
        }
}

/*<Codenesium>
    <Hash>363dc347c472f1d2b1209ca8076f7997</Hash>
</Codenesium>*/