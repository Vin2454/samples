using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ISalesPersonQuotaHistoryService
	{
		Task<CreateResponse<ApiSalesPersonQuotaHistoryResponseModel>> Create(
			ApiSalesPersonQuotaHistoryRequestModel model);

		Task<UpdateResponse<ApiSalesPersonQuotaHistoryResponseModel>> Update(int businessEntityID,
		                                                                      ApiSalesPersonQuotaHistoryRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiSalesPersonQuotaHistoryResponseModel> Get(int businessEntityID);

		Task<List<ApiSalesPersonQuotaHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>626ef0dfff876ad58ca279cdb2e1c204</Hash>
</Codenesium>*/