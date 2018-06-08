using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;

namespace NebulaNS.Api.Web
{
        [Route("api/clasps")]
        [ApiVersion("1.0")]
        public class ClaspController: AbstractClaspController
        {
                public ClaspController(
                        ServiceSettings settings,
                        ILogger<ClaspController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IClaspService claspService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               claspService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>a1b3c4be81313889f58f4807211cdc89</Hash>
</Codenesium>*/