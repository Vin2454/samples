using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public class ApiWorkerPoolRequestModelValidator : AbstractApiWorkerPoolRequestModelValidator, IApiWorkerPoolRequestModelValidator
        {
                public ApiWorkerPoolRequestModelValidator(IWorkerPoolRepository workerPoolRepository)
                        : base(workerPoolRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiWorkerPoolRequestModel model)
                {
                        this.IsDefaultRules();
                        this.JSONRules();
                        this.NameRules();
                        this.SortOrderRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiWorkerPoolRequestModel model)
                {
                        this.IsDefaultRules();
                        this.JSONRules();
                        this.NameRules();
                        this.SortOrderRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>efca230a7f4f7cc143625aaea8c72353</Hash>
</Codenesium>*/