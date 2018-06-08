using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services

{
        public abstract class AbstractApiFileTypeRequestModelValidator: AbstractValidator<ApiFileTypeRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiFileTypeRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiFileTypeRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 255);
                }
        }
}

/*<Codenesium>
    <Hash>6e14acd20681d9f6c2f021b7af366b9a</Hash>
</Codenesium>*/