using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public class ApiMachineRequestModelValidator : AbstractApiMachineRequestModelValidator, IApiMachineRequestModelValidator
        {
                public ApiMachineRequestModelValidator(IMachineRepository machineRepository)
                        : base(machineRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiMachineRequestModel model)
                {
                        this.CommunicationStyleRules();
                        this.EnvironmentIdsRules();
                        this.FingerprintRules();
                        this.IsDisabledRules();
                        this.JSONRules();
                        this.MachinePolicyIdRules();
                        this.NameRules();
                        this.RelatedDocumentIdsRules();
                        this.RolesRules();
                        this.TenantIdsRules();
                        this.TenantTagsRules();
                        this.ThumbprintRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiMachineRequestModel model)
                {
                        this.CommunicationStyleRules();
                        this.EnvironmentIdsRules();
                        this.FingerprintRules();
                        this.IsDisabledRules();
                        this.JSONRules();
                        this.MachinePolicyIdRules();
                        this.NameRules();
                        this.RelatedDocumentIdsRules();
                        this.RolesRules();
                        this.TenantIdsRules();
                        this.TenantTagsRules();
                        this.ThumbprintRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>53efbb60964f126b1f82783466578f51</Hash>
</Codenesium>*/