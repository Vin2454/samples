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
	public abstract class AbstractApiProductListPriceHistoryRequestModelValidator : AbstractValidator<ApiProductListPriceHistoryRequestModel>
	{
		private int existingRecordId;

		private IProductListPriceHistoryRepository productListPriceHistoryRepository;

		public AbstractApiProductListPriceHistoryRequestModelValidator(IProductListPriceHistoryRepository productListPriceHistoryRepository)
		{
			this.productListPriceHistoryRepository = productListPriceHistoryRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductListPriceHistoryRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void EndDateRules()
		{
		}

		public virtual void ListPriceRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void StartDateRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>d3d0822c6e067df3739e8221d03fcd1e</Hash>
</Codenesium>*/