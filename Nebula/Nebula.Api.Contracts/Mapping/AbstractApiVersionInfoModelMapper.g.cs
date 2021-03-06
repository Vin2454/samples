using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public abstract class AbstractApiVersionInfoModelMapper
	{
		public virtual ApiVersionInfoResponseModel MapRequestToResponse(
			long version,
			ApiVersionInfoRequestModel request)
		{
			var response = new ApiVersionInfoResponseModel();
			response.SetProperties(version,
			                       request.AppliedOn,
			                       request.Description);
			return response;
		}

		public virtual ApiVersionInfoRequestModel MapResponseToRequest(
			ApiVersionInfoResponseModel response)
		{
			var request = new ApiVersionInfoRequestModel();
			request.SetProperties(
				response.AppliedOn,
				response.Description);
			return request;
		}

		public JsonPatchDocument<ApiVersionInfoRequestModel> CreatePatch(ApiVersionInfoRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVersionInfoRequestModel>();
			patch.Replace(x => x.AppliedOn, model.AppliedOn);
			patch.Replace(x => x.Description, model.Description);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>cface62197602bbe21db0d51635d443c</Hash>
</Codenesium>*/