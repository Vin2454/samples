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
        [Trait("Table", "TagSet")]
        [Trait("Area", "Services")]
        public partial class TagSetServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ITagSetRepository>();
                        var records = new List<TagSet>();
                        records.Add(new TagSet());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new TagSetService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TagSetModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTagSetMapperMock,
                                                        mock.DALMapperMockFactory.DALTagSetMapperMock);

                        List<ApiTagSetResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ITagSetRepository>();
                        var record = new TagSet();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new TagSetService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TagSetModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTagSetMapperMock,
                                                        mock.DALMapperMockFactory.DALTagSetMapperMock);

                        ApiTagSetResponseModel response = await service.Get(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ITagSetRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<TagSet>(null));
                        var service = new TagSetService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TagSetModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTagSetMapperMock,
                                                        mock.DALMapperMockFactory.DALTagSetMapperMock);

                        ApiTagSetResponseModel response = await service.Get(default (string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ITagSetRepository>();
                        var model = new ApiTagSetRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TagSet>())).Returns(Task.FromResult(new TagSet()));
                        var service = new TagSetService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TagSetModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTagSetMapperMock,
                                                        mock.DALMapperMockFactory.DALTagSetMapperMock);

                        CreateResponse<ApiTagSetResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.TagSetModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTagSetRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<TagSet>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ITagSetRepository>();
                        var model = new ApiTagSetRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TagSet>())).Returns(Task.FromResult(new TagSet()));
                        var service = new TagSetService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TagSetModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTagSetMapperMock,
                                                        mock.DALMapperMockFactory.DALTagSetMapperMock);

                        ActionResponse response = await service.Update(default (string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.TagSetModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiTagSetRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<TagSet>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ITagSetRepository>();
                        var model = new ApiTagSetRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new TagSetService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TagSetModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTagSetMapperMock,
                                                        mock.DALMapperMockFactory.DALTagSetMapperMock);

                        ActionResponse response = await service.Delete(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.TagSetModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void GetName_Exists()
                {
                        var mock = new ServiceMockFacade<ITagSetRepository>();
                        var record = new TagSet();

                        mock.RepositoryMock.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new TagSetService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TagSetModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTagSetMapperMock,
                                                        mock.DALMapperMockFactory.DALTagSetMapperMock);

                        ApiTagSetResponseModel response = await service.GetName(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.GetName(It.IsAny<string>()));
                }

                [Fact]
                public async void GetName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ITagSetRepository>();
                        mock.RepositoryMock.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<TagSet>(null));
                        var service = new TagSetService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TagSetModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTagSetMapperMock,
                                                        mock.DALMapperMockFactory.DALTagSetMapperMock);

                        ApiTagSetResponseModel response = await service.GetName(default (string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.GetName(It.IsAny<string>()));
                }

                [Fact]
                public async void GetDataVersion_Exists()
                {
                        var mock = new ServiceMockFacade<ITagSetRepository>();
                        var records = new List<TagSet>();
                        records.Add(new TagSet());
                        mock.RepositoryMock.Setup(x => x.GetDataVersion(It.IsAny<byte[]>())).Returns(Task.FromResult(records));
                        var service = new TagSetService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TagSetModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTagSetMapperMock,
                                                        mock.DALMapperMockFactory.DALTagSetMapperMock);

                        List<ApiTagSetResponseModel> response = await service.GetDataVersion(default (byte[]));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetDataVersion(It.IsAny<byte[]>()));
                }

                [Fact]
                public async void GetDataVersion_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ITagSetRepository>();
                        mock.RepositoryMock.Setup(x => x.GetDataVersion(It.IsAny<byte[]>())).Returns(Task.FromResult<List<TagSet>>(new List<TagSet>()));
                        var service = new TagSetService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TagSetModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTagSetMapperMock,
                                                        mock.DALMapperMockFactory.DALTagSetMapperMock);

                        List<ApiTagSetResponseModel> response = await service.GetDataVersion(default (byte[]));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetDataVersion(It.IsAny<byte[]>()));
                }
        }
}

/*<Codenesium>
    <Hash>a8e825b3408299cb4f191373162d2a36</Hash>
</Codenesium>*/