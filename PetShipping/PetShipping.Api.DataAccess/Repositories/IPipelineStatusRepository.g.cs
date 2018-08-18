using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface IPipelineStatusRepository
	{
		Task<PipelineStatus> Create(PipelineStatus item);

		Task Update(PipelineStatus item);

		Task Delete(int id);

		Task<PipelineStatus> Get(int id);

		Task<List<PipelineStatus>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Pipeline>> Pipelines(int pipelineStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>6d4ebb4e3692337af3a55dbd813d6cb4</Hash>
</Codenesium>*/