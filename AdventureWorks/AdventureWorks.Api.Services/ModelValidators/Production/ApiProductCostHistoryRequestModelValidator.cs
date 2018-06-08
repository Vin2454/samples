using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiProductCostHistoryRequestModelValidator: AbstractApiProductCostHistoryRequestModelValidator, IApiProductCostHistoryRequestModelValidator
        {
                public ApiProductCostHistoryRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiProductCostHistoryRequestModel model)
                {
                        this.EndDateRules();
                        this.ModifiedDateRules();
                        this.StandardCostRules();
                        this.StartDateRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductCostHistoryRequestModel model)
                {
                        this.EndDateRules();
                        this.ModifiedDateRules();
                        this.StandardCostRules();
                        this.StartDateRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>1cfca4c400d7ed13f60fd4ab7c073ca0</Hash>
</Codenesium>*/