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
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;

namespace FermataFishNS.Api.Web
{
	public abstract class AbstractSpaceXSpaceFeatureController: AbstractApiController
	{
		protected ISpaceXSpaceFeatureService spaceXSpaceFeatureService;

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractSpaceXSpaceFeatureController(
			ServiceSettings settings,
			ILogger<AbstractSpaceXSpaceFeatureController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpaceXSpaceFeatureService spaceXSpaceFeatureService
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.spaceXSpaceFeatureService = spaceXSpaceFeatureService;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSpaceXSpaceFeatureResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiSpaceXSpaceFeatureResponseModel> response = await this.spaceXSpaceFeatureService.All(query.Offset, query.Limit);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiSpaceXSpaceFeatureResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiSpaceXSpaceFeatureResponseModel response = await this.spaceXSpaceFeatureService.Get(id);

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
		[ProducesResponseType(typeof(ApiSpaceXSpaceFeatureResponseModel), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiSpaceXSpaceFeatureRequestModel model)
		{
			CreateResponse<ApiSpaceXSpaceFeatureResponseModel> result = await this.spaceXSpaceFeatureService.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.Id.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/SpaceXSpaceFeatures/{result.Record.Id.ToString()}");
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
		[ProducesResponseType(typeof(List<ApiSpaceXSpaceFeatureResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSpaceXSpaceFeatureRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiSpaceXSpaceFeatureResponseModel> records = new List<ApiSpaceXSpaceFeatureResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiSpaceXSpaceFeatureResponseModel> result = await this.spaceXSpaceFeatureService.Create(model);

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
		[ProducesResponseType(typeof(ApiSpaceXSpaceFeatureResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSpaceXSpaceFeatureRequestModel model)
		{
			ActionResponse result = await this.spaceXSpaceFeatureService.Update(id, model);

			if (result.Success)
			{
				ApiSpaceXSpaceFeatureResponseModel response = await this.spaceXSpaceFeatureService.Get(id);

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
			ActionResponse result = await this.spaceXSpaceFeatureService.Delete(id);

			if (result.Success)
			{
				return this.NoContent();
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}
	}
}

/*<Codenesium>
    <Hash>9790233cb8728352438f0bd71e77cec6</Hash>
</Codenesium>*/