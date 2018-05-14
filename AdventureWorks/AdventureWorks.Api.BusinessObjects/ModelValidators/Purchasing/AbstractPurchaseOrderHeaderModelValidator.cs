using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiPurchaseOrderHeaderModelValidator: AbstractValidator<ApiPurchaseOrderHeaderModel>
	{
		public new ValidationResult Validate(ApiPurchaseOrderHeaderModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiPurchaseOrderHeaderModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void EmployeeIDRules()
		{
			this.RuleFor(x => x.EmployeeID).NotNull();
		}

		public virtual void FreightRules()
		{
			this.RuleFor(x => x.Freight).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void OrderDateRules()
		{
			this.RuleFor(x => x.OrderDate).NotNull();
		}

		public virtual void RevisionNumberRules()
		{
			this.RuleFor(x => x.RevisionNumber).NotNull();
		}

		public virtual void ShipDateRules()
		{                       }

		public virtual void ShipMethodIDRules()
		{
			this.RuleFor(x => x.ShipMethodID).NotNull();
		}

		public virtual void StatusRules()
		{
			this.RuleFor(x => x.Status).NotNull();
		}

		public virtual void SubTotalRules()
		{
			this.RuleFor(x => x.SubTotal).NotNull();
		}

		public virtual void TaxAmtRules()
		{
			this.RuleFor(x => x.TaxAmt).NotNull();
		}

		public virtual void TotalDueRules()
		{
			this.RuleFor(x => x.TotalDue).NotNull();
		}

		public virtual void VendorIDRules()
		{
			this.RuleFor(x => x.VendorID).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>7f0adcaada5a239399d88e3af5a46c2f</Hash>
</Codenesium>*/