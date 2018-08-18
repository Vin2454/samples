using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial class DeploymentRelatedMachineService : AbstractDeploymentRelatedMachineService, IDeploymentRelatedMachineService
	{
		public DeploymentRelatedMachineService(
			ILogger<IDeploymentRelatedMachineRepository> logger,
			IDeploymentRelatedMachineRepository deploymentRelatedMachineRepository,
			IApiDeploymentRelatedMachineRequestModelValidator deploymentRelatedMachineModelValidator,
			IBOLDeploymentRelatedMachineMapper boldeploymentRelatedMachineMapper,
			IDALDeploymentRelatedMachineMapper daldeploymentRelatedMachineMapper
			)
			: base(logger,
			       deploymentRelatedMachineRepository,
			       deploymentRelatedMachineModelValidator,
			       boldeploymentRelatedMachineMapper,
			       daldeploymentRelatedMachineMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f8cd6c6d96cd4fa5df237bb5d91e25d4</Hash>
</Codenesium>*/