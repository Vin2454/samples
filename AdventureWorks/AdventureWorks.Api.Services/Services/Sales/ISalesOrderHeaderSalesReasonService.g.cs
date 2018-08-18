using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ISalesOrderHeaderSalesReasonService
	{
		Task<CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>> Create(
			ApiSalesOrderHeaderSalesReasonRequestModel model);

		Task<UpdateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>> Update(int salesOrderID,
		                                                                          ApiSalesOrderHeaderSalesReasonRequestModel model);

		Task<ActionResponse> Delete(int salesOrderID);

		Task<ApiSalesOrderHeaderSalesReasonResponseModel> Get(int salesOrderID);

		Task<List<ApiSalesOrderHeaderSalesReasonResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>498d21c1b28da252f4a99be64a9b0210</Hash>
</Codenesium>*/