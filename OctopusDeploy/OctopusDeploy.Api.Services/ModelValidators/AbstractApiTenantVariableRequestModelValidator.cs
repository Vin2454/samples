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
        public abstract class AbstractApiTenantVariableRequestModelValidator : AbstractValidator<ApiTenantVariableRequestModel>
        {
                private string existingRecordId;

                private ITenantVariableRepository tenantVariableRepository;

                public AbstractApiTenantVariableRequestModelValidator(ITenantVariableRepository tenantVariableRepository)
                {
                        this.tenantVariableRepository = tenantVariableRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiTenantVariableRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void EnvironmentIdRules()
                {
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByTenantIdOwnerIdEnvironmentIdVariableTemplateId).When(x => x?.EnvironmentId != null).WithMessage("Violates unique constraint").WithName(nameof(ApiTenantVariableRequestModel.EnvironmentId));
                        this.RuleFor(x => x.EnvironmentId).Length(0, 50);
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void OwnerIdRules()
                {
                        this.RuleFor(x => x.OwnerId).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByTenantIdOwnerIdEnvironmentIdVariableTemplateId).When(x => x?.OwnerId != null).WithMessage("Violates unique constraint").WithName(nameof(ApiTenantVariableRequestModel.OwnerId));
                        this.RuleFor(x => x.OwnerId).Length(0, 50);
                }

                public virtual void RelatedDocumentIdRules()
                {
                }

                public virtual void TenantIdRules()
                {
                        this.RuleFor(x => x.TenantId).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByTenantIdOwnerIdEnvironmentIdVariableTemplateId).When(x => x?.TenantId != null).WithMessage("Violates unique constraint").WithName(nameof(ApiTenantVariableRequestModel.TenantId));
                        this.RuleFor(x => x.TenantId).Length(0, 50);
                }

                public virtual void VariableTemplateIdRules()
                {
                        this.RuleFor(x => x.VariableTemplateId).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByTenantIdOwnerIdEnvironmentIdVariableTemplateId).When(x => x?.VariableTemplateId != null).WithMessage("Violates unique constraint").WithName(nameof(ApiTenantVariableRequestModel.VariableTemplateId));
                        this.RuleFor(x => x.VariableTemplateId).Length(0, 50);
                }

                private async Task<bool> BeUniqueByTenantIdOwnerIdEnvironmentIdVariableTemplateId(ApiTenantVariableRequestModel model,  CancellationToken cancellationToken)
                {
                        TenantVariable record = await this.tenantVariableRepository.ByTenantIdOwnerIdEnvironmentIdVariableTemplateId(model.TenantId, model.OwnerId, model.EnvironmentId, model.VariableTemplateId);

                        if (record == null || (this.existingRecordId != default(string) && record.Id == this.existingRecordId))
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
    <Hash>2bfb8eae0c9c34e6917b75bd5756590c</Hash>
</Codenesium>*/