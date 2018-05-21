using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiCustomerModelValidator: AbstractValidator<ApiCustomerModel>
	{
		public new ValidationResult Validate(ApiCustomerModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiCustomerModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IStoreRepository StoreRepository { get; set; }
		public ISalesTerritoryRepository SalesTerritoryRepository { get; set; }
		public ICustomerRepository CustomerRepository { get; set; }
		public virtual void AccountNumberRules()
		{
			this.RuleFor(x => x.AccountNumber).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueGetAccountNumber).When(x => x ?.AccountNumber != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCustomerModel.AccountNumber));
			this.RuleFor(x => x.AccountNumber).Length(0, 10);
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void PersonIDRules()
		{                       }

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void StoreIDRules()
		{
			this.RuleFor(x => x.StoreID).Must(this.BeValidStore).When(x => x ?.StoreID != null).WithMessage("Invalid reference");
		}

		public virtual void TerritoryIDRules()
		{
			this.RuleFor(x => x.TerritoryID).Must(this.BeValidSalesTerritory).When(x => x ?.TerritoryID != null).WithMessage("Invalid reference");
		}

		private bool BeValidStore(Nullable<int> id)
		{
			return this.StoreRepository.Get(id.GetValueOrDefault()) != null;
		}

		private bool BeValidSalesTerritory(Nullable<int> id)
		{
			return this.SalesTerritoryRepository.Get(id.GetValueOrDefault()) != null;
		}

		private bool BeUniqueGetAccountNumber(ApiCustomerModel model)
		{
			return this.CustomerRepository.GetAccountNumber(model.AccountNumber) == null;
		}
	}
}

/*<Codenesium>
    <Hash>82378517baecac8cfd23fab963543e18</Hash>
</Codenesium>*/