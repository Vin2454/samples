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
        [Trait("Table", "ProjectGroup")]
        [Trait("Area", "Services")]
        public partial class ProjectGroupServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IProjectGroupRepository>();
                        var records = new List<ProjectGroup>();
                        records.Add(new ProjectGroup());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ProjectGroupService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProjectGroupModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProjectGroupMapperMock,
                                                              mock.DALMapperMockFactory.DALProjectGroupMapperMock);

                        List<ApiProjectGroupResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IProjectGroupRepository>();
                        var record = new ProjectGroup();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new ProjectGroupService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProjectGroupModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProjectGroupMapperMock,
                                                              mock.DALMapperMockFactory.DALProjectGroupMapperMock);

                        ApiProjectGroupResponseModel response = await service.Get(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IProjectGroupRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ProjectGroup>(null));
                        var service = new ProjectGroupService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProjectGroupModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProjectGroupMapperMock,
                                                              mock.DALMapperMockFactory.DALProjectGroupMapperMock);

                        ApiProjectGroupResponseModel response = await service.Get(default (string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IProjectGroupRepository>();
                        var model = new ApiProjectGroupRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProjectGroup>())).Returns(Task.FromResult(new ProjectGroup()));
                        var service = new ProjectGroupService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProjectGroupModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProjectGroupMapperMock,
                                                              mock.DALMapperMockFactory.DALProjectGroupMapperMock);

                        CreateResponse<ApiProjectGroupResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ProjectGroupModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProjectGroupRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ProjectGroup>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IProjectGroupRepository>();
                        var model = new ApiProjectGroupRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProjectGroup>())).Returns(Task.FromResult(new ProjectGroup()));
                        var service = new ProjectGroupService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProjectGroupModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProjectGroupMapperMock,
                                                              mock.DALMapperMockFactory.DALProjectGroupMapperMock);

                        ActionResponse response = await service.Update(default (string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ProjectGroupModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiProjectGroupRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ProjectGroup>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IProjectGroupRepository>();
                        var model = new ApiProjectGroupRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new ProjectGroupService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProjectGroupModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProjectGroupMapperMock,
                                                              mock.DALMapperMockFactory.DALProjectGroupMapperMock);

                        ActionResponse response = await service.Delete(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.ProjectGroupModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void GetName_Exists()
                {
                        var mock = new ServiceMockFacade<IProjectGroupRepository>();
                        var record = new ProjectGroup();

                        mock.RepositoryMock.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new ProjectGroupService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProjectGroupModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProjectGroupMapperMock,
                                                              mock.DALMapperMockFactory.DALProjectGroupMapperMock);

                        ApiProjectGroupResponseModel response = await service.GetName(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.GetName(It.IsAny<string>()));
                }

                [Fact]
                public async void GetName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IProjectGroupRepository>();
                        mock.RepositoryMock.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<ProjectGroup>(null));
                        var service = new ProjectGroupService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProjectGroupModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProjectGroupMapperMock,
                                                              mock.DALMapperMockFactory.DALProjectGroupMapperMock);

                        ApiProjectGroupResponseModel response = await service.GetName(default (string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.GetName(It.IsAny<string>()));
                }

                [Fact]
                public async void GetDataVersion_Exists()
                {
                        var mock = new ServiceMockFacade<IProjectGroupRepository>();
                        var records = new List<ProjectGroup>();
                        records.Add(new ProjectGroup());
                        mock.RepositoryMock.Setup(x => x.GetDataVersion(It.IsAny<byte[]>())).Returns(Task.FromResult(records));
                        var service = new ProjectGroupService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProjectGroupModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProjectGroupMapperMock,
                                                              mock.DALMapperMockFactory.DALProjectGroupMapperMock);

                        List<ApiProjectGroupResponseModel> response = await service.GetDataVersion(default (byte[]));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetDataVersion(It.IsAny<byte[]>()));
                }

                [Fact]
                public async void GetDataVersion_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IProjectGroupRepository>();
                        mock.RepositoryMock.Setup(x => x.GetDataVersion(It.IsAny<byte[]>())).Returns(Task.FromResult<List<ProjectGroup>>(new List<ProjectGroup>()));
                        var service = new ProjectGroupService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.ProjectGroupModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLProjectGroupMapperMock,
                                                              mock.DALMapperMockFactory.DALProjectGroupMapperMock);

                        List<ApiProjectGroupResponseModel> response = await service.GetDataVersion(default (byte[]));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetDataVersion(It.IsAny<byte[]>()));
                }
        }
}

/*<Codenesium>
    <Hash>e35161efda352e626cb57c2934215383</Hash>
</Codenesium>*/