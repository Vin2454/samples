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
	[Trait("Table", "Space")]
	[Trait("Area", "Services")]
	public partial class SpaceServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISpaceRepository>();
			var records = new List<Space>();
			records.Add(new Space());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SpaceService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceMapperMock);

			List<ApiSpaceResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISpaceRepository>();
			var record = new Space();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SpaceService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceMapperMock);

			ApiSpaceResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISpaceRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Space>(null));
			var service = new SpaceService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceMapperMock);

			ApiSpaceResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ISpaceRepository>();
			var model = new ApiSpaceRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Space>())).Returns(Task.FromResult(new Space()));
			var service = new SpaceService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceMapperMock);

			CreateResponse<ApiSpaceResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSpaceRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Space>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ISpaceRepository>();
			var model = new ApiSpaceRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Space>())).Returns(Task.FromResult(new Space()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));
			var service = new SpaceService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceMapperMock);

			UpdateResponse<ApiSpaceResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpaceRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Space>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ISpaceRepository>();
			var model = new ApiSpaceRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SpaceService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>f4163014216d61ac379deb17e87509df</Hash>
</Codenesium>*/