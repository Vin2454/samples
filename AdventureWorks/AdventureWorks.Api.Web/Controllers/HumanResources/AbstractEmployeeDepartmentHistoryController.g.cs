using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	public abstract class AbstractEmployeeDepartmentHistoryController: AbstractApiController
	{
		protected IEmployeeDepartmentHistoryService employeeDepartmentHistoryService;

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractEmployeeDepartmentHistoryController(
			ServiceSettings settings,
			ILogger<AbstractEmployeeDepartmentHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEmployeeDepartmentHistoryService employeeDepartmentHistoryService
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.employeeDepartmentHistoryService = employeeDepartmentHistoryService;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiEmployeeDepartmentHistoryResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiEmployeeDepartmentHistoryResponseModel> response = await this.employeeDepartmentHistoryService.All(query.Offset, query.Limit);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiEmployeeDepartmentHistoryResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiEmployeeDepartmentHistoryResponseModel response = await this.employeeDepartmentHistoryService.Get(id);

			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(ApiEmployeeDepartmentHistoryResponseModel), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiEmployeeDepartmentHistoryRequestModel model)
		{
			CreateResponse<ApiEmployeeDepartmentHistoryResponseModel> result = await this.employeeDepartmentHistoryService.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.BusinessEntityID.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/EmployeeDepartmentHistories/{result.Record.BusinessEntityID.ToString()}");
				return this.Ok(result.Record);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWork]
		[ProducesResponseType(typeof(List<ApiEmployeeDepartmentHistoryResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiEmployeeDepartmentHistoryRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiEmployeeDepartmentHistoryResponseModel> records = new List<ApiEmployeeDepartmentHistoryResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiEmployeeDepartmentHistoryResponseModel> result = await this.employeeDepartmentHistoryService.Create(model);

				if(result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			return this.Ok(records);
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(ApiEmployeeDepartmentHistoryResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiEmployeeDepartmentHistoryRequestModel model)
		{
			ActionResponse result = await this.employeeDepartmentHistoryService.Update(id, model);

			if (result.Success)
			{
				ApiEmployeeDepartmentHistoryResponseModel response = await this.employeeDepartmentHistoryService.Get(id);

				return this.Ok(response);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			ActionResponse result = await this.employeeDepartmentHistoryService.Delete(id);

			if (result.Success)
			{
				return this.NoContent();
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpGet]
		[Route("getDepartmentID/{departmentID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiEmployeeDepartmentHistoryResponseModel>), 200)]
		public async virtual Task<IActionResult> GetDepartmentID(short departmentID)
		{
			List<ApiEmployeeDepartmentHistoryResponseModel> response = await this.employeeDepartmentHistoryService.GetDepartmentID(departmentID);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("getShiftID/{shiftID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiEmployeeDepartmentHistoryResponseModel>), 200)]
		public async virtual Task<IActionResult> GetShiftID(int shiftID)
		{
			List<ApiEmployeeDepartmentHistoryResponseModel> response = await this.employeeDepartmentHistoryService.GetShiftID(shiftID);

			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>741df8d4f5dd3c10da93a9a22b66ec1d</Hash>
</Codenesium>*/