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
        [Trait("Table", "NuGetPackage")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLNuGetPackageActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLNuGetPackageMapper();

                        ApiNuGetPackageRequestModel model = new ApiNuGetPackageRequestModel();

                        model.SetProperties("A", "A", "A", 1, 1, 1, 1, "A");
                        BONuGetPackage response = mapper.MapModelToBO("A", model);

                        response.JSON.Should().Be("A");
                        response.PackageId.Should().Be("A");
                        response.Version.Should().Be("A");
                        response.VersionBuild.Should().Be(1);
                        response.VersionMajor.Should().Be(1);
                        response.VersionMinor.Should().Be(1);
                        response.VersionRevision.Should().Be(1);
                        response.VersionSpecial.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLNuGetPackageMapper();

                        BONuGetPackage bo = new BONuGetPackage();

                        bo.SetProperties("A", "A", "A", "A", 1, 1, 1, 1, "A");
                        ApiNuGetPackageResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.PackageId.Should().Be("A");
                        response.Version.Should().Be("A");
                        response.VersionBuild.Should().Be(1);
                        response.VersionMajor.Should().Be(1);
                        response.VersionMinor.Should().Be(1);
                        response.VersionRevision.Should().Be(1);
                        response.VersionSpecial.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLNuGetPackageMapper();

                        BONuGetPackage bo = new BONuGetPackage();

                        bo.SetProperties("A", "A", "A", "A", 1, 1, 1, 1, "A");
                        List<ApiNuGetPackageResponseModel> response = mapper.MapBOToModel(new List<BONuGetPackage>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>99afcbeb87ff4801b0e4008411693580</Hash>
</Codenesium>*/