using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public abstract class AbstractApiStudioModelMapper
	{
		public virtual ApiStudioResponseModel MapRequestToResponse(
			int id,
			ApiStudioRequestModel request)
		{
			var response = new ApiStudioResponseModel();
			response.SetProperties(id,
			                       request.Address1,
			                       request.Address2,
			                       request.City,
			                       request.Name,
			                       request.Province,
			                       request.Website,
			                       request.Zip);
			return response;
		}

		public virtual ApiStudioRequestModel MapResponseToRequest(
			ApiStudioResponseModel response)
		{
			var request = new ApiStudioRequestModel();
			request.SetProperties(
				response.Address1,
				response.Address2,
				response.City,
				response.Name,
				response.Province,
				response.Website,
				response.Zip);
			return request;
		}

		public JsonPatchDocument<ApiStudioRequestModel> CreatePatch(ApiStudioRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiStudioRequestModel>();
			patch.Replace(x => x.Address1, model.Address1);
			patch.Replace(x => x.Address2, model.Address2);
			patch.Replace(x => x.City, model.City);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Province, model.Province);
			patch.Replace(x => x.Website, model.Website);
			patch.Replace(x => x.Zip, model.Zip);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>9acb49524eb789315bef6e06ea1d8a27</Hash>
</Codenesium>*/