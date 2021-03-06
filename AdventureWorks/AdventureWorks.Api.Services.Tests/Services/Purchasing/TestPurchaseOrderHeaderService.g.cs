using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PurchaseOrderHeader")]
	[Trait("Area", "Services")]
	public partial class PurchaseOrderHeaderServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPurchaseOrderHeaderRepository>();
			var records = new List<PurchaseOrderHeader>();
			records.Add(new PurchaseOrderHeader());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PurchaseOrderHeaderService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderDetailMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderDetailMapperMock);

			List<ApiPurchaseOrderHeaderResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPurchaseOrderHeaderRepository>();
			var record = new PurchaseOrderHeader();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PurchaseOrderHeaderService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderDetailMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderDetailMapperMock);

			ApiPurchaseOrderHeaderResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPurchaseOrderHeaderRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PurchaseOrderHeader>(null));
			var service = new PurchaseOrderHeaderService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderDetailMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderDetailMapperMock);

			ApiPurchaseOrderHeaderResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IPurchaseOrderHeaderRepository>();
			var model = new ApiPurchaseOrderHeaderRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PurchaseOrderHeader>())).Returns(Task.FromResult(new PurchaseOrderHeader()));
			var service = new PurchaseOrderHeaderService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderDetailMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderDetailMapperMock);

			CreateResponse<ApiPurchaseOrderHeaderResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPurchaseOrderHeaderRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PurchaseOrderHeader>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IPurchaseOrderHeaderRepository>();
			var model = new ApiPurchaseOrderHeaderRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PurchaseOrderHeader>())).Returns(Task.FromResult(new PurchaseOrderHeader()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PurchaseOrderHeader()));
			var service = new PurchaseOrderHeaderService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderDetailMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderDetailMapperMock);

			UpdateResponse<ApiPurchaseOrderHeaderResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderHeaderRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PurchaseOrderHeader>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IPurchaseOrderHeaderRepository>();
			var model = new ApiPurchaseOrderHeaderRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PurchaseOrderHeaderService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderDetailMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderDetailMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByEmployeeID_Exists()
		{
			var mock = new ServiceMockFacade<IPurchaseOrderHeaderRepository>();
			var records = new List<PurchaseOrderHeader>();
			records.Add(new PurchaseOrderHeader());
			mock.RepositoryMock.Setup(x => x.ByEmployeeID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PurchaseOrderHeaderService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderDetailMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderDetailMapperMock);

			List<ApiPurchaseOrderHeaderResponseModel> response = await service.ByEmployeeID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByEmployeeID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByEmployeeID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPurchaseOrderHeaderRepository>();
			mock.RepositoryMock.Setup(x => x.ByEmployeeID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PurchaseOrderHeader>>(new List<PurchaseOrderHeader>()));
			var service = new PurchaseOrderHeaderService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderDetailMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderDetailMapperMock);

			List<ApiPurchaseOrderHeaderResponseModel> response = await service.ByEmployeeID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByEmployeeID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByVendorID_Exists()
		{
			var mock = new ServiceMockFacade<IPurchaseOrderHeaderRepository>();
			var records = new List<PurchaseOrderHeader>();
			records.Add(new PurchaseOrderHeader());
			mock.RepositoryMock.Setup(x => x.ByVendorID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PurchaseOrderHeaderService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderDetailMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderDetailMapperMock);

			List<ApiPurchaseOrderHeaderResponseModel> response = await service.ByVendorID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByVendorID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByVendorID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPurchaseOrderHeaderRepository>();
			mock.RepositoryMock.Setup(x => x.ByVendorID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PurchaseOrderHeader>>(new List<PurchaseOrderHeader>()));
			var service = new PurchaseOrderHeaderService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderDetailMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderDetailMapperMock);

			List<ApiPurchaseOrderHeaderResponseModel> response = await service.ByVendorID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByVendorID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PurchaseOrderDetailsByPurchaseOrderID_Exists()
		{
			var mock = new ServiceMockFacade<IPurchaseOrderHeaderRepository>();
			var records = new List<PurchaseOrderDetail>();
			records.Add(new PurchaseOrderDetail());
			mock.RepositoryMock.Setup(x => x.PurchaseOrderDetailsByPurchaseOrderID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PurchaseOrderHeaderService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderDetailMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderDetailMapperMock);

			List<ApiPurchaseOrderDetailResponseModel> response = await service.PurchaseOrderDetailsByPurchaseOrderID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PurchaseOrderDetailsByPurchaseOrderID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PurchaseOrderDetailsByPurchaseOrderID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPurchaseOrderHeaderRepository>();
			mock.RepositoryMock.Setup(x => x.PurchaseOrderDetailsByPurchaseOrderID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PurchaseOrderDetail>>(new List<PurchaseOrderDetail>()));
			var service = new PurchaseOrderHeaderService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderDetailMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderDetailMapperMock);

			List<ApiPurchaseOrderDetailResponseModel> response = await service.PurchaseOrderDetailsByPurchaseOrderID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PurchaseOrderDetailsByPurchaseOrderID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>b5d16b169c47780c7337e95e5f78dbf7</Hash>
</Codenesium>*/