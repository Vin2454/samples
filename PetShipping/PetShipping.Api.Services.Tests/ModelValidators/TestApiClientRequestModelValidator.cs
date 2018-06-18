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
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Client")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiClientRequestModelValidatorTest
        {
                public ApiClientRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Email_Create_null()
                {
                        Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
                        clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

                        var validator = new ApiClientRequestModelValidator(clientRepository.Object);

                        await validator.ValidateCreateAsync(new ApiClientRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
                }

                [Fact]
                public async void Email_Update_null()
                {
                        Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
                        clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

                        var validator = new ApiClientRequestModelValidator(clientRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiClientRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
                }

                [Fact]
                public async void Email_Create_length()
                {
                        Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
                        clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

                        var validator = new ApiClientRequestModelValidator(clientRepository.Object);

                        await validator.ValidateCreateAsync(new ApiClientRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
                }

                [Fact]
                public async void Email_Update_length()
                {
                        Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
                        clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

                        var validator = new ApiClientRequestModelValidator(clientRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiClientRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
                }

                [Fact]
                public async void Email_Delete()
                {
                        Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
                        clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

                        var validator = new ApiClientRequestModelValidator(clientRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void FirstName_Create_null()
                {
                        Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
                        clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

                        var validator = new ApiClientRequestModelValidator(clientRepository.Object);

                        await validator.ValidateCreateAsync(new ApiClientRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
                }

                [Fact]
                public async void FirstName_Update_null()
                {
                        Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
                        clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

                        var validator = new ApiClientRequestModelValidator(clientRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiClientRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
                }

                [Fact]
                public async void FirstName_Create_length()
                {
                        Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
                        clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

                        var validator = new ApiClientRequestModelValidator(clientRepository.Object);

                        await validator.ValidateCreateAsync(new ApiClientRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
                }

                [Fact]
                public async void FirstName_Update_length()
                {
                        Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
                        clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

                        var validator = new ApiClientRequestModelValidator(clientRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiClientRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
                }

                [Fact]
                public async void FirstName_Delete()
                {
                        Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
                        clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

                        var validator = new ApiClientRequestModelValidator(clientRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void LastName_Create_null()
                {
                        Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
                        clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

                        var validator = new ApiClientRequestModelValidator(clientRepository.Object);

                        await validator.ValidateCreateAsync(new ApiClientRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
                }

                [Fact]
                public async void LastName_Update_null()
                {
                        Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
                        clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

                        var validator = new ApiClientRequestModelValidator(clientRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiClientRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
                }

                [Fact]
                public async void LastName_Create_length()
                {
                        Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
                        clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

                        var validator = new ApiClientRequestModelValidator(clientRepository.Object);

                        await validator.ValidateCreateAsync(new ApiClientRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
                }

                [Fact]
                public async void LastName_Update_length()
                {
                        Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
                        clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

                        var validator = new ApiClientRequestModelValidator(clientRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiClientRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
                }

                [Fact]
                public async void LastName_Delete()
                {
                        Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
                        clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

                        var validator = new ApiClientRequestModelValidator(clientRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Phone_Create_null()
                {
                        Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
                        clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

                        var validator = new ApiClientRequestModelValidator(clientRepository.Object);

                        await validator.ValidateCreateAsync(new ApiClientRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Phone, null as string);
                }

                [Fact]
                public async void Phone_Update_null()
                {
                        Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
                        clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

                        var validator = new ApiClientRequestModelValidator(clientRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiClientRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Phone, null as string);
                }

                [Fact]
                public async void Phone_Create_length()
                {
                        Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
                        clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

                        var validator = new ApiClientRequestModelValidator(clientRepository.Object);

                        await validator.ValidateCreateAsync(new ApiClientRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 11));
                }

                [Fact]
                public async void Phone_Update_length()
                {
                        Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
                        clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

                        var validator = new ApiClientRequestModelValidator(clientRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiClientRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 11));
                }

                [Fact]
                public async void Phone_Delete()
                {
                        Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
                        clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

                        var validator = new ApiClientRequestModelValidator(clientRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>ff1e3c284d2543c3b210bebb823a047e</Hash>
</Codenesium>*/