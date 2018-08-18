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
	public abstract class AbstractApiSalesPersonQuotaHistoryRequestModelValidator : AbstractValidator<ApiSalesPersonQuotaHistoryRequestModel>
	{
		private int existingRecordId;

		private ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository;

		public AbstractApiSalesPersonQuotaHistoryRequestModelValidator(ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository)
		{
			this.salesPersonQuotaHistoryRepository = salesPersonQuotaHistoryRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesPersonQuotaHistoryRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void QuotaDateRules()
		{
		}

		public virtual void RowguidRules()
		{
		}

		public virtual void SalesQuotaRules()
		{
		}

		private async Task<bool> BeValidSalesPerson(int id,  CancellationToken cancellationToken)
		{
			var record = await this.salesPersonQuotaHistoryRepository.GetSalesPerson(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>224e7214cd9aa4c360e6233c6cc13985</Hash>
</Codenesium>*/