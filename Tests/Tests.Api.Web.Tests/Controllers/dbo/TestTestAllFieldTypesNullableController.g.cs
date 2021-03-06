using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TestAllFieldTypesNullable")]
	[Trait("Area", "Controllers")]
	public partial class TestAllFieldTypesNullableControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();
			var record = new ApiTestAllFieldTypesNullableResponseModel();
			var records = new List<ApiTestAllFieldTypesNullableResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTestAllFieldTypesNullableResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiTestAllFieldTypesNullableResponseModel>>(new List<ApiTestAllFieldTypesNullableResponseModel>()));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTestAllFieldTypesNullableResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTestAllFieldTypesNullableResponseModel()));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiTestAllFieldTypesNullableResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTestAllFieldTypesNullableResponseModel>(null));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void BulkInsert_No_Errors()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();

			var mockResponse = new CreateResponse<ApiTestAllFieldTypesNullableResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiTestAllFieldTypesNullableResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTestAllFieldTypesNullableRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTestAllFieldTypesNullableResponseModel>>(mockResponse));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTestAllFieldTypesNullableRequestModel>();
			records.Add(new ApiTestAllFieldTypesNullableRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiTestAllFieldTypesNullableResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTestAllFieldTypesNullableRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTestAllFieldTypesNullableResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTestAllFieldTypesNullableRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTestAllFieldTypesNullableResponseModel>>(mockResponse.Object));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTestAllFieldTypesNullableRequestModel>();
			records.Add(new ApiTestAllFieldTypesNullableRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTestAllFieldTypesNullableRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();

			var mockResponse = new CreateResponse<ApiTestAllFieldTypesNullableResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiTestAllFieldTypesNullableResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTestAllFieldTypesNullableRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTestAllFieldTypesNullableResponseModel>>(mockResponse));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTestAllFieldTypesNullableRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiTestAllFieldTypesNullableResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTestAllFieldTypesNullableRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTestAllFieldTypesNullableResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiTestAllFieldTypesNullableResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTestAllFieldTypesNullableRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTestAllFieldTypesNullableResponseModel>>(mockResponse.Object));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTestAllFieldTypesNullableRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTestAllFieldTypesNullableRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTestAllFieldTypesNullableResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypesNullableRequestModel>()))
			.Callback<int, ApiTestAllFieldTypesNullableRequestModel>(
				(id, model) => model.FieldBigInt.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiTestAllFieldTypesNullableResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTestAllFieldTypesNullableResponseModel>(new ApiTestAllFieldTypesNullableResponseModel()));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTestAllFieldTypesNullableModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTestAllFieldTypesNullableRequestModel>();
			patch.Replace(x => x.FieldBigInt, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypesNullableRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTestAllFieldTypesNullableResponseModel>(null));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTestAllFieldTypesNullableRequestModel>();
			patch.Replace(x => x.FieldBigInt, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTestAllFieldTypesNullableResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypesNullableRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTestAllFieldTypesNullableResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTestAllFieldTypesNullableResponseModel()));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTestAllFieldTypesNullableModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTestAllFieldTypesNullableRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypesNullableRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTestAllFieldTypesNullableResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypesNullableRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTestAllFieldTypesNullableResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTestAllFieldTypesNullableResponseModel()));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTestAllFieldTypesNullableModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTestAllFieldTypesNullableRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypesNullableRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTestAllFieldTypesNullableResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypesNullableRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTestAllFieldTypesNullableResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTestAllFieldTypesNullableResponseModel>(null));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTestAllFieldTypesNullableModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTestAllFieldTypesNullableRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class TestAllFieldTypesNullableControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<TestAllFieldTypesNullableController>> LoggerMock { get; set; } = new Mock<ILogger<TestAllFieldTypesNullableController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ITestAllFieldTypesNullableService> ServiceMock { get; set; } = new Mock<ITestAllFieldTypesNullableService>();

		public Mock<IApiTestAllFieldTypesNullableModelMapper> ModelMapperMock { get; set; } = new Mock<IApiTestAllFieldTypesNullableModelMapper>();
	}
}

/*<Codenesium>
    <Hash>6e7bcdb2eae1a5eb92127e4e63444cd7</Hash>
</Codenesium>*/