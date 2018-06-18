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
        [Trait("Table", "Shift")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiShiftRequestModelValidatorTest
        {
                public ApiShiftRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IShiftRepository> shiftRepository = new Mock<IShiftRepository>();
                        shiftRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Shift()));

                        var validator = new ApiShiftRequestModelValidator(shiftRepository.Object);

                        await validator.ValidateCreateAsync(new ApiShiftRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IShiftRepository> shiftRepository = new Mock<IShiftRepository>();
                        shiftRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Shift()));

                        var validator = new ApiShiftRequestModelValidator(shiftRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiShiftRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IShiftRepository> shiftRepository = new Mock<IShiftRepository>();
                        shiftRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Shift()));

                        var validator = new ApiShiftRequestModelValidator(shiftRepository.Object);

                        await validator.ValidateCreateAsync(new ApiShiftRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IShiftRepository> shiftRepository = new Mock<IShiftRepository>();
                        shiftRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Shift()));

                        var validator = new ApiShiftRequestModelValidator(shiftRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiShiftRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IShiftRepository> shiftRepository = new Mock<IShiftRepository>();
                        shiftRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Shift()));

                        var validator = new ApiShiftRequestModelValidator(shiftRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueByStartTimeEndTime_Create_Exists()
                {
                        Mock<IShiftRepository> shiftRepository = new Mock<IShiftRepository>();
                        shiftRepository.Setup(x => x.ByStartTimeEndTime(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>())).Returns(Task.FromResult<Shift>(new Shift()));
                        var validator = new ApiShiftRequestModelValidator(shiftRepository.Object);

                        await validator.ValidateCreateAsync(new ApiShiftRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EndTime, TimeSpan.Parse("0"));
                }

                [Fact]
                private async void BeUniqueByStartTimeEndTime_Create_Not_Exists()
                {
                        Mock<IShiftRepository> shiftRepository = new Mock<IShiftRepository>();
                        shiftRepository.Setup(x => x.ByStartTimeEndTime(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>())).Returns(Task.FromResult<Shift>(null));
                        var validator = new ApiShiftRequestModelValidator(shiftRepository.Object);

                        await validator.ValidateCreateAsync(new ApiShiftRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.EndTime, TimeSpan.Parse("0"));
                }

                [Fact]
                private async void BeUniqueByStartTimeEndTime_Update_Exists()
                {
                        Mock<IShiftRepository> shiftRepository = new Mock<IShiftRepository>();
                        shiftRepository.Setup(x => x.ByStartTimeEndTime(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>())).Returns(Task.FromResult<Shift>(new Shift()));
                        var validator = new ApiShiftRequestModelValidator(shiftRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiShiftRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EndTime, TimeSpan.Parse("0"));
                }

                [Fact]
                private async void BeUniqueByStartTimeEndTime_Update_Not_Exists()
                {
                        Mock<IShiftRepository> shiftRepository = new Mock<IShiftRepository>();
                        shiftRepository.Setup(x => x.ByStartTimeEndTime(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>())).Returns(Task.FromResult<Shift>(null));
                        var validator = new ApiShiftRequestModelValidator(shiftRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiShiftRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.EndTime, TimeSpan.Parse("0"));
                }
        }
}

/*<Codenesium>
    <Hash>b995b835dab73e236432e58bde02c708</Hash>
</Codenesium>*/