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
        [Trait("Table", "DeploymentHistory")]
        [Trait("Area", "Services")]
        public partial class DeploymentHistoryServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IDeploymentHistoryRepository>();
                        var records = new List<DeploymentHistory>();
                        records.Add(new DeploymentHistory());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new DeploymentHistoryService(mock.LoggerMock.Object,
                                                                   mock.RepositoryMock.Object,
                                                                   mock.ModelValidatorMockFactory.DeploymentHistoryModelValidatorMock.Object,
                                                                   mock.BOLMapperMockFactory.BOLDeploymentHistoryMapperMock,
                                                                   mock.DALMapperMockFactory.DALDeploymentHistoryMapperMock);

                        List<ApiDeploymentHistoryResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IDeploymentHistoryRepository>();
                        var record = new DeploymentHistory();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new DeploymentHistoryService(mock.LoggerMock.Object,
                                                                   mock.RepositoryMock.Object,
                                                                   mock.ModelValidatorMockFactory.DeploymentHistoryModelValidatorMock.Object,
                                                                   mock.BOLMapperMockFactory.BOLDeploymentHistoryMapperMock,
                                                                   mock.DALMapperMockFactory.DALDeploymentHistoryMapperMock);

                        ApiDeploymentHistoryResponseModel response = await service.Get(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IDeploymentHistoryRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<DeploymentHistory>(null));
                        var service = new DeploymentHistoryService(mock.LoggerMock.Object,
                                                                   mock.RepositoryMock.Object,
                                                                   mock.ModelValidatorMockFactory.DeploymentHistoryModelValidatorMock.Object,
                                                                   mock.BOLMapperMockFactory.BOLDeploymentHistoryMapperMock,
                                                                   mock.DALMapperMockFactory.DALDeploymentHistoryMapperMock);

                        ApiDeploymentHistoryResponseModel response = await service.Get(default (string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IDeploymentHistoryRepository>();
                        var model = new ApiDeploymentHistoryRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<DeploymentHistory>())).Returns(Task.FromResult(new DeploymentHistory()));
                        var service = new DeploymentHistoryService(mock.LoggerMock.Object,
                                                                   mock.RepositoryMock.Object,
                                                                   mock.ModelValidatorMockFactory.DeploymentHistoryModelValidatorMock.Object,
                                                                   mock.BOLMapperMockFactory.BOLDeploymentHistoryMapperMock,
                                                                   mock.DALMapperMockFactory.DALDeploymentHistoryMapperMock);

                        CreateResponse<ApiDeploymentHistoryResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.DeploymentHistoryModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDeploymentHistoryRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<DeploymentHistory>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IDeploymentHistoryRepository>();
                        var model = new ApiDeploymentHistoryRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<DeploymentHistory>())).Returns(Task.FromResult(new DeploymentHistory()));
                        var service = new DeploymentHistoryService(mock.LoggerMock.Object,
                                                                   mock.RepositoryMock.Object,
                                                                   mock.ModelValidatorMockFactory.DeploymentHistoryModelValidatorMock.Object,
                                                                   mock.BOLMapperMockFactory.BOLDeploymentHistoryMapperMock,
                                                                   mock.DALMapperMockFactory.DALDeploymentHistoryMapperMock);

                        ActionResponse response = await service.Update(default (string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.DeploymentHistoryModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiDeploymentHistoryRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<DeploymentHistory>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IDeploymentHistoryRepository>();
                        var model = new ApiDeploymentHistoryRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new DeploymentHistoryService(mock.LoggerMock.Object,
                                                                   mock.RepositoryMock.Object,
                                                                   mock.ModelValidatorMockFactory.DeploymentHistoryModelValidatorMock.Object,
                                                                   mock.BOLMapperMockFactory.BOLDeploymentHistoryMapperMock,
                                                                   mock.DALMapperMockFactory.DALDeploymentHistoryMapperMock);

                        ActionResponse response = await service.Delete(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.DeploymentHistoryModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void GetCreated_Exists()
                {
                        var mock = new ServiceMockFacade<IDeploymentHistoryRepository>();
                        var records = new List<DeploymentHistory>();
                        records.Add(new DeploymentHistory());
                        mock.RepositoryMock.Setup(x => x.GetCreated(It.IsAny<DateTimeOffset>())).Returns(Task.FromResult(records));
                        var service = new DeploymentHistoryService(mock.LoggerMock.Object,
                                                                   mock.RepositoryMock.Object,
                                                                   mock.ModelValidatorMockFactory.DeploymentHistoryModelValidatorMock.Object,
                                                                   mock.BOLMapperMockFactory.BOLDeploymentHistoryMapperMock,
                                                                   mock.DALMapperMockFactory.DALDeploymentHistoryMapperMock);

                        List<ApiDeploymentHistoryResponseModel> response = await service.GetCreated(default (DateTimeOffset));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetCreated(It.IsAny<DateTimeOffset>()));
                }

                [Fact]
                public async void GetCreated_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IDeploymentHistoryRepository>();
                        mock.RepositoryMock.Setup(x => x.GetCreated(It.IsAny<DateTimeOffset>())).Returns(Task.FromResult<List<DeploymentHistory>>(new List<DeploymentHistory>()));
                        var service = new DeploymentHistoryService(mock.LoggerMock.Object,
                                                                   mock.RepositoryMock.Object,
                                                                   mock.ModelValidatorMockFactory.DeploymentHistoryModelValidatorMock.Object,
                                                                   mock.BOLMapperMockFactory.BOLDeploymentHistoryMapperMock,
                                                                   mock.DALMapperMockFactory.DALDeploymentHistoryMapperMock);

                        List<ApiDeploymentHistoryResponseModel> response = await service.GetCreated(default (DateTimeOffset));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetCreated(It.IsAny<DateTimeOffset>()));
                }
        }
}

/*<Codenesium>
    <Hash>4b5337a202581bdf264e07194788217b</Hash>
</Codenesium>*/