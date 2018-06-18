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
        [Trait("Table", "UserRole")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLUserRoleActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLUserRoleMapper();

                        ApiUserRoleRequestModel model = new ApiUserRoleRequestModel();

                        model.SetProperties("A", "A");
                        BOUserRole response = mapper.MapModelToBO("A", model);

                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLUserRoleMapper();

                        BOUserRole bo = new BOUserRole();

                        bo.SetProperties("A", "A", "A");
                        ApiUserRoleResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLUserRoleMapper();

                        BOUserRole bo = new BOUserRole();

                        bo.SetProperties("A", "A", "A");
                        List<ApiUserRoleResponseModel> response = mapper.MapBOToModel(new List<BOUserRole>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>04dc506549cefb8661ab88641a516f1a</Hash>
</Codenesium>*/