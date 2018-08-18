using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/illustrations")]
	[ApiController]
	[ApiVersion("1.0")]
	public class IllustrationController : AbstractIllustrationController
	{
		public IllustrationController(
			ApiSettings settings,
			ILogger<IllustrationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IIllustrationService illustrationService,
			IApiIllustrationModelMapper illustrationModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       illustrationService,
			       illustrationModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>1f8af528bfb2fe223ae447091b410094</Hash>
</Codenesium>*/