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
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;

namespace TestsNS.Api.Web
{
	[Route("api/personRefs")]
	[ApiController]
	[ApiVersion("1.0")]
	public class PersonRefController : AbstractPersonRefController
	{
		public PersonRefController(
			ApiSettings settings,
			ILogger<PersonRefController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPersonRefService personRefService,
			IApiPersonRefModelMapper personRefModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       personRefService,
			       personRefModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>19ba793c546c38b8c6a79c16530ba618</Hash>
</Codenesium>*/