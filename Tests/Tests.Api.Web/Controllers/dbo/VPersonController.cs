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
	[Route("api/vPersons")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class VPersonController : AbstractVPersonController
	{
		public VPersonController(
			ApiSettings settings,
			ILogger<VPersonController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVPersonService vPersonService,
			IApiVPersonModelMapper vPersonModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       vPersonService,
			       vPersonModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>1185222aa7e06813e8d104385e2d2fc1</Hash>
</Codenesium>*/