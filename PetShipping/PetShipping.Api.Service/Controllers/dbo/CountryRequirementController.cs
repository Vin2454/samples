using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.BusinessObjects;

namespace PetShippingNS.Api.Service
{
	[Route("api/countryRequirements")]
	[ApiVersion("1.0")]
	[Response]
	public class CountryRequirementController: AbstractCountryRequirementController
	{
		public CountryRequirementController(
			ServiceSettings settings,
			ILogger<CountryRequirementController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOCountryRequirement countryRequirementManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       countryRequirementManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>be7b392bb039688a76bee7f0a2a3234d</Hash>
</Codenesium>*/