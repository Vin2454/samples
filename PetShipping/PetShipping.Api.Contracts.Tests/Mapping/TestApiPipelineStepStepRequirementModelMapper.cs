using FluentAssertions;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PipelineStepStepRequirement")]
        [Trait("Area", "ApiModel")]
        public class TestApiPipelineStepStepRequirementModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiPipelineStepStepRequirementModelMapper();
                        var model = new ApiPipelineStepStepRequirementRequestModel();
                        model.SetProperties("A", 1, true);
                        ApiPipelineStepStepRequirementResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Details.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.PipelineStepId.Should().Be(1);
                        response.RequirementMet.Should().Be(true);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiPipelineStepStepRequirementModelMapper();
                        var model = new ApiPipelineStepStepRequirementResponseModel();
                        model.SetProperties(1, "A", 1, true);
                        ApiPipelineStepStepRequirementRequestModel response = mapper.MapResponseToRequest(model);

                        response.Details.Should().Be("A");
                        response.PipelineStepId.Should().Be(1);
                        response.RequirementMet.Should().Be(true);
                }
        }
}

/*<Codenesium>
    <Hash>585b2917ba3563296898ba284c515312</Hash>
</Codenesium>*/