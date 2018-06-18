using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiScrapReasonRequestModelValidator: AbstractApiScrapReasonRequestModelValidator, IApiScrapReasonRequestModelValidator
        {
                public ApiScrapReasonRequestModelValidator(IScrapReasonRepository scrapReasonRepository)
                        : base(scrapReasonRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiScrapReasonRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(short id, ApiScrapReasonRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.NameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(short id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>e9fb375b7848888d85f3ab3d006b1125</Hash>
</Codenesium>*/