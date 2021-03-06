using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public abstract class AbstractApiCityModelMapper
	{
		public virtual ApiCityResponseModel MapRequestToResponse(
			int id,
			ApiCityRequestModel request)
		{
			var response = new ApiCityResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.ProvinceId);
			return response;
		}

		public virtual ApiCityRequestModel MapResponseToRequest(
			ApiCityResponseModel response)
		{
			var request = new ApiCityRequestModel();
			request.SetProperties(
				response.Name,
				response.ProvinceId);
			return request;
		}

		public JsonPatchDocument<ApiCityRequestModel> CreatePatch(ApiCityRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCityRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.ProvinceId, model.ProvinceId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>e8280b375619541772c2b2ce9ec4811e</Hash>
</Codenesium>*/