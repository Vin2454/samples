using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractShiftModelValidator: AbstractValidator<ShiftModel>
	{
		public new ValidationResult Validate(ShiftModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ShiftModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void EndTimeRules()
		{
			this.RuleFor(x => x.EndTime).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void StartTimeRules()
		{
			this.RuleFor(x => x.StartTime).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>937c6f30c5b726f5d436d59ee07d12d9</Hash>
</Codenesium>*/