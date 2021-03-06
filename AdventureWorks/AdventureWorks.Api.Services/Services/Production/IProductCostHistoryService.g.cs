using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IProductCostHistoryService
	{
		Task<CreateResponse<ApiProductCostHistoryResponseModel>> Create(
			ApiProductCostHistoryRequestModel model);

		Task<UpdateResponse<ApiProductCostHistoryResponseModel>> Update(int productID,
		                                                                 ApiProductCostHistoryRequestModel model);

		Task<ActionResponse> Delete(int productID);

		Task<ApiProductCostHistoryResponseModel> Get(int productID);

		Task<List<ApiProductCostHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>808d0f73909c2629214c1bcc7c0af0e1</Hash>
</Codenesium>*/