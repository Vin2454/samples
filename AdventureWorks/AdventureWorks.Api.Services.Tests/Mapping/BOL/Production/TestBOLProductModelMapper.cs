using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ProductModel")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLProductModelActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLProductModelMapper();

                        ApiProductModelRequestModel model = new ApiProductModelRequestModel();

                        model.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        BOProductModel response = mapper.MapModelToBO(1, model);

                        response.CatalogDescription.Should().Be("A");
                        response.Instructions.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLProductModelMapper();

                        BOProductModel bo = new BOProductModel();

                        bo.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        ApiProductModelResponseModel response = mapper.MapBOToModel(bo);

                        response.CatalogDescription.Should().Be("A");
                        response.Instructions.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.ProductModelID.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLProductModelMapper();

                        BOProductModel bo = new BOProductModel();

                        bo.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        List<ApiProductModelResponseModel> response = mapper.MapBOToModel(new List<BOProductModel>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>303a3ce7d277bcb4c07c84fbba16c2ba</Hash>
</Codenesium>*/