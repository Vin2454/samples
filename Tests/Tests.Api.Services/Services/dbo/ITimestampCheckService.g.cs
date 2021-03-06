using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface ITimestampCheckService
	{
		Task<CreateResponse<ApiTimestampCheckResponseModel>> Create(
			ApiTimestampCheckRequestModel model);

		Task<UpdateResponse<ApiTimestampCheckResponseModel>> Update(int id,
		                                                             ApiTimestampCheckRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTimestampCheckResponseModel> Get(int id);

		Task<List<ApiTimestampCheckResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8d342bcb60b387079c9e8d59ee1965c3</Hash>
</Codenesium>*/