using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IVariableSetRepository
	{
		Task<VariableSet> Create(VariableSet item);

		Task Update(VariableSet item);

		Task Delete(string id);

		Task<VariableSet> Get(string id);

		Task<List<VariableSet>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>dd1c93bfab808c7f16c87000dfdd97e0</Hash>
</Codenesium>*/