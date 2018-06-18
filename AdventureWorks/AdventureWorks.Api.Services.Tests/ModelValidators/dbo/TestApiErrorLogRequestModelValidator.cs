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
        [Trait("Table", "ErrorLog")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiErrorLogRequestModelValidatorTest
        {
                public ApiErrorLogRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void ErrorMessage_Create_null()
                {
                        Mock<IErrorLogRepository> errorLogRepository = new Mock<IErrorLogRepository>();
                        errorLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ErrorLog()));

                        var validator = new ApiErrorLogRequestModelValidator(errorLogRepository.Object);

                        await validator.ValidateCreateAsync(new ApiErrorLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ErrorMessage, null as string);
                }

                [Fact]
                public async void ErrorMessage_Update_null()
                {
                        Mock<IErrorLogRepository> errorLogRepository = new Mock<IErrorLogRepository>();
                        errorLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ErrorLog()));

                        var validator = new ApiErrorLogRequestModelValidator(errorLogRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiErrorLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ErrorMessage, null as string);
                }

                [Fact]
                public async void ErrorMessage_Create_length()
                {
                        Mock<IErrorLogRepository> errorLogRepository = new Mock<IErrorLogRepository>();
                        errorLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ErrorLog()));

                        var validator = new ApiErrorLogRequestModelValidator(errorLogRepository.Object);

                        await validator.ValidateCreateAsync(new ApiErrorLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ErrorMessage, new string('A', 4001));
                }

                [Fact]
                public async void ErrorMessage_Update_length()
                {
                        Mock<IErrorLogRepository> errorLogRepository = new Mock<IErrorLogRepository>();
                        errorLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ErrorLog()));

                        var validator = new ApiErrorLogRequestModelValidator(errorLogRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiErrorLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ErrorMessage, new string('A', 4001));
                }

                [Fact]
                public async void ErrorMessage_Delete()
                {
                        Mock<IErrorLogRepository> errorLogRepository = new Mock<IErrorLogRepository>();
                        errorLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ErrorLog()));

                        var validator = new ApiErrorLogRequestModelValidator(errorLogRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void ErrorProcedure_Create_length()
                {
                        Mock<IErrorLogRepository> errorLogRepository = new Mock<IErrorLogRepository>();
                        errorLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ErrorLog()));

                        var validator = new ApiErrorLogRequestModelValidator(errorLogRepository.Object);

                        await validator.ValidateCreateAsync(new ApiErrorLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ErrorProcedure, new string('A', 127));
                }

                [Fact]
                public async void ErrorProcedure_Update_length()
                {
                        Mock<IErrorLogRepository> errorLogRepository = new Mock<IErrorLogRepository>();
                        errorLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ErrorLog()));

                        var validator = new ApiErrorLogRequestModelValidator(errorLogRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiErrorLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ErrorProcedure, new string('A', 127));
                }

                [Fact]
                public async void ErrorProcedure_Delete()
                {
                        Mock<IErrorLogRepository> errorLogRepository = new Mock<IErrorLogRepository>();
                        errorLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ErrorLog()));

                        var validator = new ApiErrorLogRequestModelValidator(errorLogRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void UserName_Create_null()
                {
                        Mock<IErrorLogRepository> errorLogRepository = new Mock<IErrorLogRepository>();
                        errorLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ErrorLog()));

                        var validator = new ApiErrorLogRequestModelValidator(errorLogRepository.Object);

                        await validator.ValidateCreateAsync(new ApiErrorLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.UserName, null as string);
                }

                [Fact]
                public async void UserName_Update_null()
                {
                        Mock<IErrorLogRepository> errorLogRepository = new Mock<IErrorLogRepository>();
                        errorLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ErrorLog()));

                        var validator = new ApiErrorLogRequestModelValidator(errorLogRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiErrorLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.UserName, null as string);
                }

                [Fact]
                public async void UserName_Create_length()
                {
                        Mock<IErrorLogRepository> errorLogRepository = new Mock<IErrorLogRepository>();
                        errorLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ErrorLog()));

                        var validator = new ApiErrorLogRequestModelValidator(errorLogRepository.Object);

                        await validator.ValidateCreateAsync(new ApiErrorLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.UserName, new string('A', 129));
                }

                [Fact]
                public async void UserName_Update_length()
                {
                        Mock<IErrorLogRepository> errorLogRepository = new Mock<IErrorLogRepository>();
                        errorLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ErrorLog()));

                        var validator = new ApiErrorLogRequestModelValidator(errorLogRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiErrorLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.UserName, new string('A', 129));
                }

                [Fact]
                public async void UserName_Delete()
                {
                        Mock<IErrorLogRepository> errorLogRepository = new Mock<IErrorLogRepository>();
                        errorLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ErrorLog()));

                        var validator = new ApiErrorLogRequestModelValidator(errorLogRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>227de79db5622a08efdcdf6f1cb514e2</Hash>
</Codenesium>*/