using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface IAirlineRepository
	{
		Task<Airline> Create(Airline item);

		Task Update(Airline item);

		Task Delete(int id);

		Task<Airline> Get(int id);

		Task<List<Airline>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>deb3716b70e2a82448de2b2685069e93</Hash>
</Codenesium>*/