using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
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

namespace AdventureWorksNS.Api.Web
{
	[Route("api/employeeDepartmentHistories")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class EmployeeDepartmentHistoryController : AbstractEmployeeDepartmentHistoryController
	{
		public EmployeeDepartmentHistoryController(
			ApiSettings settings,
			ILogger<EmployeeDepartmentHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEmployeeDepartmentHistoryService employeeDepartmentHistoryService,
			IApiEmployeeDepartmentHistoryModelMapper employeeDepartmentHistoryModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       employeeDepartmentHistoryService,
			       employeeDepartmentHistoryModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f80ac0b3c02ea6676e6c56886ef137f1</Hash>
</Codenesium>*/