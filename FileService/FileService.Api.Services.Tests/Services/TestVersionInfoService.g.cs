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
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "VersionInfo")]
        [Trait("Area", "Services")]
        public partial class VersionInfoServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IVersionInfoRepository>();
                        var records = new List<VersionInfo>();
                        records.Add(new VersionInfo());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new VersionInfoService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLVersionInfoMapperMock,
                                                             mock.DALMapperMockFactory.DALVersionInfoMapperMock);

                        List<ApiVersionInfoResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IVersionInfoRepository>();
                        var record = new VersionInfo();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<long>())).Returns(Task.FromResult(record));
                        var service = new VersionInfoService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLVersionInfoMapperMock,
                                                             mock.DALMapperMockFactory.DALVersionInfoMapperMock);

                        ApiVersionInfoResponseModel response = await service.Get(default (long));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<long>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IVersionInfoRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<long>())).Returns(Task.FromResult<VersionInfo>(null));
                        var service = new VersionInfoService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLVersionInfoMapperMock,
                                                             mock.DALMapperMockFactory.DALVersionInfoMapperMock);

                        ApiVersionInfoResponseModel response = await service.Get(default (long));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<long>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IVersionInfoRepository>();
                        var model = new ApiVersionInfoRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VersionInfo>())).Returns(Task.FromResult(new VersionInfo()));
                        var service = new VersionInfoService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLVersionInfoMapperMock,
                                                             mock.DALMapperMockFactory.DALVersionInfoMapperMock);

                        CreateResponse<ApiVersionInfoResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVersionInfoRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<VersionInfo>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IVersionInfoRepository>();
                        var model = new ApiVersionInfoRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VersionInfo>())).Returns(Task.FromResult(new VersionInfo()));
                        var service = new VersionInfoService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLVersionInfoMapperMock,
                                                             mock.DALMapperMockFactory.DALVersionInfoMapperMock);

                        ActionResponse response = await service.Update(default (long), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<long>(), It.IsAny<ApiVersionInfoRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<VersionInfo>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IVersionInfoRepository>();
                        var model = new ApiVersionInfoRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<long>())).Returns(Task.CompletedTask);
                        var service = new VersionInfoService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLVersionInfoMapperMock,
                                                             mock.DALMapperMockFactory.DALVersionInfoMapperMock);

                        ActionResponse response = await service.Delete(default (long));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<long>()));
                        mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<long>()));
                }

                [Fact]
                public async void GetVersion_Exists()
                {
                        var mock = new ServiceMockFacade<IVersionInfoRepository>();
                        var record = new VersionInfo();

                        mock.RepositoryMock.Setup(x => x.GetVersion(It.IsAny<long>())).Returns(Task.FromResult(record));
                        var service = new VersionInfoService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLVersionInfoMapperMock,
                                                             mock.DALMapperMockFactory.DALVersionInfoMapperMock);

                        ApiVersionInfoResponseModel response = await service.GetVersion(default (long));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.GetVersion(It.IsAny<long>()));
                }

                [Fact]
                public async void GetVersion_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IVersionInfoRepository>();
                        mock.RepositoryMock.Setup(x => x.GetVersion(It.IsAny<long>())).Returns(Task.FromResult<VersionInfo>(null));
                        var service = new VersionInfoService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLVersionInfoMapperMock,
                                                             mock.DALMapperMockFactory.DALVersionInfoMapperMock);

                        ApiVersionInfoResponseModel response = await service.GetVersion(default (long));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.GetVersion(It.IsAny<long>()));
                }
        }
}

/*<Codenesium>
    <Hash>c1e67fb53d58cc08b2bc30ad7828faf1</Hash>
</Codenesium>*/