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
        [Trait("Table", "Location")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLLocationMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLLocationMapper();
                        ApiLocationRequestModel model = new ApiLocationRequestModel();
                        model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        BOLocation response = mapper.MapModelToBO(1, model);

                        response.Availability.Should().Be(1);
                        response.CostRate.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLLocationMapper();
                        BOLocation bo = new BOLocation();
                        bo.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiLocationResponseModel response = mapper.MapBOToModel(bo);

                        response.Availability.Should().Be(1);
                        response.CostRate.Should().Be(1);
                        response.LocationID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLLocationMapper();
                        BOLocation bo = new BOLocation();
                        bo.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        List<ApiLocationResponseModel> response = mapper.MapBOToModel(new List<BOLocation>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>4de49f2d8933714c75cf7e5d68a2c0f2</Hash>
</Codenesium>*/