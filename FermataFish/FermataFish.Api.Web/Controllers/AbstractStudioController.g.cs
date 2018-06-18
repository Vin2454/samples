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
        public abstract class AbstractStudioController: AbstractApiController
        {
                protected IStudioService StudioService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractStudioController(
                        ApiSettings settings,
                        ILogger<AbstractStudioController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IStudioService studioService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.StudioService = studioService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiStudioResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiStudioResponseModel> response = await this.StudioService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiStudioResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiStudioResponseModel response = await this.StudioService.Get(id);

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
                [ProducesResponseType(typeof(ApiStudioResponseModel), 200)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiStudioRequestModel model)
                {
                        CreateResponse<ApiStudioResponseModel> result = await this.StudioService.Create(model);

                        if (result.Success)
                        {
                                this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.Id.ToString());
                                this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/Studios/{result.Record.Id.ToString()}");
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
                [ProducesResponseType(typeof(List<ApiStudioResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiStudioRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiStudioResponseModel> records = new List<ApiStudioResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiStudioResponseModel> result = await this.StudioService.Create(model);

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

                [HttpPut]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiStudioResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiStudioRequestModel model)
                {
                        ActionResponse result = await this.StudioService.Update(id, model);

                        if (result.Success)
                        {
                                ApiStudioResponseModel response = await this.StudioService.Get(id);

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
                        ActionResponse result = await this.StudioService.Delete(id);

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
                [Route("{studioId}/Admins")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiStudioResponseModel>), 200)]
                public async virtual Task<IActionResult> Admins(int studioId, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiAdminResponseModel> response = await this.StudioService.Admins(studioId, query.Limit, query.Offset);

                        return this.Ok(response);
                }
                [HttpGet]
                [Route("{id}/Families")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiStudioResponseModel>), 200)]
                public async virtual Task<IActionResult> Families(int id, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiFamilyResponseModel> response = await this.StudioService.Families(id, query.Limit, query.Offset);

                        return this.Ok(response);
                }
                [HttpGet]
                [Route("{studioId}/Lessons")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiStudioResponseModel>), 200)]
                public async virtual Task<IActionResult> Lessons(int studioId, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiLessonResponseModel> response = await this.StudioService.Lessons(studioId, query.Limit, query.Offset);

                        return this.Ok(response);
                }
                [HttpGet]
                [Route("{id}/LessonStatus")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiStudioResponseModel>), 200)]
                public async virtual Task<IActionResult> LessonStatus(int id, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiLessonStatusResponseModel> response = await this.StudioService.LessonStatus(id, query.Limit, query.Offset);

                        return this.Ok(response);
                }
                [HttpGet]
                [Route("{studioId}/Spaces")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiStudioResponseModel>), 200)]
                public async virtual Task<IActionResult> Spaces(int studioId, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiSpaceResponseModel> response = await this.StudioService.Spaces(studioId, query.Limit, query.Offset);

                        return this.Ok(response);
                }
                [HttpGet]
                [Route("{studioId}/SpaceFeatures")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiStudioResponseModel>), 200)]
                public async virtual Task<IActionResult> SpaceFeatures(int studioId, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiSpaceFeatureResponseModel> response = await this.StudioService.SpaceFeatures(studioId, query.Limit, query.Offset);

                        return this.Ok(response);
                }
                [HttpGet]
                [Route("{studioId}/Students")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiStudioResponseModel>), 200)]
                public async virtual Task<IActionResult> Students(int studioId, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiStudentResponseModel> response = await this.StudioService.Students(studioId, query.Limit, query.Offset);

                        return this.Ok(response);
                }
                [HttpGet]
                [Route("{studioId}/Teachers")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiStudioResponseModel>), 200)]
                public async virtual Task<IActionResult> Teachers(int studioId, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiTeacherResponseModel> response = await this.StudioService.Teachers(studioId, query.Limit, query.Offset);

                        return this.Ok(response);
                }
                [HttpGet]
                [Route("{studioId}/TeacherSkills")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiStudioResponseModel>), 200)]
                public async virtual Task<IActionResult> TeacherSkills(int studioId, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiTeacherSkillResponseModel> response = await this.StudioService.TeacherSkills(studioId, query.Limit, query.Offset);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>ba858bdba88d29cdfd2e2f2b63f509a1</Hash>
</Codenesium>*/