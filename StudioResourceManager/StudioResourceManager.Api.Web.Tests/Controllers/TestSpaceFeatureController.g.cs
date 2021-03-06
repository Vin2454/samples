using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpaceFeature")]
	[Trait("Area", "Controllers")]
	public partial class SpaceFeatureControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			SpaceFeatureControllerMockFacade mock = new SpaceFeatureControllerMockFacade();
			var record = new ApiSpaceFeatureResponseModel();
			var records = new List<ApiSpaceFeatureResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			SpaceFeatureController controller = new SpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSpaceFeatureResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			SpaceFeatureControllerMockFacade mock = new SpaceFeatureControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiSpaceFeatureResponseModel>>(new List<ApiSpaceFeatureResponseModel>()));
			SpaceFeatureController controller = new SpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSpaceFeatureResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			SpaceFeatureControllerMockFacade mock = new SpaceFeatureControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSpaceFeatureResponseModel()));
			SpaceFeatureController controller = new SpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiSpaceFeatureResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			SpaceFeatureControllerMockFacade mock = new SpaceFeatureControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSpaceFeatureResponseModel>(null));
			SpaceFeatureController controller = new SpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SpaceFeatureControllerMockFacade mock = new SpaceFeatureControllerMockFacade();

			var mockResponse = new CreateResponse<ApiSpaceFeatureResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiSpaceFeatureResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSpaceFeatureRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSpaceFeatureResponseModel>>(mockResponse));
			SpaceFeatureController controller = new SpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSpaceFeatureRequestModel>();
			records.Add(new ApiSpaceFeatureRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiSpaceFeatureResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSpaceFeatureRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			SpaceFeatureControllerMockFacade mock = new SpaceFeatureControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSpaceFeatureResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSpaceFeatureRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSpaceFeatureResponseModel>>(mockResponse.Object));
			SpaceFeatureController controller = new SpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSpaceFeatureRequestModel>();
			records.Add(new ApiSpaceFeatureRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSpaceFeatureRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			SpaceFeatureControllerMockFacade mock = new SpaceFeatureControllerMockFacade();

			var mockResponse = new CreateResponse<ApiSpaceFeatureResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiSpaceFeatureResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSpaceFeatureRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSpaceFeatureResponseModel>>(mockResponse));
			SpaceFeatureController controller = new SpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSpaceFeatureRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiSpaceFeatureResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSpaceFeatureRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			SpaceFeatureControllerMockFacade mock = new SpaceFeatureControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSpaceFeatureResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiSpaceFeatureResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSpaceFeatureRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSpaceFeatureResponseModel>>(mockResponse.Object));
			SpaceFeatureController controller = new SpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSpaceFeatureRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSpaceFeatureRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			SpaceFeatureControllerMockFacade mock = new SpaceFeatureControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSpaceFeatureResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceFeatureRequestModel>()))
			.Callback<int, ApiSpaceFeatureRequestModel>(
				(id, model) => model.Name.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiSpaceFeatureResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSpaceFeatureResponseModel>(new ApiSpaceFeatureResponseModel()));
			SpaceFeatureController controller = new SpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSpaceFeatureModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSpaceFeatureRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceFeatureRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			SpaceFeatureControllerMockFacade mock = new SpaceFeatureControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSpaceFeatureResponseModel>(null));
			SpaceFeatureController controller = new SpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSpaceFeatureRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			SpaceFeatureControllerMockFacade mock = new SpaceFeatureControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSpaceFeatureResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceFeatureRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSpaceFeatureResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSpaceFeatureResponseModel()));
			SpaceFeatureController controller = new SpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSpaceFeatureModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSpaceFeatureRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceFeatureRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			SpaceFeatureControllerMockFacade mock = new SpaceFeatureControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSpaceFeatureResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceFeatureRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSpaceFeatureResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSpaceFeatureResponseModel()));
			SpaceFeatureController controller = new SpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSpaceFeatureModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSpaceFeatureRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceFeatureRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			SpaceFeatureControllerMockFacade mock = new SpaceFeatureControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSpaceFeatureResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceFeatureRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSpaceFeatureResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSpaceFeatureResponseModel>(null));
			SpaceFeatureController controller = new SpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSpaceFeatureModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSpaceFeatureRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			SpaceFeatureControllerMockFacade mock = new SpaceFeatureControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SpaceFeatureController controller = new SpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SpaceFeatureControllerMockFacade mock = new SpaceFeatureControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SpaceFeatureController controller = new SpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class SpaceFeatureControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<SpaceFeatureController>> LoggerMock { get; set; } = new Mock<ILogger<SpaceFeatureController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ISpaceFeatureService> ServiceMock { get; set; } = new Mock<ISpaceFeatureService>();

		public Mock<IApiSpaceFeatureModelMapper> ModelMapperMock { get; set; } = new Mock<IApiSpaceFeatureModelMapper>();
	}
}

/*<Codenesium>
    <Hash>bd51b75ccd58b15475c0a4bbe94b511c</Hash>
</Codenesium>*/