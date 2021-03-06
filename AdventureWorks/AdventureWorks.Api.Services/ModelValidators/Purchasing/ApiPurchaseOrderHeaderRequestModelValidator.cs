using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiPurchaseOrderHeaderRequestModelValidator : AbstractApiPurchaseOrderHeaderRequestModelValidator, IApiPurchaseOrderHeaderRequestModelValidator
	{
		public ApiPurchaseOrderHeaderRequestModelValidator(IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository)
			: base(purchaseOrderHeaderRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPurchaseOrderHeaderRequestModel model)
		{
			this.EmployeeIDRules();
			this.FreightRules();
			this.ModifiedDateRules();
			this.OrderDateRules();
			this.RevisionNumberRules();
			this.ShipDateRules();
			this.ShipMethodIDRules();
			this.StatusRules();
			this.SubTotalRules();
			this.TaxAmtRules();
			this.TotalDueRules();
			this.VendorIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPurchaseOrderHeaderRequestModel model)
		{
			this.EmployeeIDRules();
			this.FreightRules();
			this.ModifiedDateRules();
			this.OrderDateRules();
			this.RevisionNumberRules();
			this.ShipDateRules();
			this.ShipMethodIDRules();
			this.StatusRules();
			this.SubTotalRules();
			this.TaxAmtRules();
			this.TotalDueRules();
			this.VendorIDRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>850d76c6e8dcb00e44e5c0efe16a3a17</Hash>
</Codenesium>*/