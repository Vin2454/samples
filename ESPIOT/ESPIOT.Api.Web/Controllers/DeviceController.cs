using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.Services;

namespace ESPIOTNS.Api.Web
{
	[Route("api/devices")]
	[ApiVersion("1.0")]
	public class DeviceController: AbstractDeviceController
	{
		public DeviceController(
			ServiceSettings settings,
			ILogger<DeviceController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDeviceService deviceService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       deviceService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>33d9e02d4c4110f66868f36607260f18</Hash>
</Codenesium>*/