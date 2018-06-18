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
        [Trait("Table", "ServerTask")]
        [Trait("Area", "Services")]
        public partial class ServerTaskServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IServerTaskRepository>();
                        var records = new List<ServerTask>();
                        records.Add(new ServerTask());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ServerTaskService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLServerTaskMapperMock,
                                                            mock.DALMapperMockFactory.DALServerTaskMapperMock);

                        List<ApiServerTaskResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IServerTaskRepository>();
                        var record = new ServerTask();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new ServerTaskService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLServerTaskMapperMock,
                                                            mock.DALMapperMockFactory.DALServerTaskMapperMock);

                        ApiServerTaskResponseModel response = await service.Get(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IServerTaskRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ServerTask>(null));
                        var service = new ServerTaskService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLServerTaskMapperMock,
                                                            mock.DALMapperMockFactory.DALServerTaskMapperMock);

                        ApiServerTaskResponseModel response = await service.Get(default (string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IServerTaskRepository>();
                        var model = new ApiServerTaskRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ServerTask>())).Returns(Task.FromResult(new ServerTask()));
                        var service = new ServerTaskService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLServerTaskMapperMock,
                                                            mock.DALMapperMockFactory.DALServerTaskMapperMock);

                        CreateResponse<ApiServerTaskResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiServerTaskRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ServerTask>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IServerTaskRepository>();
                        var model = new ApiServerTaskRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ServerTask>())).Returns(Task.FromResult(new ServerTask()));
                        var service = new ServerTaskService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLServerTaskMapperMock,
                                                            mock.DALMapperMockFactory.DALServerTaskMapperMock);

                        ActionResponse response = await service.Update(default (string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiServerTaskRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ServerTask>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IServerTaskRepository>();
                        var model = new ApiServerTaskRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new ServerTaskService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLServerTaskMapperMock,
                                                            mock.DALMapperMockFactory.DALServerTaskMapperMock);

                        ActionResponse response = await service.Delete(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void GetDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId_Exists()
                {
                        var mock = new ServiceMockFacade<IServerTaskRepository>();
                        var records = new List<ServerTask>();
                        records.Add(new ServerTask());
                        mock.RepositoryMock.Setup(x => x.GetDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<Nullable<DateTimeOffset>>(), It.IsAny<Nullable<DateTimeOffset>>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new ServerTaskService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLServerTaskMapperMock,
                                                            mock.DALMapperMockFactory.DALServerTaskMapperMock);

                        List<ApiServerTaskResponseModel> response = await service.GetDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(default (string), default (DateTimeOffset), default (Nullable<DateTimeOffset>), default (Nullable<DateTimeOffset>), default (string), default (string), default (bool), default (bool), default (int), default (string), default (string), default (string), default (string), default (string), default (string), default (string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<Nullable<DateTimeOffset>>(), It.IsAny<Nullable<DateTimeOffset>>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
                }

                [Fact]
                public async void GetDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IServerTaskRepository>();
                        mock.RepositoryMock.Setup(x => x.GetDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<Nullable<DateTimeOffset>>(), It.IsAny<Nullable<DateTimeOffset>>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<List<ServerTask>>(new List<ServerTask>()));
                        var service = new ServerTaskService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLServerTaskMapperMock,
                                                            mock.DALMapperMockFactory.DALServerTaskMapperMock);

                        List<ApiServerTaskResponseModel> response = await service.GetDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(default (string), default (DateTimeOffset), default (Nullable<DateTimeOffset>), default (Nullable<DateTimeOffset>), default (string), default (string), default (bool), default (bool), default (int), default (string), default (string), default (string), default (string), default (string), default (string), default (string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<Nullable<DateTimeOffset>>(), It.IsAny<Nullable<DateTimeOffset>>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
                }

                [Fact]
                public async void GetStateConcurrencyTag_Exists()
                {
                        var mock = new ServiceMockFacade<IServerTaskRepository>();
                        var records = new List<ServerTask>();
                        records.Add(new ServerTask());
                        mock.RepositoryMock.Setup(x => x.GetStateConcurrencyTag(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new ServerTaskService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLServerTaskMapperMock,
                                                            mock.DALMapperMockFactory.DALServerTaskMapperMock);

                        List<ApiServerTaskResponseModel> response = await service.GetStateConcurrencyTag(default (string), default (string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetStateConcurrencyTag(It.IsAny<string>(), It.IsAny<string>()));
                }

                [Fact]
                public async void GetStateConcurrencyTag_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IServerTaskRepository>();
                        mock.RepositoryMock.Setup(x => x.GetStateConcurrencyTag(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<List<ServerTask>>(new List<ServerTask>()));
                        var service = new ServerTaskService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLServerTaskMapperMock,
                                                            mock.DALMapperMockFactory.DALServerTaskMapperMock);

                        List<ApiServerTaskResponseModel> response = await service.GetStateConcurrencyTag(default (string), default (string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetStateConcurrencyTag(It.IsAny<string>(), It.IsAny<string>()));
                }

                [Fact]
                public async void GetNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId_Exists()
                {
                        var mock = new ServiceMockFacade<IServerTaskRepository>();
                        var records = new List<ServerTask>();
                        records.Add(new ServerTask());
                        mock.RepositoryMock.Setup(x => x.GetNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Nullable<DateTimeOffset>>(), It.IsAny<Nullable<DateTimeOffset>>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new ServerTaskService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLServerTaskMapperMock,
                                                            mock.DALMapperMockFactory.DALServerTaskMapperMock);

                        List<ApiServerTaskResponseModel> response = await service.GetNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(default (string), default (string), default (Nullable<DateTimeOffset>), default (Nullable<DateTimeOffset>), default (string), default (bool), default (string), default (string), default (string), default (int), default (string), default (DateTimeOffset), default (string), default (string), default (bool), default (string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Nullable<DateTimeOffset>>(), It.IsAny<Nullable<DateTimeOffset>>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()));
                }

                [Fact]
                public async void GetNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IServerTaskRepository>();
                        mock.RepositoryMock.Setup(x => x.GetNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Nullable<DateTimeOffset>>(), It.IsAny<Nullable<DateTimeOffset>>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>())).Returns(Task.FromResult<List<ServerTask>>(new List<ServerTask>()));
                        var service = new ServerTaskService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLServerTaskMapperMock,
                                                            mock.DALMapperMockFactory.DALServerTaskMapperMock);

                        List<ApiServerTaskResponseModel> response = await service.GetNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(default (string), default (string), default (Nullable<DateTimeOffset>), default (Nullable<DateTimeOffset>), default (string), default (bool), default (string), default (string), default (string), default (int), default (string), default (DateTimeOffset), default (string), default (string), default (bool), default (string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Nullable<DateTimeOffset>>(), It.IsAny<Nullable<DateTimeOffset>>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>ce4c501e09e8b892050503ecbc326d90</Hash>
</Codenesium>*/