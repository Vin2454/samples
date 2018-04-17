using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/productModelIllustrations")]
	[ApiVersion("1.0")]
	public class ProductModelIllustrationController: AbstractProductModelIllustrationController
	{
		public ProductModelIllustrationController(
			ILogger<ProductModelIllustrationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductModelIllustration productModelIllustrationManager
			)
			: base(logger,
			       transactionCoordinator,
			       productModelIllustrationManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>14f72dcb5ace236867f93639bccd28cc</Hash>
</Codenesium>*/