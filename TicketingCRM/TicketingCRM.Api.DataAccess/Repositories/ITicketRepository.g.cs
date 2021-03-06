using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial interface ITicketRepository
	{
		Task<Ticket> Create(Ticket item);

		Task Update(Ticket item);

		Task Delete(int id);

		Task<Ticket> Get(int id);

		Task<List<Ticket>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Ticket>> ByTicketStatusId(int ticketStatusId, int limit = int.MaxValue, int offset = 0);

		Task<TicketStatu> TicketStatuByTicketStatusId(int ticketStatusId);
	}
}

/*<Codenesium>
    <Hash>06caf7afb75d0985e4de50ea9f3d2121</Hash>
</Codenesium>*/