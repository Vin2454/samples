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
        public abstract class AbstractApiArtifactRequestModelValidator: AbstractValidator<ApiArtifactRequestModel>
        {
                private string existingRecordId;

                IArtifactRepository artifactRepository;

                public AbstractApiArtifactRequestModelValidator(IArtifactRepository artifactRepository)
                {
                        this.artifactRepository = artifactRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiArtifactRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void CreatedRules()
                {
                }

                public virtual void EnvironmentIdRules()
                {
                        this.RuleFor(x => x.EnvironmentId).Length(0, 50);
                }

                public virtual void FilenameRules()
                {
                        this.RuleFor(x => x.Filename).NotNull();
                        this.RuleFor(x => x.Filename).Length(0, 200);
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
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
        }
}

/*<Codenesium>
    <Hash>b4c806eb9915ea6ad300b334f9109db3</Hash>
</Codenesium>*/