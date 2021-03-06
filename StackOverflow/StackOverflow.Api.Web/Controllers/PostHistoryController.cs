using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Web
{
	[Route("api/postHistories")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class PostHistoryController : AbstractPostHistoryController
	{
		public PostHistoryController(
			ApiSettings settings,
			ILogger<PostHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPostHistoryService postHistoryService,
			IApiPostHistoryModelMapper postHistoryModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       postHistoryService,
			       postHistoryModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>60f4b4f73b97d05a12d8fc6373031e2b</Hash>
</Codenesium>*/