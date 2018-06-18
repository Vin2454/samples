using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class AddressService: AbstractAddressService, IAddressService
        {
                public AddressService(
                        ILogger<IAddressRepository> logger,
                        IAddressRepository addressRepository,
                        IApiAddressRequestModelValidator addressModelValidator,
                        IBOLAddressMapper boladdressMapper,
                        IDALAddressMapper daladdressMapper
                        ,
                        IBOLBusinessEntityAddressMapper bolBusinessEntityAddressMapper,
                        IDALBusinessEntityAddressMapper dalBusinessEntityAddressMapper

                        )
                        : base(logger,
                               addressRepository,
                               addressModelValidator,
                               boladdressMapper,
                               daladdressMapper
                               ,
                               bolBusinessEntityAddressMapper,
                               dalBusinessEntityAddressMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>81c5b4c0039c7bdd18e56df279cd8de1</Hash>
</Codenesium>*/