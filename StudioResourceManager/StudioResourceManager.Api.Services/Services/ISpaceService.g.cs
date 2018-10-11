using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface ISpaceService
	{
		Task<CreateResponse<ApiSpaceResponseModel>> Create(
			ApiSpaceRequestModel model);

		Task<UpdateResponse<ApiSpaceResponseModel>> Update(int id,
		                                                    ApiSpaceRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSpaceResponseModel> Get(int id);

		Task<List<ApiSpaceResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSpaceSpaceFeatureResponseModel>> SpaceSpaceFeatures(int spaceId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSpaceResponseModel>> BySpaceFeatureId(int spaceId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e2ced789a0facf59c7a54e580e5bdfd7</Hash>
</Codenesium>*/