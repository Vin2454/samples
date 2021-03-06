using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SalesTerritoryHistory")]
	[Trait("Area", "ApiModel")]
	public class TestApiSalesTerritoryHistoryModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiSalesTerritoryHistoryModelMapper();
			var model = new ApiSalesTerritoryHistoryRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiSalesTerritoryHistoryResponseModel response = mapper.MapRequestToResponse(1, model);

			response.BusinessEntityID.Should().Be(1);
			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TerritoryID.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiSalesTerritoryHistoryModelMapper();
			var model = new ApiSalesTerritoryHistoryResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiSalesTerritoryHistoryRequestModel response = mapper.MapResponseToRequest(model);

			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TerritoryID.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSalesTerritoryHistoryModelMapper();
			var model = new ApiSalesTerritoryHistoryRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1);

			JsonPatchDocument<ApiSalesTerritoryHistoryRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSalesTerritoryHistoryRequestModel();
			patch.ApplyTo(response);
			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TerritoryID.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ae27f8a1e0bb5734d1e2c3f0da8d1571</Hash>
</Codenesium>*/