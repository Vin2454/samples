using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public abstract class AbstractApiSelfReferenceModelMapper
	{
		public virtual ApiSelfReferenceResponseModel MapRequestToResponse(
			int id,
			ApiSelfReferenceRequestModel request)
		{
			var response = new ApiSelfReferenceResponseModel();
			response.SetProperties(id,
			                       request.SelfReferenceId,
			                       request.SelfReferenceId2);
			return response;
		}

		public virtual ApiSelfReferenceRequestModel MapResponseToRequest(
			ApiSelfReferenceResponseModel response)
		{
			var request = new ApiSelfReferenceRequestModel();
			request.SetProperties(
				response.SelfReferenceId,
				response.SelfReferenceId2);
			return request;
		}

		public JsonPatchDocument<ApiSelfReferenceRequestModel> CreatePatch(ApiSelfReferenceRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSelfReferenceRequestModel>();
			patch.Replace(x => x.SelfReferenceId, model.SelfReferenceId);
			patch.Replace(x => x.SelfReferenceId2, model.SelfReferenceId2);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>25d87986c4d62815add86c5de2317a56</Hash>
</Codenesium>*/