using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
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
	[Route("api/users")]
	[ApiController]
	[ApiVersion("1.0")]
	public class UsersController : AbstractUsersController
	{
		public UsersController(
			ApiSettings settings,
			ILogger<UsersController> logger,
			ITransactionCoordinator transactionCoordinator,
			IUsersService usersService,
			IApiUsersModelMapper usersModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       usersService,
			       usersModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>eb1030a0143fb28b00677c6771a10f3a</Hash>
</Codenesium>*/