using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostHistoryType")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPostHistoryTypeRequestModelValidatorTest
	{
		public ApiPostHistoryTypeRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Type_Create_null()
		{
			Mock<IPostHistoryTypeRepository> postHistoryTypeRepository = new Mock<IPostHistoryTypeRepository>();
			postHistoryTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistoryType()));

			var validator = new ApiPostHistoryTypeRequestModelValidator(postHistoryTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostHistoryTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, null as string);
		}

		[Fact]
		public async void Type_Update_null()
		{
			Mock<IPostHistoryTypeRepository> postHistoryTypeRepository = new Mock<IPostHistoryTypeRepository>();
			postHistoryTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistoryType()));

			var validator = new ApiPostHistoryTypeRequestModelValidator(postHistoryTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostHistoryTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, null as string);
		}

		[Fact]
		public async void Type_Create_length()
		{
			Mock<IPostHistoryTypeRepository> postHistoryTypeRepository = new Mock<IPostHistoryTypeRepository>();
			postHistoryTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistoryType()));

			var validator = new ApiPostHistoryTypeRequestModelValidator(postHistoryTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostHistoryTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, new string('A', 51));
		}

		[Fact]
		public async void Type_Update_length()
		{
			Mock<IPostHistoryTypeRepository> postHistoryTypeRepository = new Mock<IPostHistoryTypeRepository>();
			postHistoryTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistoryType()));

			var validator = new ApiPostHistoryTypeRequestModelValidator(postHistoryTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostHistoryTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>894941c257b06d143e225df902d96531</Hash>
</Codenesium>*/