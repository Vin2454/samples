using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "CountryRegion")]
        [Trait("Area", "DALMapper")]
        public class TestDALCountryRegionActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALCountryRegionMapper();

                        var bo = new BOCountryRegion();

                        bo.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        CountryRegion response = mapper.MapBOToEF(bo);

                        response.CountryRegionCode.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALCountryRegionMapper();

                        CountryRegion entity = new CountryRegion();

                        entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        BOCountryRegion  response = mapper.MapEFToBO(entity);

                        response.CountryRegionCode.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALCountryRegionMapper();

                        CountryRegion entity = new CountryRegion();

                        entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        List<BOCountryRegion> response = mapper.MapEFToBO(new List<CountryRegion>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>a5479b533d9091266d723418d3ce2aaf</Hash>
</Codenesium>*/