using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "AWBuildVersion")]
        [Trait("Area", "DALMapper")]
        public class TestDALAWBuildVersionActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALAWBuildVersionMapper();

                        var bo = new BOAWBuildVersion();

                        bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));

                        AWBuildVersion response = mapper.MapBOToEF(bo);

                        response.Database_Version.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.SystemInformationID.Should().Be(1);
                        response.VersionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALAWBuildVersionMapper();

                        AWBuildVersion entity = new AWBuildVersion();

                        entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        BOAWBuildVersion  response = mapper.MapEFToBO(entity);

                        response.Database_Version.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.SystemInformationID.Should().Be(1);
                        response.VersionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALAWBuildVersionMapper();

                        AWBuildVersion entity = new AWBuildVersion();

                        entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        List<BOAWBuildVersion> response = mapper.MapEFToBO(new List<AWBuildVersion>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>c05ab0754e2a9896d1e788e0de1fca06</Hash>
</Codenesium>*/