using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "TagSet")]
        [Trait("Area", "DALMapper")]
        public class TestDALTagSetActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALTagSetMapper();

                        var bo = new BOTagSet();

                        bo.SetProperties("A", BitConverter.GetBytes(1), "A", "A", 1);

                        TagSet response = mapper.MapBOToEF(bo);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.SortOrder.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALTagSetMapper();

                        TagSet entity = new TagSet();

                        entity.SetProperties(BitConverter.GetBytes(1), "A", "A", "A", 1);

                        BOTagSet  response = mapper.MapEFToBO(entity);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.SortOrder.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALTagSetMapper();

                        TagSet entity = new TagSet();

                        entity.SetProperties(BitConverter.GetBytes(1), "A", "A", "A", 1);

                        List<BOTagSet> response = mapper.MapEFToBO(new List<TagSet>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>63d1690cc48e879ed5d791894f809dc1</Hash>
</Codenesium>*/