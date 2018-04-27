using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.BusinessObjects;

namespace PetStoreNS.Api.Service
{
	[Route("api/sales")]
	[ApiVersion("1.0")]
	[Response]
	public class SaleController: AbstractSaleController
	{
		public SaleController(
			ServiceSettings settings,
			ILogger<SaleController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSale saleManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       saleManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>abafdd98fb2628ae5b55c89069285896</Hash>
</Codenesium>*/