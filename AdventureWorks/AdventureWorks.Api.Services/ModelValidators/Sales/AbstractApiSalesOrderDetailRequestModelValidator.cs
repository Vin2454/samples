using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiSalesOrderDetailRequestModelValidator : AbstractValidator<ApiSalesOrderDetailRequestModel>
	{
		private int existingRecordId;

		private ISalesOrderDetailRepository salesOrderDetailRepository;

		public AbstractApiSalesOrderDetailRequestModelValidator(ISalesOrderDetailRepository salesOrderDetailRepository)
		{
			this.salesOrderDetailRepository = salesOrderDetailRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesOrderDetailRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CarrierTrackingNumberRules()
		{
			this.RuleFor(x => x.CarrierTrackingNumber).Length(0, 25);
		}

		public virtual void LineTotalRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void OrderQtyRules()
		{
		}

		public virtual void ProductIDRules()
		{
		}

		public virtual void RowguidRules()
		{
		}

		public virtual void SalesOrderDetailIDRules()
		{
		}

		public virtual void SpecialOfferIDRules()
		{
		}

		public virtual void UnitPriceRules()
		{
		}

		public virtual void UnitPriceDiscountRules()
		{
		}

		private async Task<bool> BeValidSalesOrderHeaderBySalesOrderID(int id,  CancellationToken cancellationToken)
		{
			var record = await this.salesOrderDetailRepository.SalesOrderHeaderBySalesOrderID(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>3cc39f1683ba5f8db8ca7636b3578266</Hash>
</Codenesium>*/