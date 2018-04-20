using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.BusinessObjects;

namespace FermataFishNS.Api.Service
{
	[Route("api/rates")]
	[ApiVersion("1.0")]
	[Response]
	public class RateController: AbstractRateController
	{
		public RateController(
			ServiceSettings settings,
			ILogger<RateController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBORate rateManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       rateManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a722064cccd653e8773171ccf6564d94</Hash>
</Codenesium>*/