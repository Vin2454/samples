using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Web
{
        public abstract class AbstractDeploymentHistoryController : AbstractApiController
        {
                protected IDeploymentHistoryService DeploymentHistoryService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractDeploymentHistoryController(
                        ApiSettings settings,
                        ILogger<AbstractDeploymentHistoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IDeploymentHistoryService deploymentHistoryService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.DeploymentHistoryService = deploymentHistoryService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiDeploymentHistoryResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiDeploymentHistoryResponseModel> response = await this.DeploymentHistoryService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiDeploymentHistoryResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiDeploymentHistoryResponseModel response = await this.DeploymentHistoryService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiDeploymentHistoryResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiDeploymentHistoryRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiDeploymentHistoryResponseModel> records = new List<ApiDeploymentHistoryResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiDeploymentHistoryResponseModel> result = await this.DeploymentHistoryService.Create(model);

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
                [ProducesResponseType(typeof(ApiDeploymentHistoryResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiDeploymentHistoryRequestModel model)
                {
                        CreateResponse<ApiDeploymentHistoryResponseModel> result = await this.DeploymentHistoryService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/DeploymentHistories/{result.Record.DeploymentId}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiDeploymentHistoryResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiDeploymentHistoryRequestModel> patch)
                {
                        ApiDeploymentHistoryResponseModel record = await this.DeploymentHistoryService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiDeploymentHistoryRequestModel model = new ApiDeploymentHistoryRequestModel();
                                model.SetProperties(model.ChannelId,
                                                    model.ChannelName,
                                                    model.CompletedTime,
                                                    model.Created,
                                                    model.DeployedBy,
                                                    model.DeploymentName,
                                                    model.DurationSeconds,
                                                    model.EnvironmentId,
                                                    model.EnvironmentName,
                                                    model.ProjectId,
                                                    model.ProjectName,
                                                    model.ProjectSlug,
                                                    model.QueueTime,
                                                    model.ReleaseId,
                                                    model.ReleaseVersion,
                                                    model.StartTime,
                                                    model.TaskId,
                                                    model.TaskState,
                                                    model.TenantId,
                                                    model.TenantName);
                                patch.ApplyTo(model);
                                ActionResponse result = await this.DeploymentHistoryService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiDeploymentHistoryResponseModel response = await this.DeploymentHistoryService.Get(id);

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
                [ProducesResponseType(typeof(ApiDeploymentHistoryResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiDeploymentHistoryRequestModel model)
                {
                        ActionResponse result = await this.DeploymentHistoryService.Update(id, model);

                        if (result.Success)
                        {
                                ApiDeploymentHistoryResponseModel response = await this.DeploymentHistoryService.Get(id);

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
                public virtual async Task<IActionResult> Delete(string id)
                {
                        ActionResponse result = await this.DeploymentHistoryService.Delete(id);

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
                [Route("byCreated/{created}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiDeploymentHistoryResponseModel>), 200)]
                public async virtual Task<IActionResult> ByCreated(DateTimeOffset created)
                {
                        List<ApiDeploymentHistoryResponseModel> response = await this.DeploymentHistoryService.ByCreated(created);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>e1802ecb879cf7b70e4c43ec63e855b8</Hash>
</Codenesium>*/