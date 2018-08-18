using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public abstract class AbstractApiStudentXFamilyModelMapper
	{
		public virtual ApiStudentXFamilyResponseModel MapRequestToResponse(
			int id,
			ApiStudentXFamilyRequestModel request)
		{
			var response = new ApiStudentXFamilyResponseModel();
			response.SetProperties(id,
			                       request.FamilyId,
			                       request.StudentId);
			return response;
		}

		public virtual ApiStudentXFamilyRequestModel MapResponseToRequest(
			ApiStudentXFamilyResponseModel response)
		{
			var request = new ApiStudentXFamilyRequestModel();
			request.SetProperties(
				response.FamilyId,
				response.StudentId);
			return request;
		}

		public JsonPatchDocument<ApiStudentXFamilyRequestModel> CreatePatch(ApiStudentXFamilyRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiStudentXFamilyRequestModel>();
			patch.Replace(x => x.FamilyId, model.FamilyId);
			patch.Replace(x => x.StudentId, model.StudentId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>841cdb43c5be63e3795ceb40e6c5b0bf</Hash>
</Codenesium>*/