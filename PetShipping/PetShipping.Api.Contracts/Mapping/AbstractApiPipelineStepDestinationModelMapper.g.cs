using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public abstract class AbstractApiPipelineStepDestinationModelMapper
	{
		public virtual ApiPipelineStepDestinationResponseModel MapRequestToResponse(
			int id,
			ApiPipelineStepDestinationRequestModel request)
		{
			var response = new ApiPipelineStepDestinationResponseModel();
			response.SetProperties(id,
			                       request.DestinationId,
			                       request.PipelineStepId);
			return response;
		}

		public virtual ApiPipelineStepDestinationRequestModel MapResponseToRequest(
			ApiPipelineStepDestinationResponseModel response)
		{
			var request = new ApiPipelineStepDestinationRequestModel();
			request.SetProperties(
				response.DestinationId,
				response.PipelineStepId);
			return request;
		}

		public JsonPatchDocument<ApiPipelineStepDestinationRequestModel> CreatePatch(ApiPipelineStepDestinationRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPipelineStepDestinationRequestModel>();
			patch.Replace(x => x.DestinationId, model.DestinationId);
			patch.Replace(x => x.PipelineStepId, model.PipelineStepId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>76452984215748c9b8b172ab446385cf</Hash>
</Codenesium>*/