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
        public abstract class AbstractTeacherSkillController: AbstractApiController
        {
                protected ITeacherSkillService TeacherSkillService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractTeacherSkillController(
                        ApiSettings settings,
                        ILogger<AbstractTeacherSkillController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITeacherSkillService teacherSkillService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.TeacherSkillService = teacherSkillService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiTeacherSkillResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
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
                [Route("")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiTeacherSkillResponseModel), 200)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiTeacherSkillRequestModel model)
                {
                        CreateResponse<ApiTeacherSkillResponseModel> result = await this.TeacherSkillService.Create(model);

                        if (result.Success)
                        {
                                this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.Id.ToString());
                                this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/TeacherSkills/{result.Record.Id.ToString()}");
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

                [HttpPut]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiTeacherSkillResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiTeacherSkillRequestModel model)
                {
                        ActionResponse result = await this.TeacherSkillService.Update(id, model);

                        if (result.Success)
                        {
                                ApiTeacherSkillResponseModel response = await this.TeacherSkillService.Get(id);

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
                        ActionResponse result = await this.TeacherSkillService.Delete(id);

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
                [Route("{teacherSkillId}/Rates")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiTeacherSkillResponseModel>), 200)]
                public async virtual Task<IActionResult> Rates(int teacherSkillId, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiRateResponseModel> response = await this.TeacherSkillService.Rates(teacherSkillId, query.Limit, query.Offset);

                        return this.Ok(response);
                }
                [HttpGet]
                [Route("{teacherSkillId}/TeacherXTeacherSkills")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiTeacherSkillResponseModel>), 200)]
                public async virtual Task<IActionResult> TeacherXTeacherSkills(int teacherSkillId, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiTeacherXTeacherSkillResponseModel> response = await this.TeacherSkillService.TeacherXTeacherSkills(teacherSkillId, query.Limit, query.Offset);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>fc1ee9a03e0e0e91453bc9726015f461</Hash>
</Codenesium>*/