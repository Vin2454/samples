using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NebulaNS.Api.Web
{
	public abstract class AbstractVersionInfoController : AbstractApiController
	{
		protected IVersionInfoService VersionInfoService { get; private set; }

		protected IApiVersionInfoModelMapper VersionInfoModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractVersionInfoController(
			ApiSettings settings,
			ILogger<AbstractVersionInfoController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVersionInfoService versionInfoService,
			IApiVersionInfoModelMapper versionInfoModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.VersionInfoService = versionInfoService;
			this.VersionInfoModelMapper = versionInfoModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiVersionInfoResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiVersionInfoResponseModel> response = await this.VersionInfoService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiVersionInfoResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(long id)
		{
			ApiVersionInfoResponseModel response = await this.VersionInfoService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiVersionInfoResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiVersionInfoRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiVersionInfoResponseModel> records = new List<ApiVersionInfoResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiVersionInfoResponseModel> result = await this.VersionInfoService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiVersionInfoResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiVersionInfoRequestModel model)
		{
			CreateResponse<ApiVersionInfoResponseModel> result = await this.VersionInfoService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/VersionInfoes/{result.Record.Version}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiVersionInfoResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(long id, [FromBody] JsonPatchDocument<ApiVersionInfoRequestModel> patch)
		{
			ApiVersionInfoResponseModel record = await this.VersionInfoService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiVersionInfoRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiVersionInfoResponseModel> result = await this.VersionInfoService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiVersionInfoResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(long id, [FromBody] ApiVersionInfoRequestModel model)
		{
			ApiVersionInfoRequestModel request = await this.PatchModel(id, this.VersionInfoModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiVersionInfoResponseModel> result = await this.VersionInfoService.Update(id, request);

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
		public virtual async Task<IActionResult> Delete(long id)
		{
			ActionResponse result = await this.VersionInfoService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		private async Task<ApiVersionInfoRequestModel> PatchModel(long id, JsonPatchDocument<ApiVersionInfoRequestModel> patch)
		{
			var record = await this.VersionInfoService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiVersionInfoRequestModel request = this.VersionInfoModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>509ab18d1198e65869a70681ded5dd94</Hash>
</Codenesium>*/