using ESPIOTNS.Api.Contracts;
using FluentAssertions;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ESPIOTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Area", "Includes")]
	public partial class ServiceIncludesTests
	{
		[Fact]
		public void Test_ValidationError()
		{
			var error = new ValidationError("1", "error", "field1");
			error.ErrorCode.Should().Be("1");
			error.ErrorMessage.Should().Be("error");
			error.PropertyName.Should().Be("field1");
		}

		[Fact]
		public void ActionResponse_Error()
		{
			var failures = new List<ValidationFailure>();
			failures.Add(new ValidationFailure("field1", "error"));
			var result = new ValidationResult(failures);
			var response = new ActionResponse(result);
			response.Success.Should().BeFalse();
			response.ValidationErrors.Count.Should().Be(1);
		}

		[Fact]
		public void ActionResponse_No_Error()
		{
			var failures = new List<ValidationFailure>();
			var result = new ValidationResult(failures);
			var response = new ActionResponse(result);
			response.Success.Should().BeTrue();
		}

		[Fact]
		public void CreateResponse_Error()
		{
			var failures = new List<ValidationFailure>();
			failures.Add(new ValidationFailure("field1", "error"));
			var result = new ValidationResult(failures);
			CreateResponse<int> response = new CreateResponse<int>(result);
			response.Success.Should().BeFalse();
			response.ValidationErrors.Count.Should().Be(1);
		}

		[Fact]
		public void CreateResponse_No_Error()
		{
			var failures = new List<ValidationFailure>();
			ValidationResult result = new ValidationResult(failures);
			CreateResponse<int> response = new CreateResponse<int>(result);
			response.Success.Should().BeTrue();
		}

		[Fact]
		public void CreateResponse_SetRecord()
		{
			List<ValidationFailure> failures = new List<ValidationFailure>();
			ValidationResult result = new ValidationResult(failures);

			var item = new
			{
				id = 1
			};

			CreateResponse<object> response = new CreateResponse<object>(result);
			response.SetRecord(item);
			response.Record.Should().NotBeNull();
		}
	}
}

/*<Codenesium>
    <Hash>7007e1da0ddcaa04cf3d2559eeb7e24d</Hash>
</Codenesium>*/