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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
	[Route("api/transactions")]
	[ApiController]
	[ApiVersion("1.0")]
	public class TransactionController : AbstractTransactionController
	{
		public TransactionController(
			ApiSettings settings,
			ILogger<TransactionController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITransactionService transactionService,
			IApiTransactionModelMapper transactionModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       transactionService,
			       transactionModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>241a02b988016c9ff5332326e33bbc24</Hash>
</Codenesium>*/