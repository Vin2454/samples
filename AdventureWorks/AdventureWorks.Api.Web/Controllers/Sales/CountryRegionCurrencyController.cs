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
	[Route("api/countryRegionCurrencies")]
	[ApiController]
	[ApiVersion("1.0")]
	public class CountryRegionCurrencyController : AbstractCountryRegionCurrencyController
	{
		public CountryRegionCurrencyController(
			ApiSettings settings,
			ILogger<CountryRegionCurrencyController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICountryRegionCurrencyService countryRegionCurrencyService,
			IApiCountryRegionCurrencyModelMapper countryRegionCurrencyModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       countryRegionCurrencyService,
			       countryRegionCurrencyModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f223352fe5bb617b14534d5c735472ce</Hash>
</Codenesium>*/