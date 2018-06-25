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
        public abstract class AbstractApiProjectGroupRequestModelValidator : AbstractValidator<ApiProjectGroupRequestModel>
        {
                private string existingRecordId;

                private IProjectGroupRepository projectGroupRepository;

                public AbstractApiProjectGroupRequestModelValidator(IProjectGroupRepository projectGroupRepository)
                {
                        this.projectGroupRepository = projectGroupRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiProjectGroupRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void DataVersionRules()
                {
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProjectGroupRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                private async Task<bool> BeUniqueByName(ApiProjectGroupRequestModel model,  CancellationToken cancellationToken)
                {
                        ProjectGroup record = await this.projectGroupRepository.ByName(model.Name);

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
    <Hash>413f6383835274f01a3698c587394b0e</Hash>
</Codenesium>*/