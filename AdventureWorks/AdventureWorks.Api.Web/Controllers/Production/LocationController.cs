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

namespace AdventureWorksNS.Api.Web
{
        [Route("api/locations")]
        [ApiVersion("1.0")]
        public class LocationController : AbstractLocationController
        {
                public LocationController(
                        ApiSettings settings,
                        ILogger<LocationController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ILocationService locationService,
                        IApiLocationModelMapper locationModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               locationService,
                               locationModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>02a1b710777b592b0c35af0beed56017</Hash>
</Codenesium>*/