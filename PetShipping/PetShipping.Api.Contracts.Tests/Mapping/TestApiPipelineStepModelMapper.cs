using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStep")]
	[Trait("Area", "ApiModel")]
	public class TestApiPipelineStepModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiPipelineStepModelMapper();
			var model = new ApiPipelineStepRequestModel();
			model.SetProperties("A", 1, 1);
			ApiPipelineStepResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.PipelineStepStatusId.Should().Be(1);
			response.ShipperId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiPipelineStepModelMapper();
			var model = new ApiPipelineStepResponseModel();
			model.SetProperties(1, "A", 1, 1);
			ApiPipelineStepRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
			response.PipelineStepStatusId.Should().Be(1);
			response.ShipperId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPipelineStepModelMapper();
			var model = new ApiPipelineStepRequestModel();
			model.SetProperties("A", 1, 1);

			JsonPatchDocument<ApiPipelineStepRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPipelineStepRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
			response.PipelineStepStatusId.Should().Be(1);
			response.ShipperId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>42cd60fc2f36977335eef4fcfe759dff</Hash>
</Codenesium>*/