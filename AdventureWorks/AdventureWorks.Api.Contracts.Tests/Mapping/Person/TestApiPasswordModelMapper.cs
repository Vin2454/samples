using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Password")]
        [Trait("Area", "ApiModel")]
        public class TestApiPasswordModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiPasswordModelMapper();
                        var model = new ApiPasswordRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        ApiPasswordResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.BusinessEntityID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PasswordHash.Should().Be("A");
                        response.PasswordSalt.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiPasswordModelMapper();
                        var model = new ApiPasswordResponseModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        ApiPasswordRequestModel response = mapper.MapResponseToRequest(model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PasswordHash.Should().Be("A");
                        response.PasswordSalt.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiPasswordModelMapper();
                        var model = new ApiPasswordRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        JsonPatchDocument<ApiPasswordRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiPasswordRequestModel();
                        patch.ApplyTo(response);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PasswordHash.Should().Be("A");
                        response.PasswordSalt.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }
        }
}

/*<Codenesium>
    <Hash>305949a372e36fcf53e7e7ca350da54a</Hash>
</Codenesium>*/