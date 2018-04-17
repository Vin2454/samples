using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractEmployeePayHistoryModelValidator: AbstractValidator<EmployeePayHistoryModel>
	{
		public new ValidationResult Validate(EmployeePayHistoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(EmployeePayHistoryModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IEmployeeRepository EmployeeRepository { get; set; }
		public virtual void RateChangeDateRules()
		{
			this.RuleFor(x => x.RateChangeDate).NotNull();
		}

		public virtual void RateRules()
		{
			this.RuleFor(x => x.Rate).NotNull();
		}

		public virtual void PayFrequencyRules()
		{
			this.RuleFor(x => x.PayFrequency).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidEmployee(int id)
		{
			return this.EmployeeRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>c581077c9a759e4c908ef598e29e7d54</Hash>
</Codenesium>*/