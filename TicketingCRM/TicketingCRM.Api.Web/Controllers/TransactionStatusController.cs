using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
        [Route("api/transactionStatus")]
        [ApiVersion("1.0")]
        public class TransactionStatusController: AbstractTransactionStatusController
        {
                public TransactionStatusController(
                        ServiceSettings settings,
                        ILogger<TransactionStatusController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITransactionStatusService transactionStatusService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               transactionStatusService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>db85dcb5344df7166461c9897b3e34b9</Hash>
</Codenesium>*/