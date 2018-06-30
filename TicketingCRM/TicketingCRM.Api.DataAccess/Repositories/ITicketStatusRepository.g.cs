using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public interface ITicketStatusRepository
        {
                Task<TicketStatus> Create(TicketStatus item);

                Task Update(TicketStatus item);

                Task Delete(int id);

                Task<TicketStatus> Get(int id);

                Task<List<TicketStatus>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Ticket>> Tickets(int ticketStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>f55fd5087468fcd29956ea5430b0cc48</Hash>
</Codenesium>*/