using FluentAssertions;
using NebulaNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "LinkLog")]
        [Trait("Area", "ApiModel")]
        public class TestApiLinkLogModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiLinkLogModelMapper();
                        var model = new ApiLinkLogRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
                        ApiLinkLogResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.DateEntered.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Id.Should().Be(1);
                        response.LinkId.Should().Be(1);
                        response.Log.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiLinkLogModelMapper();
                        var model = new ApiLinkLogResponseModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
                        ApiLinkLogRequestModel response = mapper.MapResponseToRequest(model);

                        response.DateEntered.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.LinkId.Should().Be(1);
                        response.Log.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>9241821870539721da42e05d27c35843</Hash>
</Codenesium>*/