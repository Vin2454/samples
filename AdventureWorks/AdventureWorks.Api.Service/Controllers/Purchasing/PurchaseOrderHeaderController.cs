using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/purchaseOrderHeaders")]
	[ApiVersion("1.0")]
	[Response]
	public class PurchaseOrderHeaderController: AbstractPurchaseOrderHeaderController
	{
		public PurchaseOrderHeaderController(
			ServiceSettings settings,
			ILogger<PurchaseOrderHeaderController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPurchaseOrderHeader purchaseOrderHeaderManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       purchaseOrderHeaderManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>6c20663325e9790dd7f8d8f8ffc78845</Hash>
</Codenesium>*/