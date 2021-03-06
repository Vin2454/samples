using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using Xunit;

namespace TestsNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SchemaBPerson")]
	[Trait("Area", "ApiModel")]
	public class TestApiSchemaBPersonModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiSchemaBPersonModelMapper();
			var model = new ApiSchemaBPersonRequestModel();
			model.SetProperties("A");
			ApiSchemaBPersonResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiSchemaBPersonModelMapper();
			var model = new ApiSchemaBPersonResponseModel();
			model.SetProperties(1, "A");
			ApiSchemaBPersonRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSchemaBPersonModelMapper();
			var model = new ApiSchemaBPersonRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiSchemaBPersonRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSchemaBPersonRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>654b41c7b1e4044fa0367e31f5ee044e</Hash>
</Codenesium>*/