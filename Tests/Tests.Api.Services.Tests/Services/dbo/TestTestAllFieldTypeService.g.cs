using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TestAllFieldType")]
	[Trait("Area", "Services")]
	public partial class TestAllFieldTypeServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypeRepository>();
			var records = new List<TestAllFieldType>();
			records.Add(new TestAllFieldType());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TestAllFieldTypeService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTestAllFieldTypeMapperMock,
			                                          mock.DALMapperMockFactory.DALTestAllFieldTypeMapperMock);

			List<ApiTestAllFieldTypeResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypeRepository>();
			var record = new TestAllFieldType();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TestAllFieldTypeService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTestAllFieldTypeMapperMock,
			                                          mock.DALMapperMockFactory.DALTestAllFieldTypeMapperMock);

			ApiTestAllFieldTypeResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypeRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<TestAllFieldType>(null));
			var service = new TestAllFieldTypeService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTestAllFieldTypeMapperMock,
			                                          mock.DALMapperMockFactory.DALTestAllFieldTypeMapperMock);

			ApiTestAllFieldTypeResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypeRepository>();
			var model = new ApiTestAllFieldTypeRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TestAllFieldType>())).Returns(Task.FromResult(new TestAllFieldType()));
			var service = new TestAllFieldTypeService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTestAllFieldTypeMapperMock,
			                                          mock.DALMapperMockFactory.DALTestAllFieldTypeMapperMock);

			CreateResponse<ApiTestAllFieldTypeResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTestAllFieldTypeRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<TestAllFieldType>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypeRepository>();
			var model = new ApiTestAllFieldTypeRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TestAllFieldType>())).Returns(Task.FromResult(new TestAllFieldType()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));
			var service = new TestAllFieldTypeService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTestAllFieldTypeMapperMock,
			                                          mock.DALMapperMockFactory.DALTestAllFieldTypeMapperMock);

			UpdateResponse<ApiTestAllFieldTypeResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypeRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<TestAllFieldType>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypeRepository>();
			var model = new ApiTestAllFieldTypeRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TestAllFieldTypeService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTestAllFieldTypeMapperMock,
			                                          mock.DALMapperMockFactory.DALTestAllFieldTypeMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TestAllFieldTypeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>32cf6170c5a937f983e2cf8591e032e6</Hash>
</Codenesium>*/