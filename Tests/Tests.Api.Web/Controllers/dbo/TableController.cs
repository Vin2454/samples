using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;

namespace TestsNS.Api.Web
{
        [Route("api/tables")]
        [ApiController]
        [ApiVersion("1.0")]
        public class TableController : AbstractTableController
        {
                public TableController(
                        ApiSettings settings,
                        ILogger<TableController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITableService tableService,
                        IApiTableModelMapper tableModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               tableService,
                               tableModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>57f17083a2c275be9fc15cbb8a95ddb1</Hash>
</Codenesium>*/