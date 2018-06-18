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
        [Trait("Table", "LibraryVariableSet")]
        [Trait("Area", "Services")]
        public partial class LibraryVariableSetServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ILibraryVariableSetRepository>();
                        var records = new List<LibraryVariableSet>();
                        records.Add(new LibraryVariableSet());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new LibraryVariableSetService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.LibraryVariableSetModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLLibraryVariableSetMapperMock,
                                                                    mock.DALMapperMockFactory.DALLibraryVariableSetMapperMock);

                        List<ApiLibraryVariableSetResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ILibraryVariableSetRepository>();
                        var record = new LibraryVariableSet();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new LibraryVariableSetService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.LibraryVariableSetModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLLibraryVariableSetMapperMock,
                                                                    mock.DALMapperMockFactory.DALLibraryVariableSetMapperMock);

                        ApiLibraryVariableSetResponseModel response = await service.Get(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ILibraryVariableSetRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<LibraryVariableSet>(null));
                        var service = new LibraryVariableSetService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.LibraryVariableSetModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLLibraryVariableSetMapperMock,
                                                                    mock.DALMapperMockFactory.DALLibraryVariableSetMapperMock);

                        ApiLibraryVariableSetResponseModel response = await service.Get(default (string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ILibraryVariableSetRepository>();
                        var model = new ApiLibraryVariableSetRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LibraryVariableSet>())).Returns(Task.FromResult(new LibraryVariableSet()));
                        var service = new LibraryVariableSetService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.LibraryVariableSetModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLLibraryVariableSetMapperMock,
                                                                    mock.DALMapperMockFactory.DALLibraryVariableSetMapperMock);

                        CreateResponse<ApiLibraryVariableSetResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.LibraryVariableSetModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLibraryVariableSetRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<LibraryVariableSet>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ILibraryVariableSetRepository>();
                        var model = new ApiLibraryVariableSetRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LibraryVariableSet>())).Returns(Task.FromResult(new LibraryVariableSet()));
                        var service = new LibraryVariableSetService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.LibraryVariableSetModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLLibraryVariableSetMapperMock,
                                                                    mock.DALMapperMockFactory.DALLibraryVariableSetMapperMock);

                        ActionResponse response = await service.Update(default (string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.LibraryVariableSetModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiLibraryVariableSetRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<LibraryVariableSet>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ILibraryVariableSetRepository>();
                        var model = new ApiLibraryVariableSetRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new LibraryVariableSetService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.LibraryVariableSetModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLLibraryVariableSetMapperMock,
                                                                    mock.DALMapperMockFactory.DALLibraryVariableSetMapperMock);

                        ActionResponse response = await service.Delete(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.LibraryVariableSetModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void GetName_Exists()
                {
                        var mock = new ServiceMockFacade<ILibraryVariableSetRepository>();
                        var record = new LibraryVariableSet();

                        mock.RepositoryMock.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new LibraryVariableSetService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.LibraryVariableSetModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLLibraryVariableSetMapperMock,
                                                                    mock.DALMapperMockFactory.DALLibraryVariableSetMapperMock);

                        ApiLibraryVariableSetResponseModel response = await service.GetName(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.GetName(It.IsAny<string>()));
                }

                [Fact]
                public async void GetName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ILibraryVariableSetRepository>();
                        mock.RepositoryMock.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<LibraryVariableSet>(null));
                        var service = new LibraryVariableSetService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.LibraryVariableSetModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLLibraryVariableSetMapperMock,
                                                                    mock.DALMapperMockFactory.DALLibraryVariableSetMapperMock);

                        ApiLibraryVariableSetResponseModel response = await service.GetName(default (string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.GetName(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>568892cc9e675ffd7ce4c5b262d99a46</Hash>
</Codenesium>*/