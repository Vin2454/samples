using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IClaspService
	{
		Task<CreateResponse<ApiClaspResponseModel>> Create(
			ApiClaspRequestModel model);

		Task<UpdateResponse<ApiClaspResponseModel>> Update(int id,
		                                                    ApiClaspRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiClaspResponseModel> Get(int id);

		Task<List<ApiClaspResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>5446e5906cb79e29d13f5a9d2ec6bef5</Hash>
</Codenesium>*/