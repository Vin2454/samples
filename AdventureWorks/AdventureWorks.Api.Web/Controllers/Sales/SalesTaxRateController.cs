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
        [Route("api/salesTaxRates")]
        [ApiVersion("1.0")]
        public class SalesTaxRateController: AbstractSalesTaxRateController
        {
                public SalesTaxRateController(
                        ServiceSettings settings,
                        ILogger<SalesTaxRateController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISalesTaxRateService salesTaxRateService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               salesTaxRateService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>ef5260996328755fd36c0b721709fe5c</Hash>
</Codenesium>*/