using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Deployment")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLDeploymentActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLDeploymentMapper();

                        ApiDeploymentRequestModel model = new ApiDeploymentRequestModel();

                        model.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A", "A", "A", "A", "A");
                        BODeployment response = mapper.MapModelToBO("A", model);

                        response.ChannelId.Should().Be("A");
                        response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.DeployedBy.Should().Be("A");
                        response.DeployedToMachineIds.Should().Be("A");
                        response.EnvironmentId.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectGroupId.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.ReleaseId.Should().Be("A");
                        response.TaskId.Should().Be("A");
                        response.TenantId.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLDeploymentMapper();

                        BODeployment bo = new BODeployment();

                        bo.SetProperties("A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A", "A", "A", "A", "A");
                        ApiDeploymentResponseModel response = mapper.MapBOToModel(bo);

                        response.ChannelId.Should().Be("A");
                        response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.DeployedBy.Should().Be("A");
                        response.DeployedToMachineIds.Should().Be("A");
                        response.EnvironmentId.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectGroupId.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.ReleaseId.Should().Be("A");
                        response.TaskId.Should().Be("A");
                        response.TenantId.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLDeploymentMapper();

                        BODeployment bo = new BODeployment();

                        bo.SetProperties("A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A", "A", "A", "A", "A");
                        List<ApiDeploymentResponseModel> response = mapper.MapBOToModel(new List<BODeployment>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>8782f4f7ecdd29b9b9c9b9fd163b9ab9</Hash>
</Codenesium>*/