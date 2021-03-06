using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
	public abstract class AbstractSaleController : AbstractApiController
	{
		protected ISaleService SaleService { get; private set; }

		protected IApiSaleModelMapper SaleModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractSaleController(
			ApiSettings settings,
			ILogger<AbstractSaleController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISaleService saleService,
			IApiSaleModelMapper saleModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.SaleService = saleService;
			this.SaleModelMapper = saleModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSaleResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSaleResponseModel> response = await this.SaleService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiSaleResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiSaleResponseModel response = await this.SaleService.Get(id);

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
		[Route("BulkInsert")]
		[UnitOfWork]
		[ProducesResponseType(typeof(List<ApiSaleResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSaleRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiSaleResponseModel> records = new List<ApiSaleResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiSaleResponseModel> result = await this.SaleService.Create(model);

				if (result.Success)
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

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiSaleResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiSaleRequestModel model)
		{
			CreateResponse<ApiSaleResponseModel> result = await this.SaleService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Sales/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiSaleResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiSaleRequestModel> patch)
		{
			ApiSaleResponseModel record = await this.SaleService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiSaleRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiSaleResponseModel> result = await this.SaleService.Update(id, model);

				if (result.Success)
				{
					return this.Ok(result);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiSaleResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSaleRequestModel model)
		{
			ApiSaleRequestModel request = await this.PatchModel(id, this.SaleModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiSaleResponseModel> result = await this.SaleService.Update(id, request);

				if (result.Success)
				{
					return this.Ok(result);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(ActionResponse), 200)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			ActionResponse result = await this.SaleService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpGet]
		[Route("byTransactionId/{transactionId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSaleResponseModel>), 200)]
		public async virtual Task<IActionResult> ByTransactionId(int transactionId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSaleResponseModel> response = await this.SaleService.ByTransactionId(transactionId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("bySaleId/{saleId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSaleResponseModel>), 200)]
		public async virtual Task<IActionResult> BySaleId(int saleId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSaleResponseModel> response = await this.SaleService.BySaleId(saleId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiSaleRequestModel> PatchModel(int id, JsonPatchDocument<ApiSaleRequestModel> patch)
		{
			var record = await this.SaleService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiSaleRequestModel request = this.SaleModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>2bb5d25b769eb44289272b769dbd7ed9</Hash>
</Codenesium>*/