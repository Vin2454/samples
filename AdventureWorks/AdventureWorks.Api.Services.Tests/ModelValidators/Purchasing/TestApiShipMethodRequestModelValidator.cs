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
        [Trait("Table", "ShipMethod")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiShipMethodRequestModelValidatorTest
        {
                public ApiShipMethodRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IShipMethodRepository> shipMethodRepository = new Mock<IShipMethodRepository>();
                        shipMethodRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ShipMethod()));

                        var validator = new ApiShipMethodRequestModelValidator(shipMethodRepository.Object);

                        await validator.ValidateCreateAsync(new ApiShipMethodRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IShipMethodRepository> shipMethodRepository = new Mock<IShipMethodRepository>();
                        shipMethodRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ShipMethod()));

                        var validator = new ApiShipMethodRequestModelValidator(shipMethodRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiShipMethodRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IShipMethodRepository> shipMethodRepository = new Mock<IShipMethodRepository>();
                        shipMethodRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ShipMethod()));

                        var validator = new ApiShipMethodRequestModelValidator(shipMethodRepository.Object);

                        await validator.ValidateCreateAsync(new ApiShipMethodRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IShipMethodRepository> shipMethodRepository = new Mock<IShipMethodRepository>();
                        shipMethodRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ShipMethod()));

                        var validator = new ApiShipMethodRequestModelValidator(shipMethodRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiShipMethodRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IShipMethodRepository> shipMethodRepository = new Mock<IShipMethodRepository>();
                        shipMethodRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ShipMethod()));

                        var validator = new ApiShipMethodRequestModelValidator(shipMethodRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueByName_Create_Exists()
                {
                        Mock<IShipMethodRepository> shipMethodRepository = new Mock<IShipMethodRepository>();
                        shipMethodRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ShipMethod>(new ShipMethod()));
                        var validator = new ApiShipMethodRequestModelValidator(shipMethodRepository.Object);

                        await validator.ValidateCreateAsync(new ApiShipMethodRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Create_Not_Exists()
                {
                        Mock<IShipMethodRepository> shipMethodRepository = new Mock<IShipMethodRepository>();
                        shipMethodRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ShipMethod>(null));
                        var validator = new ApiShipMethodRequestModelValidator(shipMethodRepository.Object);

                        await validator.ValidateCreateAsync(new ApiShipMethodRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Update_Exists()
                {
                        Mock<IShipMethodRepository> shipMethodRepository = new Mock<IShipMethodRepository>();
                        shipMethodRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ShipMethod>(new ShipMethod()));
                        var validator = new ApiShipMethodRequestModelValidator(shipMethodRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiShipMethodRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Update_Not_Exists()
                {
                        Mock<IShipMethodRepository> shipMethodRepository = new Mock<IShipMethodRepository>();
                        shipMethodRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ShipMethod>(null));
                        var validator = new ApiShipMethodRequestModelValidator(shipMethodRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiShipMethodRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>4e924dea121f254e9ee26eae2d4e989a</Hash>
</Codenesium>*/