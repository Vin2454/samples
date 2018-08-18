using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IPostLinksService
	{
		Task<CreateResponse<ApiPostLinksResponseModel>> Create(
			ApiPostLinksRequestModel model);

		Task<UpdateResponse<ApiPostLinksResponseModel>> Update(int id,
		                                                        ApiPostLinksRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPostLinksResponseModel> Get(int id);

		Task<List<ApiPostLinksResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>516f0e666c0d13f3371b5eab6e2cfd53</Hash>
</Codenesium>*/