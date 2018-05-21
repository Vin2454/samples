using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOProductDescription: AbstractBOManager
	{
		private IProductDescriptionRepository productDescriptionRepository;
		private IApiProductDescriptionModelValidator productDescriptionModelValidator;
		private ILogger logger;

		public AbstractBOProductDescription(
			ILogger logger,
			IProductDescriptionRepository productDescriptionRepository,
			IApiProductDescriptionModelValidator productDescriptionModelValidator)
			: base()

		{
			this.productDescriptionRepository = productDescriptionRepository;
			this.productDescriptionModelValidator = productDescriptionModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOProductDescription>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productDescriptionRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOProductDescription> Get(int productDescriptionID)
		{
			return this.productDescriptionRepository.Get(productDescriptionID);
		}

		public virtual async Task<CreateResponse<POCOProductDescription>> Create(
			ApiProductDescriptionModel model)
		{
			CreateResponse<POCOProductDescription> response = new CreateResponse<POCOProductDescription>(await this.productDescriptionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOProductDescription record = await this.productDescriptionRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productDescriptionID,
			ApiProductDescriptionModel model)
		{
			ActionResponse response = new ActionResponse(await this.productDescriptionModelValidator.ValidateUpdateAsync(productDescriptionID, model));

			if (response.Success)
			{
				await this.productDescriptionRepository.Update(productDescriptionID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productDescriptionID)
		{
			ActionResponse response = new ActionResponse(await this.productDescriptionModelValidator.ValidateDeleteAsync(productDescriptionID));

			if (response.Success)
			{
				await this.productDescriptionRepository.Delete(productDescriptionID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e9eddba5a20fd5373faa36aabb631a68</Hash>
</Codenesium>*/