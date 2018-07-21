using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Web.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Machine")]
        [Trait("Area", "Controllers")]
        public partial class MachineControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        MachineControllerMockFacade mock = new MachineControllerMockFacade();
                        var record = new ApiMachineResponseModel();
                        var records = new List<ApiMachineResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        MachineController controller = new MachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiMachineResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        MachineControllerMockFacade mock = new MachineControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiMachineResponseModel>>(new List<ApiMachineResponseModel>()));
                        MachineController controller = new MachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiMachineResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        MachineControllerMockFacade mock = new MachineControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiMachineResponseModel()));
                        MachineController controller = new MachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(string));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiMachineResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        MachineControllerMockFacade mock = new MachineControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiMachineResponseModel>(null));
                        MachineController controller = new MachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(string));

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void BulkInsert_No_Errors()
                {
                        MachineControllerMockFacade mock = new MachineControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiMachineResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiMachineResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiMachineRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiMachineResponseModel>>(mockResponse));
                        MachineController controller = new MachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiMachineRequestModel>();
                        records.Add(new ApiMachineRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiMachineResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiMachineRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        MachineControllerMockFacade mock = new MachineControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiMachineResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiMachineRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiMachineResponseModel>>(mockResponse.Object));
                        MachineController controller = new MachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiMachineRequestModel>();
                        records.Add(new ApiMachineRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiMachineRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        MachineControllerMockFacade mock = new MachineControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiMachineResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiMachineResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiMachineRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiMachineResponseModel>>(mockResponse));
                        MachineController controller = new MachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiMachineRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var createResponse = (response as CreatedResult).Value as CreateResponse<ApiMachineResponseModel>;
                        createResponse.Record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiMachineRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        MachineControllerMockFacade mock = new MachineControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiMachineResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiMachineResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiMachineRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiMachineResponseModel>>(mockResponse.Object));
                        MachineController controller = new MachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiMachineRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiMachineRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        MachineControllerMockFacade mock = new MachineControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiMachineResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiMachineRequestModel>()))
                        .Callback<string, ApiMachineRequestModel>(
                                (id, model) => model.CommunicationStyle.Should().Be("A")
                                )
                        .Returns(Task.FromResult<UpdateResponse<ApiMachineResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiMachineResponseModel>(new ApiMachineResponseModel()));
                        MachineController controller = new MachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiMachineModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiMachineRequestModel>();
                        patch.Replace(x => x.CommunicationStyle, "A");

                        IActionResult response = await controller.Patch(default(string), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiMachineRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        MachineControllerMockFacade mock = new MachineControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiMachineResponseModel>(null));
                        MachineController controller = new MachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiMachineRequestModel>();
                        patch.Replace(x => x.CommunicationStyle, "A");

                        IActionResult response = await controller.Patch(default(string), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        MachineControllerMockFacade mock = new MachineControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiMachineResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiMachineRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiMachineResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiMachineResponseModel()));
                        MachineController controller = new MachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiMachineModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiMachineRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiMachineRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        MachineControllerMockFacade mock = new MachineControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiMachineResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiMachineRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiMachineResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiMachineResponseModel()));
                        MachineController controller = new MachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiMachineModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiMachineRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiMachineRequestModel>()));
                }

                [Fact]
                public async void Update_NotFound()
                {
                        MachineControllerMockFacade mock = new MachineControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiMachineResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiMachineRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiMachineResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiMachineResponseModel>(null));
                        MachineController controller = new MachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiMachineModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiMachineRequestModel());

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        MachineControllerMockFacade mock = new MachineControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        MachineController controller = new MachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(string));

                        response.Should().BeOfType<NoContentResult>();
                        (response as NoContentResult).StatusCode.Should().Be((int)HttpStatusCode.NoContent);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
                }

                [Fact]
                public async void Delete_Errors()
                {
                        MachineControllerMockFacade mock = new MachineControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        MachineController controller = new MachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(string));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
                }
        }

        public class MachineControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<MachineController>> LoggerMock { get; set; } = new Mock<ILogger<MachineController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IMachineService> ServiceMock { get; set; } = new Mock<IMachineService>();

                public Mock<IApiMachineModelMapper> ModelMapperMock { get; set; } = new Mock<IApiMachineModelMapper>();
        }
}

/*<Codenesium>
    <Hash>d5868fc631a09d17cef775815e6f15f4</Hash>
</Codenesium>*/