using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IKeyAllocationService
	{
		Task<CreateResponse<ApiKeyAllocationResponseModel>> Create(
			ApiKeyAllocationRequestModel model);

		Task<UpdateResponse<ApiKeyAllocationResponseModel>> Update(string collectionName,
		                                                            ApiKeyAllocationRequestModel model);

		Task<ActionResponse> Delete(string collectionName);

		Task<ApiKeyAllocationResponseModel> Get(string collectionName);

		Task<List<ApiKeyAllocationResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f5fec1b44bbb4f7868ce64a9a68d3250</Hash>
</Codenesium>*/