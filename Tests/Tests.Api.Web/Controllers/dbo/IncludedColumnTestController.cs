using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;

namespace TestsNS.Api.Web
{
	[Route("api/includedColumnTests")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class IncludedColumnTestController : AbstractIncludedColumnTestController
	{
		public IncludedColumnTestController(
			ApiSettings settings,
			ILogger<IncludedColumnTestController> logger,
			ITransactionCoordinator transactionCoordinator,
			IIncludedColumnTestService includedColumnTestService,
			IApiIncludedColumnTestModelMapper includedColumnTestModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       includedColumnTestService,
			       includedColumnTestModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>cea21d16ce0ff1c1825d52122b23a3ac</Hash>
</Codenesium>*/