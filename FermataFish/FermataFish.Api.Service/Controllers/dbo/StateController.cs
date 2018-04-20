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
	[Route("api/states")]
	[ApiVersion("1.0")]
	[Response]
	public class StateController: AbstractStateController
	{
		public StateController(
			ServiceSettings settings,
			ILogger<StateController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOState stateManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       stateManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c031883478a517dfd06add840b8f98c1</Hash>
</Codenesium>*/