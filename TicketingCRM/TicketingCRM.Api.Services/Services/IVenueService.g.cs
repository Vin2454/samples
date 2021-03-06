using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IVenueService
	{
		Task<CreateResponse<ApiVenueResponseModel>> Create(
			ApiVenueRequestModel model);

		Task<UpdateResponse<ApiVenueResponseModel>> Update(int id,
		                                                    ApiVenueRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiVenueResponseModel> Get(int id);

		Task<List<ApiVenueResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiVenueResponseModel>> ByAdminId(int adminId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiVenueResponseModel>> ByProvinceId(int provinceId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>176ea544120f6283f2b488e314c22660</Hash>
</Codenesium>*/