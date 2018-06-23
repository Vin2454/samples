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
        public abstract class AbstractEventRelatedDocumentController : AbstractApiController
        {
                protected IEventRelatedDocumentService EventRelatedDocumentService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractEventRelatedDocumentController(
                        ApiSettings settings,
                        ILogger<AbstractEventRelatedDocumentController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IEventRelatedDocumentService eventRelatedDocumentService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.EventRelatedDocumentService = eventRelatedDocumentService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiEventRelatedDocumentResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiEventRelatedDocumentResponseModel> response = await this.EventRelatedDocumentService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiEventRelatedDocumentResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiEventRelatedDocumentResponseModel response = await this.EventRelatedDocumentService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiEventRelatedDocumentResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiEventRelatedDocumentRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiEventRelatedDocumentResponseModel> records = new List<ApiEventRelatedDocumentResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiEventRelatedDocumentResponseModel> result = await this.EventRelatedDocumentService.Create(model);

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
                [ProducesResponseType(typeof(ApiEventRelatedDocumentResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiEventRelatedDocumentRequestModel model)
                {
                        CreateResponse<ApiEventRelatedDocumentResponseModel> result = await this.EventRelatedDocumentService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/EventRelatedDocuments/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiEventRelatedDocumentResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiEventRelatedDocumentRequestModel> patch)
                {
                        ApiEventRelatedDocumentResponseModel record = await this.EventRelatedDocumentService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiEventRelatedDocumentRequestModel model = new ApiEventRelatedDocumentRequestModel();
                                model.SetProperties(model.EventId,
                                                    model.RelatedDocumentId);
                                patch.ApplyTo(model);
                                ActionResponse result = await this.EventRelatedDocumentService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiEventRelatedDocumentResponseModel response = await this.EventRelatedDocumentService.Get(id);

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
                [ProducesResponseType(typeof(ApiEventRelatedDocumentResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiEventRelatedDocumentRequestModel model)
                {
                        ActionResponse result = await this.EventRelatedDocumentService.Update(id, model);

                        if (result.Success)
                        {
                                ApiEventRelatedDocumentResponseModel response = await this.EventRelatedDocumentService.Get(id);

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
                        ActionResponse result = await this.EventRelatedDocumentService.Delete(id);

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
                [Route("getEventId/{eventId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiEventRelatedDocumentResponseModel>), 200)]
                public async virtual Task<IActionResult> GetEventId(string eventId)
                {
                        List<ApiEventRelatedDocumentResponseModel> response = await this.EventRelatedDocumentService.GetEventId(eventId);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("getEventIdRelatedDocumentId/{eventId}/{relatedDocumentId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiEventRelatedDocumentResponseModel>), 200)]
                public async virtual Task<IActionResult> GetEventIdRelatedDocumentId(string eventId, string relatedDocumentId)
                {
                        List<ApiEventRelatedDocumentResponseModel> response = await this.EventRelatedDocumentService.GetEventIdRelatedDocumentId(eventId, relatedDocumentId);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>54678fbeda8f059eac572d64db0968fa</Hash>
</Codenesium>*/