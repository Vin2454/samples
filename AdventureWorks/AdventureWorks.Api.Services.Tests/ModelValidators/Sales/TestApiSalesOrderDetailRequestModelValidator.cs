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
	[Trait("Table", "SalesOrderDetail")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSalesOrderDetailRequestModelValidatorTest
	{
		public ApiSalesOrderDetailRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void CarrierTrackingNumber_Create_length()
		{
			Mock<ISalesOrderDetailRepository> salesOrderDetailRepository = new Mock<ISalesOrderDetailRepository>();
			salesOrderDetailRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderDetail()));

			var validator = new ApiSalesOrderDetailRequestModelValidator(salesOrderDetailRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesOrderDetailRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CarrierTrackingNumber, new string('A', 26));
		}

		[Fact]
		public async void CarrierTrackingNumber_Update_length()
		{
			Mock<ISalesOrderDetailRepository> salesOrderDetailRepository = new Mock<ISalesOrderDetailRepository>();
			salesOrderDetailRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderDetail()));

			var validator = new ApiSalesOrderDetailRequestModelValidator(salesOrderDetailRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderDetailRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CarrierTrackingNumber, new string('A', 26));
		}
	}
}

/*<Codenesium>
    <Hash>7bdf46a0ef1c9fb0ad987996bc25fa5c</Hash>
</Codenesium>*/