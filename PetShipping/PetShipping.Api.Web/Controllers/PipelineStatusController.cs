using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Web
{
	[Route("api/pipelineStatus")]
	[ApiController]
	[ApiVersion("1.0")]
	public class PipelineStatusController : AbstractPipelineStatusController
	{
		public PipelineStatusController(
			ApiSettings settings,
			ILogger<PipelineStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPipelineStatusService pipelineStatusService,
			IApiPipelineStatusModelMapper pipelineStatusModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       pipelineStatusService,
			       pipelineStatusModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>bdd1b2e4b2c74f8f5a704f1873ee3e2b</Hash>
</Codenesium>*/