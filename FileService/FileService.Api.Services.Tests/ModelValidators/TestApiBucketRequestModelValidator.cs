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
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Bucket")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiBucketRequestModelValidatorTest
        {
                public ApiBucketRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IBucketRepository> bucketRepository = new Mock<IBucketRepository>();
                        bucketRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Bucket()));

                        var validator = new ApiBucketRequestModelValidator(bucketRepository.Object);

                        await validator.ValidateCreateAsync(new ApiBucketRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IBucketRepository> bucketRepository = new Mock<IBucketRepository>();
                        bucketRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Bucket()));

                        var validator = new ApiBucketRequestModelValidator(bucketRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiBucketRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IBucketRepository> bucketRepository = new Mock<IBucketRepository>();
                        bucketRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Bucket()));

                        var validator = new ApiBucketRequestModelValidator(bucketRepository.Object);

                        await validator.ValidateCreateAsync(new ApiBucketRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 256));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IBucketRepository> bucketRepository = new Mock<IBucketRepository>();
                        bucketRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Bucket()));

                        var validator = new ApiBucketRequestModelValidator(bucketRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiBucketRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 256));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IBucketRepository> bucketRepository = new Mock<IBucketRepository>();
                        bucketRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Bucket()));

                        var validator = new ApiBucketRequestModelValidator(bucketRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueGetExternalId_Create_Exists()
                {
                        Mock<IBucketRepository> bucketRepository = new Mock<IBucketRepository>();
                        bucketRepository.Setup(x => x.GetExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<Bucket>(new Bucket()));
                        var validator = new ApiBucketRequestModelValidator(bucketRepository.Object);

                        await validator.ValidateCreateAsync(new ApiBucketRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                private async void BeUniqueGetExternalId_Create_Not_Exists()
                {
                        Mock<IBucketRepository> bucketRepository = new Mock<IBucketRepository>();
                        bucketRepository.Setup(x => x.GetExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<Bucket>(null));
                        var validator = new ApiBucketRequestModelValidator(bucketRepository.Object);

                        await validator.ValidateCreateAsync(new ApiBucketRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                private async void BeUniqueGetExternalId_Update_Exists()
                {
                        Mock<IBucketRepository> bucketRepository = new Mock<IBucketRepository>();
                        bucketRepository.Setup(x => x.GetExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<Bucket>(new Bucket()));
                        var validator = new ApiBucketRequestModelValidator(bucketRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiBucketRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                private async void BeUniqueGetExternalId_Update_Not_Exists()
                {
                        Mock<IBucketRepository> bucketRepository = new Mock<IBucketRepository>();
                        bucketRepository.Setup(x => x.GetExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<Bucket>(null));
                        var validator = new ApiBucketRequestModelValidator(bucketRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiBucketRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }
        }
}

/*<Codenesium>
    <Hash>daa73ff3f4ad6d5175b8de40134c5b0a</Hash>
</Codenesium>*/