using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStatu")]
	[Trait("Area", "Services")]
	public partial class PipelineStatuServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPipelineStatuRepository>();
			var records = new List<PipelineStatu>();
			records.Add(new PipelineStatu());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PipelineStatuService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.PipelineStatuModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLPipelineStatuMapperMock,
			                                       mock.DALMapperMockFactory.DALPipelineStatuMapperMock,
			                                       mock.BOLMapperMockFactory.BOLPipelineMapperMock,
			                                       mock.DALMapperMockFactory.DALPipelineMapperMock);

			List<ApiPipelineStatuResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPipelineStatuRepository>();
			var record = new PipelineStatu();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PipelineStatuService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.PipelineStatuModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLPipelineStatuMapperMock,
			                                       mock.DALMapperMockFactory.DALPipelineStatuMapperMock,
			                                       mock.BOLMapperMockFactory.BOLPipelineMapperMock,
			                                       mock.DALMapperMockFactory.DALPipelineMapperMock);

			ApiPipelineStatuResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPipelineStatuRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PipelineStatu>(null));
			var service = new PipelineStatuService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.PipelineStatuModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLPipelineStatuMapperMock,
			                                       mock.DALMapperMockFactory.DALPipelineStatuMapperMock,
			                                       mock.BOLMapperMockFactory.BOLPipelineMapperMock,
			                                       mock.DALMapperMockFactory.DALPipelineMapperMock);

			ApiPipelineStatuResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IPipelineStatuRepository>();
			var model = new ApiPipelineStatuRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStatu>())).Returns(Task.FromResult(new PipelineStatu()));
			var service = new PipelineStatuService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.PipelineStatuModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLPipelineStatuMapperMock,
			                                       mock.DALMapperMockFactory.DALPipelineStatuMapperMock,
			                                       mock.BOLMapperMockFactory.BOLPipelineMapperMock,
			                                       mock.DALMapperMockFactory.DALPipelineMapperMock);

			CreateResponse<ApiPipelineStatuResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PipelineStatuModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStatuRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PipelineStatu>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IPipelineStatuRepository>();
			var model = new ApiPipelineStatuRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStatu>())).Returns(Task.FromResult(new PipelineStatu()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStatu()));
			var service = new PipelineStatuService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.PipelineStatuModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLPipelineStatuMapperMock,
			                                       mock.DALMapperMockFactory.DALPipelineStatuMapperMock,
			                                       mock.BOLMapperMockFactory.BOLPipelineMapperMock,
			                                       mock.DALMapperMockFactory.DALPipelineMapperMock);

			UpdateResponse<ApiPipelineStatuResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PipelineStatuModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStatuRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PipelineStatu>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IPipelineStatuRepository>();
			var model = new ApiPipelineStatuRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PipelineStatuService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.PipelineStatuModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLPipelineStatuMapperMock,
			                                       mock.DALMapperMockFactory.DALPipelineStatuMapperMock,
			                                       mock.BOLMapperMockFactory.BOLPipelineMapperMock,
			                                       mock.DALMapperMockFactory.DALPipelineMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PipelineStatuModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void PipelinesByPipelineStatusId_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStatuRepository>();
			var records = new List<Pipeline>();
			records.Add(new Pipeline());
			mock.RepositoryMock.Setup(x => x.PipelinesByPipelineStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PipelineStatuService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.PipelineStatuModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLPipelineStatuMapperMock,
			                                       mock.DALMapperMockFactory.DALPipelineStatuMapperMock,
			                                       mock.BOLMapperMockFactory.BOLPipelineMapperMock,
			                                       mock.DALMapperMockFactory.DALPipelineMapperMock);

			List<ApiPipelineResponseModel> response = await service.PipelinesByPipelineStatusId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelinesByPipelineStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PipelinesByPipelineStatusId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStatuRepository>();
			mock.RepositoryMock.Setup(x => x.PipelinesByPipelineStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Pipeline>>(new List<Pipeline>()));
			var service = new PipelineStatuService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.PipelineStatuModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLPipelineStatuMapperMock,
			                                       mock.DALMapperMockFactory.DALPipelineStatuMapperMock,
			                                       mock.BOLMapperMockFactory.BOLPipelineMapperMock,
			                                       mock.DALMapperMockFactory.DALPipelineMapperMock);

			List<ApiPipelineResponseModel> response = await service.PipelinesByPipelineStatusId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelinesByPipelineStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>b32ef0eacea4f192f3ce10041d8b93ac</Hash>
</Codenesium>*/