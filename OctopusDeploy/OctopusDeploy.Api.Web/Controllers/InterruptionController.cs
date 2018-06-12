using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Web
{
        [Route("api/interruptions")]
        [ApiVersion("1.0")]
        public class InterruptionController: AbstractInterruptionController
        {
                public InterruptionController(
                        ServiceSettings settings,
                        ILogger<InterruptionController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IInterruptionService interruptionService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               interruptionService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>599c5004411c02f7ec797f4bf43ea7ae</Hash>
</Codenesium>*/