using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Web
{
	[Route("api/invitations")]
	[ApiController]
	[ApiVersion("1.0")]
	public class InvitationController : AbstractInvitationController
	{
		public InvitationController(
			ApiSettings settings,
			ILogger<InvitationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IInvitationService invitationService,
			IApiInvitationModelMapper invitationModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       invitationService,
			       invitationModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d2d6d932ce4a92f44be6977cf37aa11f</Hash>
</Codenesium>*/