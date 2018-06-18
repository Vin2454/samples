using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;

namespace FermataFishNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Family")]
        [Trait("Area", "DALMapper")]
        public class TestDALFamilyActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALFamilyMapper();

                        var bo = new BOFamily();

                        bo.SetProperties(1, "A", "A", "A", "A", "A", 1);

                        Family response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.Notes.Should().Be("A");
                        response.PcEmail.Should().Be("A");
                        response.PcFirstName.Should().Be("A");
                        response.PcLastName.Should().Be("A");
                        response.PcPhone.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALFamilyMapper();

                        Family entity = new Family();

                        entity.SetProperties(1, "A", "A", "A", "A", "A", 1);

                        BOFamily  response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.Notes.Should().Be("A");
                        response.PcEmail.Should().Be("A");
                        response.PcFirstName.Should().Be("A");
                        response.PcLastName.Should().Be("A");
                        response.PcPhone.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALFamilyMapper();

                        Family entity = new Family();

                        entity.SetProperties(1, "A", "A", "A", "A", "A", 1);

                        List<BOFamily> response = mapper.MapEFToBO(new List<Family>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>7069abc04099d0fff4fbe307eae2f59a</Hash>
</Codenesium>*/