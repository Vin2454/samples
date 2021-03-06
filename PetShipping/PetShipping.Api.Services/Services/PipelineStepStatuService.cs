using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial class PipelineStepStatuService : AbstractPipelineStepStatuService, IPipelineStepStatuService
	{
		public PipelineStepStatuService(
			ILogger<IPipelineStepStatuRepository> logger,
			IPipelineStepStatuRepository pipelineStepStatuRepository,
			IApiPipelineStepStatuRequestModelValidator pipelineStepStatuModelValidator,
			IBOLPipelineStepStatuMapper bolpipelineStepStatuMapper,
			IDALPipelineStepStatuMapper dalpipelineStepStatuMapper,
			IBOLPipelineStepMapper bolPipelineStepMapper,
			IDALPipelineStepMapper dalPipelineStepMapper)
			: base(logger,
			       pipelineStepStatuRepository,
			       pipelineStepStatuModelValidator,
			       bolpipelineStepStatuMapper,
			       dalpipelineStepStatuMapper,
			       bolPipelineStepMapper,
			       dalPipelineStepMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8189004efc36f0a3c7873478a22bad61</Hash>
</Codenesium>*/