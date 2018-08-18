using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public abstract class AbstractApiSpaceXSpaceFeatureModelMapper
	{
		public virtual ApiSpaceXSpaceFeatureResponseModel MapRequestToResponse(
			int id,
			ApiSpaceXSpaceFeatureRequestModel request)
		{
			var response = new ApiSpaceXSpaceFeatureResponseModel();
			response.SetProperties(id,
			                       request.SpaceFeatureId,
			                       request.SpaceId);
			return response;
		}

		public virtual ApiSpaceXSpaceFeatureRequestModel MapResponseToRequest(
			ApiSpaceXSpaceFeatureResponseModel response)
		{
			var request = new ApiSpaceXSpaceFeatureRequestModel();
			request.SetProperties(
				response.SpaceFeatureId,
				response.SpaceId);
			return request;
		}

		public JsonPatchDocument<ApiSpaceXSpaceFeatureRequestModel> CreatePatch(ApiSpaceXSpaceFeatureRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSpaceXSpaceFeatureRequestModel>();
			patch.Replace(x => x.SpaceFeatureId, model.SpaceFeatureId);
			patch.Replace(x => x.SpaceId, model.SpaceId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>df82c54b24cf14f53f2c378d5ecbeb1d</Hash>
</Codenesium>*/