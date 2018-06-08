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
        public class OtherTransportService: AbstractOtherTransportService, IOtherTransportService
        {
                public OtherTransportService(
                        ILogger<OtherTransportRepository> logger,
                        IOtherTransportRepository otherTransportRepository,
                        IApiOtherTransportRequestModelValidator otherTransportModelValidator,
                        IBOLOtherTransportMapper bolotherTransportMapper,
                        IDALOtherTransportMapper dalotherTransportMapper)
                        : base(logger,
                               otherTransportRepository,
                               otherTransportModelValidator,
                               bolotherTransportMapper,
                               dalotherTransportMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>9656d10c9a897a9db7bba0de975b9de8</Hash>
</Codenesium>*/