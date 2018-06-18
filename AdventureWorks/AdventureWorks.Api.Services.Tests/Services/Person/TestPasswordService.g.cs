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
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Password")]
        [Trait("Area", "Services")]
        public partial class PasswordServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IPasswordRepository>();
                        var records = new List<Password>();
                        records.Add(new Password());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new PasswordService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.PasswordModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                          mock.DALMapperMockFactory.DALPasswordMapperMock);

                        List<ApiPasswordResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IPasswordRepository>();
                        var record = new Password();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new PasswordService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.PasswordModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                          mock.DALMapperMockFactory.DALPasswordMapperMock);

                        ApiPasswordResponseModel response = await service.Get(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IPasswordRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Password>(null));
                        var service = new PasswordService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.PasswordModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                          mock.DALMapperMockFactory.DALPasswordMapperMock);

                        ApiPasswordResponseModel response = await service.Get(default (int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IPasswordRepository>();
                        var model = new ApiPasswordRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Password>())).Returns(Task.FromResult(new Password()));
                        var service = new PasswordService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.PasswordModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                          mock.DALMapperMockFactory.DALPasswordMapperMock);

                        CreateResponse<ApiPasswordResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.PasswordModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPasswordRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Password>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IPasswordRepository>();
                        var model = new ApiPasswordRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Password>())).Returns(Task.FromResult(new Password()));
                        var service = new PasswordService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.PasswordModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                          mock.DALMapperMockFactory.DALPasswordMapperMock);

                        ActionResponse response = await service.Update(default (int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.PasswordModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPasswordRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Password>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IPasswordRepository>();
                        var model = new ApiPasswordRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new PasswordService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.PasswordModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLPasswordMapperMock,
                                                          mock.DALMapperMockFactory.DALPasswordMapperMock);

                        ActionResponse response = await service.Delete(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.PasswordModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>3cefba36abb43f377e1536c25acea69f</Hash>
</Codenesium>*/