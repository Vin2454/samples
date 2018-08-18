using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
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
	[Route("api/productInventories")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ProductInventoryController : AbstractProductInventoryController
	{
		public ProductInventoryController(
			ApiSettings settings,
			ILogger<ProductInventoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductInventoryService productInventoryService,
			IApiProductInventoryModelMapper productInventoryModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productInventoryService,
			       productInventoryModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>75d94a13dd4252145cc11e29ccc77663</Hash>
</Codenesium>*/