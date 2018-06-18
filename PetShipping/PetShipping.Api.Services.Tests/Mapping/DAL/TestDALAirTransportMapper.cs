using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "AirTransport")]
        [Trait("Area", "DALMapper")]
        public class TestDALAirTransportActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALAirTransportMapper();

                        var bo = new BOAirTransport();

                        bo.SetProperties(1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        AirTransport response = mapper.MapBOToEF(bo);

                        response.AirlineId.Should().Be(1);
                        response.FlightNumber.Should().Be("A");
                        response.HandlerId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.LandDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PipelineStepId.Should().Be(1);
                        response.TakeoffDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALAirTransportMapper();

                        AirTransport entity = new AirTransport();

                        entity.SetProperties(1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        BOAirTransport  response = mapper.MapEFToBO(entity);

                        response.AirlineId.Should().Be(1);
                        response.FlightNumber.Should().Be("A");
                        response.HandlerId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.LandDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PipelineStepId.Should().Be(1);
                        response.TakeoffDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALAirTransportMapper();

                        AirTransport entity = new AirTransport();

                        entity.SetProperties(1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        List<BOAirTransport> response = mapper.MapEFToBO(new List<AirTransport>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>5ab3f9f71533eb2176884fa8a97e1a2b</Hash>
</Codenesium>*/