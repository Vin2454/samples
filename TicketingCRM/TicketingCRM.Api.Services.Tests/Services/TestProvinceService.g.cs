using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Province")]
	[Trait("Area", "Services")]
	public partial class ProvinceServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IProvinceRepository>();
			var records = new List<Province>();
			records.Add(new Province());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCityMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.BOLMapperMockFactory.BOLVenueMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiProvinceResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IProvinceRepository>();
			var record = new Province();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCityMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.BOLMapperMockFactory.BOLVenueMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			ApiProvinceResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IProvinceRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Province>(null));
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCityMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.BOLMapperMockFactory.BOLVenueMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			ApiProvinceResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IProvinceRepository>();
			var model = new ApiProvinceRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Province>())).Returns(Task.FromResult(new Province()));
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCityMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.BOLMapperMockFactory.BOLVenueMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			CreateResponse<ApiProvinceResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProvinceRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Province>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IProvinceRepository>();
			var model = new ApiProvinceRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Province>())).Returns(Task.FromResult(new Province()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Province()));
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCityMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.BOLMapperMockFactory.BOLVenueMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			UpdateResponse<ApiProvinceResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProvinceRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Province>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IProvinceRepository>();
			var model = new ApiProvinceRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCityMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.BOLMapperMockFactory.BOLVenueMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByCountryId_Exists()
		{
			var mock = new ServiceMockFacade<IProvinceRepository>();
			var records = new List<Province>();
			records.Add(new Province());
			mock.RepositoryMock.Setup(x => x.ByCountryId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCityMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.BOLMapperMockFactory.BOLVenueMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiProvinceResponseModel> response = await service.ByCountryId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByCountryId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByCountryId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProvinceRepository>();
			mock.RepositoryMock.Setup(x => x.ByCountryId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Province>>(new List<Province>()));
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCityMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.BOLMapperMockFactory.BOLVenueMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiProvinceResponseModel> response = await service.ByCountryId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByCountryId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CitiesByProvinceId_Exists()
		{
			var mock = new ServiceMockFacade<IProvinceRepository>();
			var records = new List<City>();
			records.Add(new City());
			mock.RepositoryMock.Setup(x => x.CitiesByProvinceId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCityMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.BOLMapperMockFactory.BOLVenueMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiCityResponseModel> response = await service.CitiesByProvinceId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.CitiesByProvinceId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CitiesByProvinceId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProvinceRepository>();
			mock.RepositoryMock.Setup(x => x.CitiesByProvinceId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<City>>(new List<City>()));
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCityMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.BOLMapperMockFactory.BOLVenueMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiCityResponseModel> response = await service.CitiesByProvinceId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.CitiesByProvinceId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void VenuesByProvinceId_Exists()
		{
			var mock = new ServiceMockFacade<IProvinceRepository>();
			var records = new List<Venue>();
			records.Add(new Venue());
			mock.RepositoryMock.Setup(x => x.VenuesByProvinceId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCityMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.BOLMapperMockFactory.BOLVenueMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiVenueResponseModel> response = await service.VenuesByProvinceId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.VenuesByProvinceId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void VenuesByProvinceId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProvinceRepository>();
			mock.RepositoryMock.Setup(x => x.VenuesByProvinceId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Venue>>(new List<Venue>()));
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCityMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.BOLMapperMockFactory.BOLVenueMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiVenueResponseModel> response = await service.VenuesByProvinceId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.VenuesByProvinceId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>a96c0e26d743cd75bc3d741aa8681b2c</Hash>
</Codenesium>*/