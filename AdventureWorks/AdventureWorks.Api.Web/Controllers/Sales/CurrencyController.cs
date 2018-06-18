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
        [Route("api/currencies")]
        [ApiVersion("1.0")]
        public class CurrencyController: AbstractCurrencyController
        {
                public CurrencyController(
                        ApiSettings settings,
                        ILogger<CurrencyController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ICurrencyService currencyService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               currencyService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>0ac2f8ff9ae16b8c2998c695d494429e</Hash>
</Codenesium>*/