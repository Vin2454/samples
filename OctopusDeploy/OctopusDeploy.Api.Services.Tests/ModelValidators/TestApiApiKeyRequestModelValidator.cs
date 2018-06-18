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
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ApiKey")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiApiKeyRequestModelValidatorTest
        {
                public ApiApiKeyRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void ApiKeyHashed_Create_null()
                {
                        Mock<IApiKeyRepository> apiKeyRepository = new Mock<IApiKeyRepository>();
                        apiKeyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiKey()));

                        var validator = new ApiApiKeyRequestModelValidator(apiKeyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiApiKeyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ApiKeyHashed, null as string);
                }

                [Fact]
                public async void ApiKeyHashed_Update_null()
                {
                        Mock<IApiKeyRepository> apiKeyRepository = new Mock<IApiKeyRepository>();
                        apiKeyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiKey()));

                        var validator = new ApiApiKeyRequestModelValidator(apiKeyRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiApiKeyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ApiKeyHashed, null as string);
                }

                [Fact]
                public async void ApiKeyHashed_Create_length()
                {
                        Mock<IApiKeyRepository> apiKeyRepository = new Mock<IApiKeyRepository>();
                        apiKeyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiKey()));

                        var validator = new ApiApiKeyRequestModelValidator(apiKeyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiApiKeyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ApiKeyHashed, new string('A', 201));
                }

                [Fact]
                public async void ApiKeyHashed_Update_length()
                {
                        Mock<IApiKeyRepository> apiKeyRepository = new Mock<IApiKeyRepository>();
                        apiKeyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiKey()));

                        var validator = new ApiApiKeyRequestModelValidator(apiKeyRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiApiKeyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ApiKeyHashed, new string('A', 201));
                }

                [Fact]
                public async void ApiKeyHashed_Delete()
                {
                        Mock<IApiKeyRepository> apiKeyRepository = new Mock<IApiKeyRepository>();
                        apiKeyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiKey()));

                        var validator = new ApiApiKeyRequestModelValidator(apiKeyRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IApiKeyRepository> apiKeyRepository = new Mock<IApiKeyRepository>();
                        apiKeyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiKey()));

                        var validator = new ApiApiKeyRequestModelValidator(apiKeyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiApiKeyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IApiKeyRepository> apiKeyRepository = new Mock<IApiKeyRepository>();
                        apiKeyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiKey()));

                        var validator = new ApiApiKeyRequestModelValidator(apiKeyRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiApiKeyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void UserId_Create_null()
                {
                        Mock<IApiKeyRepository> apiKeyRepository = new Mock<IApiKeyRepository>();
                        apiKeyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiKey()));

                        var validator = new ApiApiKeyRequestModelValidator(apiKeyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiApiKeyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.UserId, null as string);
                }

                [Fact]
                public async void UserId_Update_null()
                {
                        Mock<IApiKeyRepository> apiKeyRepository = new Mock<IApiKeyRepository>();
                        apiKeyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiKey()));

                        var validator = new ApiApiKeyRequestModelValidator(apiKeyRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiApiKeyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.UserId, null as string);
                }

                [Fact]
                public async void UserId_Create_length()
                {
                        Mock<IApiKeyRepository> apiKeyRepository = new Mock<IApiKeyRepository>();
                        apiKeyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiKey()));

                        var validator = new ApiApiKeyRequestModelValidator(apiKeyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiApiKeyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.UserId, new string('A', 51));
                }

                [Fact]
                public async void UserId_Update_length()
                {
                        Mock<IApiKeyRepository> apiKeyRepository = new Mock<IApiKeyRepository>();
                        apiKeyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiKey()));

                        var validator = new ApiApiKeyRequestModelValidator(apiKeyRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiApiKeyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.UserId, new string('A', 51));
                }

                [Fact]
                public async void UserId_Delete()
                {
                        Mock<IApiKeyRepository> apiKeyRepository = new Mock<IApiKeyRepository>();
                        apiKeyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiKey()));

                        var validator = new ApiApiKeyRequestModelValidator(apiKeyRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueGetApiKeyHashed_Create_Exists()
                {
                        Mock<IApiKeyRepository> apiKeyRepository = new Mock<IApiKeyRepository>();
                        apiKeyRepository.Setup(x => x.GetApiKeyHashed(It.IsAny<string>())).Returns(Task.FromResult<ApiKey>(new ApiKey()));
                        var validator = new ApiApiKeyRequestModelValidator(apiKeyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiApiKeyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ApiKeyHashed, "A");
                }

                [Fact]
                private async void BeUniqueGetApiKeyHashed_Create_Not_Exists()
                {
                        Mock<IApiKeyRepository> apiKeyRepository = new Mock<IApiKeyRepository>();
                        apiKeyRepository.Setup(x => x.GetApiKeyHashed(It.IsAny<string>())).Returns(Task.FromResult<ApiKey>(null));
                        var validator = new ApiApiKeyRequestModelValidator(apiKeyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiApiKeyRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ApiKeyHashed, "A");
                }

                [Fact]
                private async void BeUniqueGetApiKeyHashed_Update_Exists()
                {
                        Mock<IApiKeyRepository> apiKeyRepository = new Mock<IApiKeyRepository>();
                        apiKeyRepository.Setup(x => x.GetApiKeyHashed(It.IsAny<string>())).Returns(Task.FromResult<ApiKey>(new ApiKey()));
                        var validator = new ApiApiKeyRequestModelValidator(apiKeyRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiApiKeyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ApiKeyHashed, "A");
                }

                [Fact]
                private async void BeUniqueGetApiKeyHashed_Update_Not_Exists()
                {
                        Mock<IApiKeyRepository> apiKeyRepository = new Mock<IApiKeyRepository>();
                        apiKeyRepository.Setup(x => x.GetApiKeyHashed(It.IsAny<string>())).Returns(Task.FromResult<ApiKey>(null));
                        var validator = new ApiApiKeyRequestModelValidator(apiKeyRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiApiKeyRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ApiKeyHashed, "A");
                }
        }
}

/*<Codenesium>
    <Hash>9cfbfdc4324251b942c13a0a8f338f31</Hash>
</Codenesium>*/