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
	[Route("api/cultures")]
	[ApiController]
	[ApiVersion("1.0")]
	public class CultureController : AbstractCultureController
	{
		public CultureController(
			ApiSettings settings,
			ILogger<CultureController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICultureService cultureService,
			IApiCultureModelMapper cultureModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       cultureService,
			       cultureModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>8ebcda89a14123ca0d5d4ef45341f54c</Hash>
</Codenesium>*/