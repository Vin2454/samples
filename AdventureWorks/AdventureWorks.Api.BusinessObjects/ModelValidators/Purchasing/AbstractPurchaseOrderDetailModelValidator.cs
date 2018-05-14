using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiPurchaseOrderDetailModelValidator: AbstractValidator<ApiPurchaseOrderDetailModel>
	{
		public new ValidationResult Validate(ApiPurchaseOrderDetailModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiPurchaseOrderDetailModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void DueDateRules()
		{
			this.RuleFor(x => x.DueDate).NotNull();
		}

		public virtual void LineTotalRules()
		{
			this.RuleFor(x => x.LineTotal).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void OrderQtyRules()
		{
			this.RuleFor(x => x.OrderQty).NotNull();
		}

		public virtual void ProductIDRules()
		{
			this.RuleFor(x => x.ProductID).NotNull();
		}

		public virtual void PurchaseOrderDetailIDRules()
		{
			this.RuleFor(x => x.PurchaseOrderDetailID).NotNull();
		}

		public virtual void ReceivedQtyRules()
		{
			this.RuleFor(x => x.ReceivedQty).NotNull();
		}

		public virtual void RejectedQtyRules()
		{
			this.RuleFor(x => x.RejectedQty).NotNull();
		}

		public virtual void StockedQtyRules()
		{
			this.RuleFor(x => x.StockedQty).NotNull();
		}

		public virtual void UnitPriceRules()
		{
			this.RuleFor(x => x.UnitPrice).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>c97244708fdfc5c1828c9be8ba71ae5a</Hash>
</Codenesium>*/