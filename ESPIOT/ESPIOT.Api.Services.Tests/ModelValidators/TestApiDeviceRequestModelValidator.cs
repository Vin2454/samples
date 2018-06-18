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
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Device")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiDeviceRequestModelValidatorTest
        {
                public ApiDeviceRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IDeviceRepository> deviceRepository = new Mock<IDeviceRepository>();
                        deviceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Device()));

                        var validator = new ApiDeviceRequestModelValidator(deviceRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDeviceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IDeviceRepository> deviceRepository = new Mock<IDeviceRepository>();
                        deviceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Device()));

                        var validator = new ApiDeviceRequestModelValidator(deviceRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiDeviceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IDeviceRepository> deviceRepository = new Mock<IDeviceRepository>();
                        deviceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Device()));

                        var validator = new ApiDeviceRequestModelValidator(deviceRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDeviceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 91));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IDeviceRepository> deviceRepository = new Mock<IDeviceRepository>();
                        deviceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Device()));

                        var validator = new ApiDeviceRequestModelValidator(deviceRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiDeviceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 91));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IDeviceRepository> deviceRepository = new Mock<IDeviceRepository>();
                        deviceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Device()));

                        var validator = new ApiDeviceRequestModelValidator(deviceRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueByPublicId_Create_Exists()
                {
                        Mock<IDeviceRepository> deviceRepository = new Mock<IDeviceRepository>();
                        deviceRepository.Setup(x => x.ByPublicId(It.IsAny<Guid>())).Returns(Task.FromResult<Device>(new Device()));
                        var validator = new ApiDeviceRequestModelValidator(deviceRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDeviceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PublicId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                private async void BeUniqueByPublicId_Create_Not_Exists()
                {
                        Mock<IDeviceRepository> deviceRepository = new Mock<IDeviceRepository>();
                        deviceRepository.Setup(x => x.ByPublicId(It.IsAny<Guid>())).Returns(Task.FromResult<Device>(null));
                        var validator = new ApiDeviceRequestModelValidator(deviceRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDeviceRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.PublicId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                private async void BeUniqueByPublicId_Update_Exists()
                {
                        Mock<IDeviceRepository> deviceRepository = new Mock<IDeviceRepository>();
                        deviceRepository.Setup(x => x.ByPublicId(It.IsAny<Guid>())).Returns(Task.FromResult<Device>(new Device()));
                        var validator = new ApiDeviceRequestModelValidator(deviceRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiDeviceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PublicId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                private async void BeUniqueByPublicId_Update_Not_Exists()
                {
                        Mock<IDeviceRepository> deviceRepository = new Mock<IDeviceRepository>();
                        deviceRepository.Setup(x => x.ByPublicId(It.IsAny<Guid>())).Returns(Task.FromResult<Device>(null));
                        var validator = new ApiDeviceRequestModelValidator(deviceRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiDeviceRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.PublicId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }
        }
}

/*<Codenesium>
    <Hash>62f59d3c84e90d9511942d2eda2138b1</Hash>
</Codenesium>*/