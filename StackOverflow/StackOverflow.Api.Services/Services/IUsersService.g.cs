using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IUsersService
	{
		Task<CreateResponse<ApiUsersResponseModel>> Create(
			ApiUsersRequestModel model);

		Task<UpdateResponse<ApiUsersResponseModel>> Update(int id,
		                                                    ApiUsersRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiUsersResponseModel> Get(int id);

		Task<List<ApiUsersResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>9d83eda63ebeb96592fdb649527a320a</Hash>
</Codenesium>*/