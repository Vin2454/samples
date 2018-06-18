using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using System.Linq;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SpecialOfferProduct")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiSpecialOfferProductRequestModelValidatorTest
        {
                public ApiSpecialOfferProductRequestModelValidatorTest()
                {
                }
        }
}

/*<Codenesium>
    <Hash>d7a9dc7c9e9835169ea6b8f2a073dfd6</Hash>
</Codenesium>*/