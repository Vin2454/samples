using Codenesium.Foundation.CommonMVC;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FermataFishNS.Api.Web
{
        [Route("api/spaceXSpaceFeatures")]
        [ApiVersion("1.0")]
        public class SpaceXSpaceFeatureController : AbstractSpaceXSpaceFeatureController
        {
                public SpaceXSpaceFeatureController(
                        ApiSettings settings,
                        ILogger<SpaceXSpaceFeatureController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISpaceXSpaceFeatureService spaceXSpaceFeatureService,
                        IApiSpaceXSpaceFeatureModelMapper spaceXSpaceFeatureModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               spaceXSpaceFeatureService,
                               spaceXSpaceFeatureModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>406a63a0841c541aff97c5f463ae9722</Hash>
</Codenesium>*/