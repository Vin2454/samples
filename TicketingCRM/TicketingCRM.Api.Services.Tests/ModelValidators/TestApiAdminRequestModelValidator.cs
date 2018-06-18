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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Admin")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiAdminRequestModelValidatorTest
        {
                public ApiAdminRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Email_Create_null()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAdminRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
                }

                [Fact]
                public async void Email_Update_null()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiAdminRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
                }

                [Fact]
                public async void Email_Create_length()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAdminRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
                }

                [Fact]
                public async void Email_Update_length()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiAdminRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
                }

                [Fact]
                public async void Email_Delete()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void FirstName_Create_null()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAdminRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
                }

                [Fact]
                public async void FirstName_Update_null()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiAdminRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
                }

                [Fact]
                public async void FirstName_Create_length()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAdminRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
                }

                [Fact]
                public async void FirstName_Update_length()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiAdminRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
                }

                [Fact]
                public async void FirstName_Delete()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void LastName_Create_null()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAdminRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
                }

                [Fact]
                public async void LastName_Update_null()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiAdminRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
                }

                [Fact]
                public async void LastName_Create_length()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAdminRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
                }

                [Fact]
                public async void LastName_Update_length()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiAdminRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
                }

                [Fact]
                public async void LastName_Delete()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Password_Create_null()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAdminRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Password, null as string);
                }

                [Fact]
                public async void Password_Update_null()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiAdminRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Password, null as string);
                }

                [Fact]
                public async void Password_Create_length()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAdminRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Password, new string('A', 129));
                }

                [Fact]
                public async void Password_Update_length()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiAdminRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Password, new string('A', 129));
                }

                [Fact]
                public async void Password_Delete()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Phone_Create_null()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAdminRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Phone, null as string);
                }

                [Fact]
                public async void Phone_Update_null()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiAdminRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Phone, null as string);
                }

                [Fact]
                public async void Phone_Create_length()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAdminRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 129));
                }

                [Fact]
                public async void Phone_Update_length()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiAdminRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 129));
                }

                [Fact]
                public async void Phone_Delete()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Username_Create_null()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAdminRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Username, null as string);
                }

                [Fact]
                public async void Username_Update_null()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiAdminRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Username, null as string);
                }

                [Fact]
                public async void Username_Create_length()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAdminRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Username, new string('A', 129));
                }

                [Fact]
                public async void Username_Update_length()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiAdminRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Username, new string('A', 129));
                }

                [Fact]
                public async void Username_Delete()
                {
                        Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
                        adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

                        var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>19bf3689cd0f7f60090081a91b3cc455</Hash>
</Codenesium>*/