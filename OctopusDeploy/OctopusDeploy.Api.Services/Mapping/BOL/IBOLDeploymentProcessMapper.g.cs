using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLDeploymentProcessMapper
	{
		BODeploymentProcess MapModelToBO(
			string id,
			ApiDeploymentProcessRequestModel model);

		ApiDeploymentProcessResponseModel MapBOToModel(
			BODeploymentProcess boDeploymentProcess);

		List<ApiDeploymentProcessResponseModel> MapBOToModel(
			List<BODeploymentProcess> items);
	}
}

/*<Codenesium>
    <Hash>8fa16055907b6bfdfab6e9454ef330f2</Hash>
</Codenesium>*/