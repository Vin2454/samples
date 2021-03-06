using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
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

namespace FileServiceNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "FileType")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiFileTypeRequestModelValidatorTest
	{
		public ApiFileTypeRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IFileTypeRepository> fileTypeRepository = new Mock<IFileTypeRepository>();
			fileTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new FileType()));

			var validator = new ApiFileTypeRequestModelValidator(fileTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiFileTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IFileTypeRepository> fileTypeRepository = new Mock<IFileTypeRepository>();
			fileTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new FileType()));

			var validator = new ApiFileTypeRequestModelValidator(fileTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiFileTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IFileTypeRepository> fileTypeRepository = new Mock<IFileTypeRepository>();
			fileTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new FileType()));

			var validator = new ApiFileTypeRequestModelValidator(fileTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiFileTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 256));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IFileTypeRepository> fileTypeRepository = new Mock<IFileTypeRepository>();
			fileTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new FileType()));

			var validator = new ApiFileTypeRequestModelValidator(fileTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiFileTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 256));
		}
	}
}

/*<Codenesium>
    <Hash>aba00d77c3dff93a63c0cbfd72aecdc5</Hash>
</Codenesium>*/