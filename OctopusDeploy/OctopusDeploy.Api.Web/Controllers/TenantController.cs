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
	[Route("api/tenants")]
	[ApiController]
	[ApiVersion("1.0")]
	public class TenantController : AbstractTenantController
	{
		public TenantController(
			ApiSettings settings,
			ILogger<TenantController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITenantService tenantService,
			IApiTenantModelMapper tenantModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       tenantService,
			       tenantModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>352327dd06584eb800fef991cc4a3362</Hash>
</Codenesium>*/