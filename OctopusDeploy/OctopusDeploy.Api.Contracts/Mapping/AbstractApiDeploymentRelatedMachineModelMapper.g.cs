using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiDeploymentRelatedMachineModelMapper
	{
		public virtual ApiDeploymentRelatedMachineResponseModel MapRequestToResponse(
			int id,
			ApiDeploymentRelatedMachineRequestModel request)
		{
			var response = new ApiDeploymentRelatedMachineResponseModel();
			response.SetProperties(id,
			                       request.DeploymentId,
			                       request.MachineId);
			return response;
		}

		public virtual ApiDeploymentRelatedMachineRequestModel MapResponseToRequest(
			ApiDeploymentRelatedMachineResponseModel response)
		{
			var request = new ApiDeploymentRelatedMachineRequestModel();
			request.SetProperties(
				response.DeploymentId,
				response.MachineId);
			return request;
		}

		public JsonPatchDocument<ApiDeploymentRelatedMachineRequestModel> CreatePatch(ApiDeploymentRelatedMachineRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiDeploymentRelatedMachineRequestModel>();
			patch.Replace(x => x.DeploymentId, model.DeploymentId);
			patch.Replace(x => x.MachineId, model.MachineId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>d267818571462559e0cbdff315102af9</Hash>
</Codenesium>*/