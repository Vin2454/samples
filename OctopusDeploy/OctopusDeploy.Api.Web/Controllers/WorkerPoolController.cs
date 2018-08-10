using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Web
{
	[Route("api/workerPools")]
	[ApiController]
	[ApiVersion("1.0")]
	public class WorkerPoolController : AbstractWorkerPoolController
	{
		public WorkerPoolController(
			ApiSettings settings,
			ILogger<WorkerPoolController> logger,
			ITransactionCoordinator transactionCoordinator,
			IWorkerPoolService workerPoolService,
			IApiWorkerPoolModelMapper workerPoolModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       workerPoolService,
			       workerPoolModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>3302e042e8a16033accc7f21e7b48734</Hash>
</Codenesium>*/