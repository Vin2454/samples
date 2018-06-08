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
        [Route("api/databaseLogs")]
        [ApiVersion("1.0")]
        public class DatabaseLogController: AbstractDatabaseLogController
        {
                public DatabaseLogController(
                        ServiceSettings settings,
                        ILogger<DatabaseLogController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IDatabaseLogService databaseLogService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               databaseLogService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>c1d12b8b5ca2a9c46f3e7b9defd189ab</Hash>
</Codenesium>*/