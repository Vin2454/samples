using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public class ApiLinkStatusRequestModelValidator: AbstractApiLinkStatusRequestModelValidator, IApiLinkStatusRequestModelValidator
        {
                public ApiLinkStatusRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiLinkStatusRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkStatusRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>ae9d4bdf52faf28cd0313368e97fb489</Hash>
</Codenesium>*/