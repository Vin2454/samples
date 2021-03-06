using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NebulaNS.Api.Web
{
	[Route("api/organizations")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class OrganizationController : AbstractOrganizationController
	{
		public OrganizationController(
			ApiSettings settings,
			ILogger<OrganizationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IOrganizationService organizationService,
			IApiOrganizationModelMapper organizationModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       organizationService,
			       organizationModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>72e1159f0804564e657f14ccc610466b</Hash>
</Codenesium>*/