using Codenesium.Foundation.CommonMVC;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FluentValidation.Results;
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

namespace FermataFishNS.Api.Web
{
        public abstract class AbstractLessonXStudentController : AbstractApiController
        {
                protected ILessonXStudentService LessonXStudentService { get; private set; }

                protected IApiLessonXStudentModelMapper LessonXStudentModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractLessonXStudentController(
                        ApiSettings settings,
                        ILogger<AbstractLessonXStudentController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ILessonXStudentService lessonXStudentService,
                        IApiLessonXStudentModelMapper lessonXStudentModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.LessonXStudentService = lessonXStudentService;
                        this.LessonXStudentModelMapper = lessonXStudentModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiLessonXStudentResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiLessonXStudentResponseModel> response = await this.LessonXStudentService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiLessonXStudentResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiLessonXStudentResponseModel response = await this.LessonXStudentService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiLessonXStudentResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiLessonXStudentRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiLessonXStudentResponseModel> records = new List<ApiLessonXStudentResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiLessonXStudentResponseModel> result = await this.LessonXStudentService.Create(model);

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
                [ProducesResponseType(typeof(ApiLessonXStudentResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiLessonXStudentRequestModel model)
                {
                        CreateResponse<ApiLessonXStudentResponseModel> result = await this.LessonXStudentService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/LessonXStudents/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiLessonXStudentResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiLessonXStudentRequestModel> patch)
                {
                        ApiLessonXStudentResponseModel record = await this.LessonXStudentService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiLessonXStudentRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.LessonXStudentService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiLessonXStudentResponseModel response = await this.LessonXStudentService.Get(id);

                                        return this.Ok(response);
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
                [ProducesResponseType(typeof(ApiLessonXStudentResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiLessonXStudentRequestModel model)
                {
                        ApiLessonXStudentRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.LessonXStudentService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiLessonXStudentResponseModel response = await this.LessonXStudentService.Get(id);

                                        return this.Ok(response);
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
                [ProducesResponseType(typeof(void), 204)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Delete(int id)
                {
                        ActionResponse result = await this.LessonXStudentService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                private JsonPatchDocument<ApiLessonXStudentRequestModel> CreatePatch(ApiLessonXStudentRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiLessonXStudentRequestModel>();
                        patch.Replace(x => x.LessonId, model.LessonId);
                        patch.Replace(x => x.StudentId, model.StudentId);
                        return patch;
                }

                private async Task<ApiLessonXStudentRequestModel> PatchModel(int id, JsonPatchDocument<ApiLessonXStudentRequestModel> patch)
                {
                        var record = await this.LessonXStudentService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiLessonXStudentRequestModel request = this.LessonXStudentModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>07921dcc399e6aa11a18fa61ddfc7965</Hash>
</Codenesium>*/