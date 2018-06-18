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
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
        [Route("api/productSubcategories")]
        [ApiVersion("1.0")]
        public class ProductSubcategoryController: AbstractProductSubcategoryController
        {
                public ProductSubcategoryController(
                        ApiSettings settings,
                        ILogger<ProductSubcategoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductSubcategoryService productSubcategoryService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               productSubcategoryService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>de56971a46bd9cecb401fb3db83bdcbd</Hash>
</Codenesium>*/