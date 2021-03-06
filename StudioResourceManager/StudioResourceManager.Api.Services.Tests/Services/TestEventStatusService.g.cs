using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventStatus")]
	[Trait("Area", "Services")]
	public partial class EventStatusServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IEventStatusRepository>();
			var records = new List<EventStatus>();
			records.Add(new EventStatus());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new EventStatusService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.EventStatusModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                     mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                     mock.DALMapperMockFactory.DALEventMapperMock);

			List<ApiEventStatusResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IEventStatusRepository>();
			var record = new EventStatus();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new EventStatusService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.EventStatusModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                     mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                     mock.DALMapperMockFactory.DALEventMapperMock);

			ApiEventStatusResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IEventStatusRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<EventStatus>(null));
			var service = new EventStatusService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.EventStatusModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                     mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                     mock.DALMapperMockFactory.DALEventMapperMock);

			ApiEventStatusResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IEventStatusRepository>();
			var model = new ApiEventStatusRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<EventStatus>())).Returns(Task.FromResult(new EventStatus()));
			var service = new EventStatusService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.EventStatusModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                     mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                     mock.DALMapperMockFactory.DALEventMapperMock);

			CreateResponse<ApiEventStatusResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.EventStatusModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiEventStatusRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<EventStatus>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IEventStatusRepository>();
			var model = new ApiEventStatusRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<EventStatus>())).Returns(Task.FromResult(new EventStatus()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventStatus()));
			var service = new EventStatusService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.EventStatusModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                     mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                     mock.DALMapperMockFactory.DALEventMapperMock);

			UpdateResponse<ApiEventStatusResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.EventStatusModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEventStatusRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<EventStatus>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IEventStatusRepository>();
			var model = new ApiEventStatusRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new EventStatusService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.EventStatusModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                     mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                     mock.DALMapperMockFactory.DALEventMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.EventStatusModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void EventsByEventStatusId_Exists()
		{
			var mock = new ServiceMockFacade<IEventStatusRepository>();
			var records = new List<Event>();
			records.Add(new Event());
			mock.RepositoryMock.Setup(x => x.EventsByEventStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new EventStatusService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.EventStatusModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                     mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                     mock.DALMapperMockFactory.DALEventMapperMock);

			List<ApiEventResponseModel> response = await service.EventsByEventStatusId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.EventsByEventStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventsByEventStatusId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IEventStatusRepository>();
			mock.RepositoryMock.Setup(x => x.EventsByEventStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Event>>(new List<Event>()));
			var service = new EventStatusService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.EventStatusModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLEventStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALEventStatusMapperMock,
			                                     mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                     mock.DALMapperMockFactory.DALEventMapperMock);

			List<ApiEventResponseModel> response = await service.EventsByEventStatusId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.EventsByEventStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>0e9fd180de621812f80cd02fb1bab527</Hash>
</Codenesium>*/