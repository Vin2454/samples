using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Web
{
        public abstract class AbstractPipelineStepStepRequirementController : AbstractApiController
        {
                protected IPipelineStepStepRequirementService PipelineStepStepRequirementService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractPipelineStepStepRequirementController(
                        ApiSettings settings,
                        ILogger<AbstractPipelineStepStepRequirementController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPipelineStepStepRequirementService pipelineStepStepRequirementService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.PipelineStepStepRequirementService = pipelineStepStepRequirementService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiPipelineStepStepRequirementResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiPipelineStepStepRequirementResponseModel> response = await this.PipelineStepStepRequirementService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiPipelineStepStepRequirementResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiPipelineStepStepRequirementResponseModel response = await this.PipelineStepStepRequirementService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiPipelineStepStepRequirementResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPipelineStepStepRequirementRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiPipelineStepStepRequirementResponseModel> records = new List<ApiPipelineStepStepRequirementResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiPipelineStepStepRequirementResponseModel> result = await this.PipelineStepStepRequirementService.Create(model);

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
                [ProducesResponseType(typeof(ApiPipelineStepStepRequirementResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiPipelineStepStepRequirementRequestModel model)
                {
                        CreateResponse<ApiPipelineStepStepRequirementResponseModel> result = await this.PipelineStepStepRequirementService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/PipelineStepStepRequirements/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiPipelineStepStepRequirementResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiPipelineStepStepRequirementRequestModel> patch)
                {
                        ApiPipelineStepStepRequirementResponseModel record = await this.PipelineStepStepRequirementService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiPipelineStepStepRequirementRequestModel model = new ApiPipelineStepStepRequirementRequestModel();
                                model.SetProperties(model.Details,
                                                    model.PipelineStepId,
                                                    model.RequirementMet);
                                patch.ApplyTo(model);
                                ActionResponse result = await this.PipelineStepStepRequirementService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiPipelineStepStepRequirementResponseModel response = await this.PipelineStepStepRequirementService.Get(id);

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
                [ProducesResponseType(typeof(ApiPipelineStepStepRequirementResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPipelineStepStepRequirementRequestModel model)
                {
                        ActionResponse result = await this.PipelineStepStepRequirementService.Update(id, model);

                        if (result.Success)
                        {
                                ApiPipelineStepStepRequirementResponseModel response = await this.PipelineStepStepRequirementService.Get(id);

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
                        ActionResponse result = await this.PipelineStepStepRequirementService.Delete(id);

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
    <Hash>61287af7beb5ed4a36a31401e95fccb3</Hash>
</Codenesium>*/