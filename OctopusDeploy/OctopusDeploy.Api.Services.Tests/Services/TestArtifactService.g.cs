using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Artifact")]
        [Trait("Area", "Services")]
        public partial class ArtifactServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IArtifactRepository>();
                        var records = new List<Artifact>();
                        records.Add(new Artifact());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ArtifactService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.ArtifactModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLArtifactMapperMock,
                                                          mock.DALMapperMockFactory.DALArtifactMapperMock);

                        List<ApiArtifactResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IArtifactRepository>();
                        var record = new Artifact();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new ArtifactService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.ArtifactModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLArtifactMapperMock,
                                                          mock.DALMapperMockFactory.DALArtifactMapperMock);

                        ApiArtifactResponseModel response = await service.Get(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IArtifactRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<Artifact>(null));
                        var service = new ArtifactService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.ArtifactModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLArtifactMapperMock,
                                                          mock.DALMapperMockFactory.DALArtifactMapperMock);

                        ApiArtifactResponseModel response = await service.Get(default (string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IArtifactRepository>();
                        var model = new ApiArtifactRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Artifact>())).Returns(Task.FromResult(new Artifact()));
                        var service = new ArtifactService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.ArtifactModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLArtifactMapperMock,
                                                          mock.DALMapperMockFactory.DALArtifactMapperMock);

                        CreateResponse<ApiArtifactResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ArtifactModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiArtifactRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Artifact>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IArtifactRepository>();
                        var model = new ApiArtifactRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Artifact>())).Returns(Task.FromResult(new Artifact()));
                        var service = new ArtifactService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.ArtifactModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLArtifactMapperMock,
                                                          mock.DALMapperMockFactory.DALArtifactMapperMock);

                        ActionResponse response = await service.Update(default (string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ArtifactModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiArtifactRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Artifact>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IArtifactRepository>();
                        var model = new ApiArtifactRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new ArtifactService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.ArtifactModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLArtifactMapperMock,
                                                          mock.DALMapperMockFactory.DALArtifactMapperMock);

                        ActionResponse response = await service.Delete(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.ArtifactModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void GetTenantId_Exists()
                {
                        var mock = new ServiceMockFacade<IArtifactRepository>();
                        var records = new List<Artifact>();
                        records.Add(new Artifact());
                        mock.RepositoryMock.Setup(x => x.GetTenantId(It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new ArtifactService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.ArtifactModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLArtifactMapperMock,
                                                          mock.DALMapperMockFactory.DALArtifactMapperMock);

                        List<ApiArtifactResponseModel> response = await service.GetTenantId(default (string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetTenantId(It.IsAny<string>()));
                }

                [Fact]
                public async void GetTenantId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IArtifactRepository>();
                        mock.RepositoryMock.Setup(x => x.GetTenantId(It.IsAny<string>())).Returns(Task.FromResult<List<Artifact>>(new List<Artifact>()));
                        var service = new ArtifactService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.ArtifactModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLArtifactMapperMock,
                                                          mock.DALMapperMockFactory.DALArtifactMapperMock);

                        List<ApiArtifactResponseModel> response = await service.GetTenantId(default (string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetTenantId(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>5e6b266377513911671e951ae4ff3a75</Hash>
</Codenesium>*/