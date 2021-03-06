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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
	[Route("api/countries")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class CountryController : AbstractCountryController
	{
		public CountryController(
			ApiSettings settings,
			ILogger<CountryController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICountryService countryService,
			IApiCountryModelMapper countryModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       countryService,
			       countryModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0e5d6fa61bf840e4963d21bdf2ddfc16</Hash>
</Codenesium>*/