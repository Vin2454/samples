using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Chain")]
	[Trait("Area", "Services")]
	public partial class ChainServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			var records = new List<Chain>();
			records.Add(new Chain());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ChainModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			List<ApiChainResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			var record = new Chain();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ChainModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			ApiChainResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Chain>(null));
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ChainModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			ApiChainResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			var model = new ApiChainRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Chain>())).Returns(Task.FromResult(new Chain()));
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ChainModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			CreateResponse<ApiChainResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ChainModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiChainRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Chain>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			var model = new ApiChainRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Chain>())).Returns(Task.FromResult(new Chain()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Chain()));
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ChainModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			UpdateResponse<ApiChainResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ChainModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiChainRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Chain>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			var model = new ApiChainRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ChainModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ChainModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByExternalId_Exists()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			var record = new Chain();
			mock.RepositoryMock.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ChainModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			ApiChainResponseModel response = await service.ByExternalId(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByExternalId(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByExternalId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			mock.RepositoryMock.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<Chain>(null));
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ChainModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			ApiChainResponseModel response = await service.ByExternalId(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByExternalId(It.IsAny<Guid>()));
		}

		[Fact]
		public async void LinksByChainId_Exists()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			var records = new List<Link>();
			records.Add(new Link());
			mock.RepositoryMock.Setup(x => x.LinksByChainId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ChainModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			List<ApiLinkResponseModel> response = await service.LinksByChainId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.LinksByChainId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void LinksByChainId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			mock.RepositoryMock.Setup(x => x.LinksByChainId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Link>>(new List<Link>()));
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ChainModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			List<ApiLinkResponseModel> response = await service.LinksByChainId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.LinksByChainId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>3e7c4a711b5dbe40b57425b92204c447</Hash>
</Codenesium>*/