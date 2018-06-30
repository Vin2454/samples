using FluentAssertions;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "AirTransport")]
        [Trait("Area", "ApiModel")]
        public class TestApiAirTransportModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiAirTransportModelMapper();
                        var model = new ApiAirTransportRequestModel();
                        model.SetProperties("A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        ApiAirTransportResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.AirlineId.Should().Be(1);
                        response.FlightNumber.Should().Be("A");
                        response.HandlerId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.LandDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PipelineStepId.Should().Be(1);
                        response.TakeoffDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiAirTransportModelMapper();
                        var model = new ApiAirTransportResponseModel();
                        model.SetProperties(1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        ApiAirTransportRequestModel response = mapper.MapResponseToRequest(model);

                        response.FlightNumber.Should().Be("A");
                        response.HandlerId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.LandDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PipelineStepId.Should().Be(1);
                        response.TakeoffDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }
        }
}

/*<Codenesium>
    <Hash>07ec57abe97ce2d2694b7f415fac18f6</Hash>
</Codenesium>*/