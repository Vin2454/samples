using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductDescription")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLProductDescriptionMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLProductDescriptionMapper();
			ApiProductDescriptionRequestModel model = new ApiProductDescriptionRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			BOProductDescription response = mapper.MapModelToBO(1, model);

			response.Description.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLProductDescriptionMapper();
			BOProductDescription bo = new BOProductDescription();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiProductDescriptionResponseModel response = mapper.MapBOToModel(bo);

			response.Description.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductDescriptionID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLProductDescriptionMapper();
			BOProductDescription bo = new BOProductDescription();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			List<ApiProductDescriptionResponseModel> response = mapper.MapBOToModel(new List<BOProductDescription>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>dbdb407efa793f9dac01fa9ce8e9fc93</Hash>
</Codenesium>*/