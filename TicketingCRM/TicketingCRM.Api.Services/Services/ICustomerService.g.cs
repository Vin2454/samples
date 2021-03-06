using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface ICustomerService
	{
		Task<CreateResponse<ApiCustomerResponseModel>> Create(
			ApiCustomerRequestModel model);

		Task<UpdateResponse<ApiCustomerResponseModel>> Update(int id,
		                                                       ApiCustomerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCustomerResponseModel> Get(int id);

		Task<List<ApiCustomerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7ee5cfbfbef07cd5cc6c5f48dadf2d19</Hash>
</Codenesium>*/