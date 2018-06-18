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
        [Trait("Table", "Worker")]
        [Trait("Area", "Services")]
        public partial class WorkerServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IWorkerRepository>();
                        var records = new List<Worker>();
                        records.Add(new Worker());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new WorkerService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.WorkerModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLWorkerMapperMock,
                                                        mock.DALMapperMockFactory.DALWorkerMapperMock);

                        List<ApiWorkerResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IWorkerRepository>();
                        var record = new Worker();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new WorkerService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.WorkerModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLWorkerMapperMock,
                                                        mock.DALMapperMockFactory.DALWorkerMapperMock);

                        ApiWorkerResponseModel response = await service.Get(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IWorkerRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<Worker>(null));
                        var service = new WorkerService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.WorkerModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLWorkerMapperMock,
                                                        mock.DALMapperMockFactory.DALWorkerMapperMock);

                        ApiWorkerResponseModel response = await service.Get(default (string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IWorkerRepository>();
                        var model = new ApiWorkerRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Worker>())).Returns(Task.FromResult(new Worker()));
                        var service = new WorkerService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.WorkerModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLWorkerMapperMock,
                                                        mock.DALMapperMockFactory.DALWorkerMapperMock);

                        CreateResponse<ApiWorkerResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.WorkerModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiWorkerRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Worker>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IWorkerRepository>();
                        var model = new ApiWorkerRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Worker>())).Returns(Task.FromResult(new Worker()));
                        var service = new WorkerService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.WorkerModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLWorkerMapperMock,
                                                        mock.DALMapperMockFactory.DALWorkerMapperMock);

                        ActionResponse response = await service.Update(default (string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.WorkerModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiWorkerRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Worker>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IWorkerRepository>();
                        var model = new ApiWorkerRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new WorkerService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.WorkerModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLWorkerMapperMock,
                                                        mock.DALMapperMockFactory.DALWorkerMapperMock);

                        ActionResponse response = await service.Delete(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.WorkerModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void GetName_Exists()
                {
                        var mock = new ServiceMockFacade<IWorkerRepository>();
                        var record = new Worker();

                        mock.RepositoryMock.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new WorkerService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.WorkerModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLWorkerMapperMock,
                                                        mock.DALMapperMockFactory.DALWorkerMapperMock);

                        ApiWorkerResponseModel response = await service.GetName(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.GetName(It.IsAny<string>()));
                }

                [Fact]
                public async void GetName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IWorkerRepository>();
                        mock.RepositoryMock.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Worker>(null));
                        var service = new WorkerService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.WorkerModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLWorkerMapperMock,
                                                        mock.DALMapperMockFactory.DALWorkerMapperMock);

                        ApiWorkerResponseModel response = await service.GetName(default (string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.GetName(It.IsAny<string>()));
                }

                [Fact]
                public async void GetMachinePolicyId_Exists()
                {
                        var mock = new ServiceMockFacade<IWorkerRepository>();
                        var records = new List<Worker>();
                        records.Add(new Worker());
                        mock.RepositoryMock.Setup(x => x.GetMachinePolicyId(It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new WorkerService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.WorkerModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLWorkerMapperMock,
                                                        mock.DALMapperMockFactory.DALWorkerMapperMock);

                        List<ApiWorkerResponseModel> response = await service.GetMachinePolicyId(default (string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetMachinePolicyId(It.IsAny<string>()));
                }

                [Fact]
                public async void GetMachinePolicyId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IWorkerRepository>();
                        mock.RepositoryMock.Setup(x => x.GetMachinePolicyId(It.IsAny<string>())).Returns(Task.FromResult<List<Worker>>(new List<Worker>()));
                        var service = new WorkerService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.WorkerModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLWorkerMapperMock,
                                                        mock.DALMapperMockFactory.DALWorkerMapperMock);

                        List<ApiWorkerResponseModel> response = await service.GetMachinePolicyId(default (string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetMachinePolicyId(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>37d00c48b839ffa45b06b66f66381bda</Hash>
</Codenesium>*/