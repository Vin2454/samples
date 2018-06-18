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
        [Trait("Table", "Artifact")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiArtifactRequestModelValidatorTest
        {
                public ApiArtifactRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void EnvironmentId_Create_length()
                {
                        Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
                        artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

                        var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);

                        await validator.ValidateCreateAsync(new ApiArtifactRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, new string('A', 51));
                }

                [Fact]
                public async void EnvironmentId_Update_length()
                {
                        Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
                        artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

                        var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiArtifactRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, new string('A', 51));
                }

                [Fact]
                public async void EnvironmentId_Delete()
                {
                        Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
                        artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

                        var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Filename_Create_null()
                {
                        Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
                        artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

                        var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);

                        await validator.ValidateCreateAsync(new ApiArtifactRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Filename, null as string);
                }

                [Fact]
                public async void Filename_Update_null()
                {
                        Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
                        artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

                        var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiArtifactRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Filename, null as string);
                }

                [Fact]
                public async void Filename_Create_length()
                {
                        Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
                        artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

                        var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);

                        await validator.ValidateCreateAsync(new ApiArtifactRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Filename, new string('A', 201));
                }

                [Fact]
                public async void Filename_Update_length()
                {
                        Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
                        artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

                        var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiArtifactRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Filename, new string('A', 201));
                }

                [Fact]
                public async void Filename_Delete()
                {
                        Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
                        artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

                        var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
                        artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

                        var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);

                        await validator.ValidateCreateAsync(new ApiArtifactRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
                        artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

                        var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiArtifactRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void ProjectId_Create_length()
                {
                        Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
                        artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

                        var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);

                        await validator.ValidateCreateAsync(new ApiArtifactRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, new string('A', 51));
                }

                [Fact]
                public async void ProjectId_Update_length()
                {
                        Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
                        artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

                        var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiArtifactRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, new string('A', 51));
                }

                [Fact]
                public async void ProjectId_Delete()
                {
                        Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
                        artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

                        var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void RelatedDocumentIds_Create_null()
                {
                        Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
                        artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

                        var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);

                        await validator.ValidateCreateAsync(new ApiArtifactRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.RelatedDocumentIds, null as string);
                }

                [Fact]
                public async void RelatedDocumentIds_Update_null()
                {
                        Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
                        artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

                        var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiArtifactRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.RelatedDocumentIds, null as string);
                }

                [Fact]
                public async void TenantId_Create_length()
                {
                        Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
                        artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

                        var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);

                        await validator.ValidateCreateAsync(new ApiArtifactRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TenantId, new string('A', 51));
                }

                [Fact]
                public async void TenantId_Update_length()
                {
                        Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
                        artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

                        var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiArtifactRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TenantId, new string('A', 51));
                }

                [Fact]
                public async void TenantId_Delete()
                {
                        Mock<IArtifactRepository> artifactRepository = new Mock<IArtifactRepository>();
                        artifactRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Artifact()));

                        var validator = new ApiArtifactRequestModelValidator(artifactRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>e38bf3255266b49a7abb00ca9d7419ba</Hash>
</Codenesium>*/