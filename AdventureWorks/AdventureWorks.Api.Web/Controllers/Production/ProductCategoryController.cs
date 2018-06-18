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
        [Route("api/productCategories")]
        [ApiVersion("1.0")]
        public class ProductCategoryController: AbstractProductCategoryController
        {
                public ProductCategoryController(
                        ApiSettings settings,
                        ILogger<ProductCategoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductCategoryService productCategoryService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               productCategoryService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>6d19357f41ad4e47b1729ddfc14b02b0</Hash>
</Codenesium>*/