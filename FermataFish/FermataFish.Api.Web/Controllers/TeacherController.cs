using Codenesium.Foundation.CommonMVC;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Web
{
	[Route("api/teachers")]
	[ApiController]
	[ApiVersion("1.0")]
	public class TeacherController : AbstractTeacherController
	{
		public TeacherController(
			ApiSettings settings,
			ILogger<TeacherController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeacherService teacherService,
			IApiTeacherModelMapper teacherModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       teacherService,
			       teacherModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b8ed71995c3e97815d4b7d52b44ce437</Hash>
</Codenesium>*/