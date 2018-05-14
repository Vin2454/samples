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
	public abstract class AbstractBOWorkOrder
	{
		private IWorkOrderRepository workOrderRepository;
		private IApiWorkOrderModelValidator workOrderModelValidator;
		private ILogger logger;

		public AbstractBOWorkOrder(
			ILogger logger,
			IWorkOrderRepository workOrderRepository,
			IApiWorkOrderModelValidator workOrderModelValidator)

		{
			this.workOrderRepository = workOrderRepository;
			this.workOrderModelValidator = workOrderModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOWorkOrder> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.workOrderRepository.All(skip, take, orderClause);
		}

		public virtual POCOWorkOrder Get(int workOrderID)
		{
			return this.workOrderRepository.Get(workOrderID);
		}

		public virtual async Task<CreateResponse<POCOWorkOrder>> Create(
			ApiWorkOrderModel model)
		{
			CreateResponse<POCOWorkOrder> response = new CreateResponse<POCOWorkOrder>(await this.workOrderModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOWorkOrder record = this.workOrderRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int workOrderID,
			ApiWorkOrderModel model)
		{
			ActionResponse response = new ActionResponse(await this.workOrderModelValidator.ValidateUpdateAsync(workOrderID, model));

			if (response.Success)
			{
				this.workOrderRepository.Update(workOrderID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int workOrderID)
		{
			ActionResponse response = new ActionResponse(await this.workOrderModelValidator.ValidateDeleteAsync(workOrderID));

			if (response.Success)
			{
				this.workOrderRepository.Delete(workOrderID);
			}
			return response;
		}

		public List<POCOWorkOrder> GetProductID(int productID)
		{
			return this.workOrderRepository.GetProductID(productID);
		}
		public List<POCOWorkOrder> GetScrapReasonID(Nullable<short> scrapReasonID)
		{
			return this.workOrderRepository.GetScrapReasonID(scrapReasonID);
		}
	}
}

/*<Codenesium>
    <Hash>2b408333560734b45af8ad8acadf8c4a</Hash>
</Codenesium>*/