using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PurchaseOrderHeader")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPurchaseOrderHeaderRequestModelValidatorTest
	{
		public ApiPurchaseOrderHeaderRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>7a577756ace4088569698b25fc66affc</Hash>
</Codenesium>*/