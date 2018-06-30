using FileServiceNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FileServiceNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "File")]
        [Trait("Area", "ApiModel")]
        public class TestApiFileModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiFileModelMapper();
                        var model = new ApiFileRequestModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, "A", "A", "A");
                        ApiFileResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.BucketId.Should().Be(1);
                        response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Description.Should().Be("A");
                        response.Expiration.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Extension.Should().Be("A");
                        response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.FileSizeInBytes.Should().Be(1);
                        response.FileTypeId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.Location.Should().Be("A");
                        response.PrivateKey.Should().Be("A");
                        response.PublicKey.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiFileModelMapper();
                        var model = new ApiFileResponseModel();
                        model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, "A", "A", "A");
                        ApiFileRequestModel response = mapper.MapResponseToRequest(model);

                        response.BucketId.Should().Be(1);
                        response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Description.Should().Be("A");
                        response.Expiration.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Extension.Should().Be("A");
                        response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.FileSizeInBytes.Should().Be(1);
                        response.FileTypeId.Should().Be(1);
                        response.Location.Should().Be("A");
                        response.PrivateKey.Should().Be("A");
                        response.PublicKey.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>07c3e3eb52ca582214d3775468b4ebda</Hash>
</Codenesium>*/