using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class AirlineService: AbstractAirlineService, IAirlineService
        {
                public AirlineService(
                        ILogger<IAirlineRepository> logger,
                        IAirlineRepository airlineRepository,
                        IApiAirlineRequestModelValidator airlineModelValidator,
                        IBOLAirlineMapper bolairlineMapper,
                        IDALAirlineMapper dalairlineMapper

                        )
                        : base(logger,
                               airlineRepository,
                               airlineModelValidator,
                               bolairlineMapper,
                               dalairlineMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>edb9b35c0fabe6ff17c61de49c0853a6</Hash>
</Codenesium>*/