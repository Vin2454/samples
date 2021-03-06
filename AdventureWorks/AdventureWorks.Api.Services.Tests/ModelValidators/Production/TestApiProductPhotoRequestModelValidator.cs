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
	[Trait("Table", "ProductPhoto")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiProductPhotoRequestModelValidatorTest
	{
		public ApiProductPhotoRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void LargePhotoFileName_Create_length()
		{
			Mock<IProductPhotoRepository> productPhotoRepository = new Mock<IProductPhotoRepository>();
			productPhotoRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductPhoto()));

			var validator = new ApiProductPhotoRequestModelValidator(productPhotoRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductPhotoRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LargePhotoFileName, new string('A', 51));
		}

		[Fact]
		public async void LargePhotoFileName_Update_length()
		{
			Mock<IProductPhotoRepository> productPhotoRepository = new Mock<IProductPhotoRepository>();
			productPhotoRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductPhoto()));

			var validator = new ApiProductPhotoRequestModelValidator(productPhotoRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductPhotoRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LargePhotoFileName, new string('A', 51));
		}

		[Fact]
		public async void ThumbnailPhotoFileName_Create_length()
		{
			Mock<IProductPhotoRepository> productPhotoRepository = new Mock<IProductPhotoRepository>();
			productPhotoRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductPhoto()));

			var validator = new ApiProductPhotoRequestModelValidator(productPhotoRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductPhotoRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ThumbnailPhotoFileName, new string('A', 51));
		}

		[Fact]
		public async void ThumbnailPhotoFileName_Update_length()
		{
			Mock<IProductPhotoRepository> productPhotoRepository = new Mock<IProductPhotoRepository>();
			productPhotoRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductPhoto()));

			var validator = new ApiProductPhotoRequestModelValidator(productPhotoRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductPhotoRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ThumbnailPhotoFileName, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>75cc3db7815d0fe000d07c40ff7953b0</Hash>
</Codenesium>*/