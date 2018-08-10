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
	public partial class OctopusServerNodeService : AbstractOctopusServerNodeService, IOctopusServerNodeService
	{
		public OctopusServerNodeService(
			ILogger<IOctopusServerNodeRepository> logger,
			IOctopusServerNodeRepository octopusServerNodeRepository,
			IApiOctopusServerNodeRequestModelValidator octopusServerNodeModelValidator,
			IBOLOctopusServerNodeMapper boloctopusServerNodeMapper,
			IDALOctopusServerNodeMapper daloctopusServerNodeMapper
			)
			: base(logger,
			       octopusServerNodeRepository,
			       octopusServerNodeModelValidator,
			       boloctopusServerNodeMapper,
			       daloctopusServerNodeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>792602f783c90bcdf19c96c41087c27e</Hash>
</Codenesium>*/