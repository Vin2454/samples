using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IVotesRepository
	{
		Task<Votes> Create(Votes item);

		Task Update(Votes item);

		Task Delete(int id);

		Task<Votes> Get(int id);

		Task<List<Votes>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>beb4208a513b51e47f1a4a8564a687d6</Hash>
</Codenesium>*/