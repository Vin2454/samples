using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface ITicketService
	{
		Task<CreateResponse<ApiTicketResponseModel>> Create(
			ApiTicketRequestModel model);

		Task<UpdateResponse<ApiTicketResponseModel>> Update(int id,
		                                                     ApiTicketRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTicketResponseModel> Get(int id);

		Task<List<ApiTicketResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTicketResponseModel>> ByTicketStatusId(int ticketStatusId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSaleTicketsResponseModel>> SaleTickets(int ticketId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7640049a968f38e0ab89c37b7b63f2ba</Hash>
</Codenesium>*/