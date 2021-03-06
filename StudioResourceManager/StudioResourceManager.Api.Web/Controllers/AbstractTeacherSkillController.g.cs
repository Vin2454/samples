using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Web
{
	public abstract class AbstractTeacherSkillController : AbstractApiController
	{
		protected ITeacherSkillService TeacherSkillService { get; private set; }

		protected IApiTeacherSkillModelMapper TeacherSkillModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractTeacherSkillController(
			ApiSettings settings,
			ILogger<AbstractTeacherSkillController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeacherSkillService teacherSkillService,
			IApiTeacherSkillModelMapper teacherSkillModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.TeacherSkillService = teacherSkillService;
			this.TeacherSkillModelMapper = teacherSkillModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTeacherSkillResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTeacherSkillResponseModel> response = await this.TeacherSkillService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiTeacherSkillResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiTeacherSkillResponseModel response = await this.TeacherSkillService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiTeacherSkillResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiTeacherSkillRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiTeacherSkillResponseModel> records = new List<ApiTeacherSkillResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiTeacherSkillResponseModel> result = await this.TeacherSkillService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiTeacherSkillResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiTeacherSkillRequestModel model)
		{
			CreateResponse<ApiTeacherSkillResponseModel> result = await this.TeacherSkillService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/TeacherSkills/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiTeacherSkillResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiTeacherSkillRequestModel> patch)
		{
			ApiTeacherSkillResponseModel record = await this.TeacherSkillService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiTeacherSkillRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiTeacherSkillResponseModel> result = await this.TeacherSkillService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiTeacherSkillResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiTeacherSkillRequestModel model)
		{
			ApiTeacherSkillRequestModel request = await this.PatchModel(id, this.TeacherSkillModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiTeacherSkillResponseModel> result = await this.TeacherSkillService.Update(id, request);

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
			ActionResponse result = await this.TeacherSkillService.Delete(id);

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
		[Route("{teacherSkillId}/RatesByTeacherSkillId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiRateResponseModel>), 200)]
		public async virtual Task<IActionResult> RatesByTeacherSkillId(int teacherSkillId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiRateResponseModel> response = await this.TeacherSkillService.RatesByTeacherSkillId(teacherSkillId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byTeacherId/{teacherId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTeacherSkillResponseModel>), 200)]
		public async virtual Task<IActionResult> ByTeacherId(int teacherId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTeacherSkillResponseModel> response = await this.TeacherSkillService.ByTeacherId(teacherId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiTeacherSkillRequestModel> PatchModel(int id, JsonPatchDocument<ApiTeacherSkillRequestModel> patch)
		{
			var record = await this.TeacherSkillService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiTeacherSkillRequestModel request = this.TeacherSkillModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>2526ec4f39ff0b77b42921394716788a</Hash>
</Codenesium>*/