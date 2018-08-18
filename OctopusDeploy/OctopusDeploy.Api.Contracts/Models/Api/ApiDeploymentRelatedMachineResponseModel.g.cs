using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiDeploymentRelatedMachineResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			string deploymentId,
			string machineId)
		{
			this.Id = id;
			this.DeploymentId = deploymentId;
			this.MachineId = machineId;

			this.DeploymentIdEntity = nameof(ApiResponse.Deployments);
		}

		[Required]
		[JsonProperty]
		public string DeploymentId { get; private set; }

		[JsonProperty]
		public string DeploymentIdEntity { get; set; }

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public string MachineId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>dbddba4befd15509f0eb2eb9003ec63f</Hash>
</Codenesium>*/