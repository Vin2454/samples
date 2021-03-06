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
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TestAllFieldTypesNullable")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiTestAllFieldTypesNullableRequestModelValidatorTest
	{
		public ApiTestAllFieldTypesNullableRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void FieldBinary_Create_length()
		{
			Mock<ITestAllFieldTypesNullableRepository> testAllFieldTypesNullableRepository = new Mock<ITestAllFieldTypesNullableRepository>();
			testAllFieldTypesNullableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));

			var validator = new ApiTestAllFieldTypesNullableRequestModelValidator(testAllFieldTypesNullableRepository.Object);
			await validator.ValidateCreateAsync(new ApiTestAllFieldTypesNullableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldBinary, new byte[51]);
		}

		[Fact]
		public async void FieldBinary_Update_length()
		{
			Mock<ITestAllFieldTypesNullableRepository> testAllFieldTypesNullableRepository = new Mock<ITestAllFieldTypesNullableRepository>();
			testAllFieldTypesNullableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));

			var validator = new ApiTestAllFieldTypesNullableRequestModelValidator(testAllFieldTypesNullableRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTestAllFieldTypesNullableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldBinary, new byte[51]);
		}

		[Fact]
		public async void FieldChar_Create_length()
		{
			Mock<ITestAllFieldTypesNullableRepository> testAllFieldTypesNullableRepository = new Mock<ITestAllFieldTypesNullableRepository>();
			testAllFieldTypesNullableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));

			var validator = new ApiTestAllFieldTypesNullableRequestModelValidator(testAllFieldTypesNullableRepository.Object);
			await validator.ValidateCreateAsync(new ApiTestAllFieldTypesNullableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldChar, new string('A', 11));
		}

		[Fact]
		public async void FieldChar_Update_length()
		{
			Mock<ITestAllFieldTypesNullableRepository> testAllFieldTypesNullableRepository = new Mock<ITestAllFieldTypesNullableRepository>();
			testAllFieldTypesNullableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));

			var validator = new ApiTestAllFieldTypesNullableRequestModelValidator(testAllFieldTypesNullableRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTestAllFieldTypesNullableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldChar, new string('A', 11));
		}

		[Fact]
		public async void FieldNChar_Create_length()
		{
			Mock<ITestAllFieldTypesNullableRepository> testAllFieldTypesNullableRepository = new Mock<ITestAllFieldTypesNullableRepository>();
			testAllFieldTypesNullableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));

			var validator = new ApiTestAllFieldTypesNullableRequestModelValidator(testAllFieldTypesNullableRepository.Object);
			await validator.ValidateCreateAsync(new ApiTestAllFieldTypesNullableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldNChar, new string('A', 11));
		}

		[Fact]
		public async void FieldNChar_Update_length()
		{
			Mock<ITestAllFieldTypesNullableRepository> testAllFieldTypesNullableRepository = new Mock<ITestAllFieldTypesNullableRepository>();
			testAllFieldTypesNullableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));

			var validator = new ApiTestAllFieldTypesNullableRequestModelValidator(testAllFieldTypesNullableRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTestAllFieldTypesNullableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldNChar, new string('A', 11));
		}

		[Fact]
		public async void FieldNVarchar_Create_length()
		{
			Mock<ITestAllFieldTypesNullableRepository> testAllFieldTypesNullableRepository = new Mock<ITestAllFieldTypesNullableRepository>();
			testAllFieldTypesNullableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));

			var validator = new ApiTestAllFieldTypesNullableRequestModelValidator(testAllFieldTypesNullableRepository.Object);
			await validator.ValidateCreateAsync(new ApiTestAllFieldTypesNullableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldNVarchar, new string('A', 51));
		}

		[Fact]
		public async void FieldNVarchar_Update_length()
		{
			Mock<ITestAllFieldTypesNullableRepository> testAllFieldTypesNullableRepository = new Mock<ITestAllFieldTypesNullableRepository>();
			testAllFieldTypesNullableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));

			var validator = new ApiTestAllFieldTypesNullableRequestModelValidator(testAllFieldTypesNullableRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTestAllFieldTypesNullableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldNVarchar, new string('A', 51));
		}

		[Fact]
		public async void FieldVarBinary_Create_length()
		{
			Mock<ITestAllFieldTypesNullableRepository> testAllFieldTypesNullableRepository = new Mock<ITestAllFieldTypesNullableRepository>();
			testAllFieldTypesNullableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));

			var validator = new ApiTestAllFieldTypesNullableRequestModelValidator(testAllFieldTypesNullableRepository.Object);
			await validator.ValidateCreateAsync(new ApiTestAllFieldTypesNullableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldVarBinary, new byte[51]);
		}

		[Fact]
		public async void FieldVarBinary_Update_length()
		{
			Mock<ITestAllFieldTypesNullableRepository> testAllFieldTypesNullableRepository = new Mock<ITestAllFieldTypesNullableRepository>();
			testAllFieldTypesNullableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));

			var validator = new ApiTestAllFieldTypesNullableRequestModelValidator(testAllFieldTypesNullableRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTestAllFieldTypesNullableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldVarBinary, new byte[51]);
		}

		[Fact]
		public async void FieldVarchar_Create_length()
		{
			Mock<ITestAllFieldTypesNullableRepository> testAllFieldTypesNullableRepository = new Mock<ITestAllFieldTypesNullableRepository>();
			testAllFieldTypesNullableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));

			var validator = new ApiTestAllFieldTypesNullableRequestModelValidator(testAllFieldTypesNullableRepository.Object);
			await validator.ValidateCreateAsync(new ApiTestAllFieldTypesNullableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldVarchar, new string('A', 51));
		}

		[Fact]
		public async void FieldVarchar_Update_length()
		{
			Mock<ITestAllFieldTypesNullableRepository> testAllFieldTypesNullableRepository = new Mock<ITestAllFieldTypesNullableRepository>();
			testAllFieldTypesNullableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));

			var validator = new ApiTestAllFieldTypesNullableRequestModelValidator(testAllFieldTypesNullableRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTestAllFieldTypesNullableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldVarchar, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>5fe3bf372d24b8fd10dc347dfdd7c556</Hash>
</Codenesium>*/