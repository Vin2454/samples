using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiTeamRequestModelValidator: AbstractApiTeamRequestModelValidator, IApiTeamRequestModelValidator
        {
                public ApiTeamRequestModelValidator(ITeamRepository teamRepository)
                        : base(teamRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiTeamRequestModel model)
                {
                        this.EnvironmentIdsRules();
                        this.JSONRules();
                        this.MemberUserIdsRules();
                        this.NameRules();
                        this.ProjectGroupIdsRules();
                        this.ProjectIdsRules();
                        this.TenantIdsRules();
                        this.TenantTagsRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiTeamRequestModel model)
                {
                        this.EnvironmentIdsRules();
                        this.JSONRules();
                        this.MemberUserIdsRules();
                        this.NameRules();
                        this.ProjectGroupIdsRules();
                        this.ProjectIdsRules();
                        this.TenantIdsRules();
                        this.TenantTagsRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>b7c6612d1857da92968329b1ec7a4653</Hash>
</Codenesium>*/