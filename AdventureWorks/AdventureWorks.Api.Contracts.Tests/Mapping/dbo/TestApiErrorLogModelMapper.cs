using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ErrorLog")]
        [Trait("Area", "ApiModel")]
        public class TestApiErrorLogModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiErrorLogModelMapper();
                        var model = new ApiErrorLogRequestModel();
                        model.SetProperties(1, "A", 1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiErrorLogResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.ErrorLine.Should().Be(1);
                        response.ErrorLogID.Should().Be(1);
                        response.ErrorMessage.Should().Be("A");
                        response.ErrorNumber.Should().Be(1);
                        response.ErrorProcedure.Should().Be("A");
                        response.ErrorSeverity.Should().Be(1);
                        response.ErrorState.Should().Be(1);
                        response.ErrorTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.UserName.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiErrorLogModelMapper();
                        var model = new ApiErrorLogResponseModel();
                        model.SetProperties(1, 1, "A", 1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiErrorLogRequestModel response = mapper.MapResponseToRequest(model);

                        response.ErrorLine.Should().Be(1);
                        response.ErrorMessage.Should().Be("A");
                        response.ErrorNumber.Should().Be(1);
                        response.ErrorProcedure.Should().Be("A");
                        response.ErrorSeverity.Should().Be(1);
                        response.ErrorState.Should().Be(1);
                        response.ErrorTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.UserName.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>801f2e400ae98840581dc86d14d9c312</Hash>
</Codenesium>*/