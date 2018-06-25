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
        [Trait("Table", "ProductSubcategory")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLProductSubcategoryMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLProductSubcategoryMapper();
                        ApiProductSubcategoryRequestModel model = new ApiProductSubcategoryRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        BOProductSubcategory response = mapper.MapModelToBO(1, model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.ProductCategoryID.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLProductSubcategoryMapper();
                        BOProductSubcategory bo = new BOProductSubcategory();
                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        ApiProductSubcategoryResponseModel response = mapper.MapBOToModel(bo);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.ProductCategoryID.Should().Be(1);
                        response.ProductSubcategoryID.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLProductSubcategoryMapper();
                        BOProductSubcategory bo = new BOProductSubcategory();
                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        List<ApiProductSubcategoryResponseModel> response = mapper.MapBOToModel(new List<BOProductSubcategory>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>31354a4b63c32c2dd69eed2e8cbf60e5</Hash>
</Codenesium>*/