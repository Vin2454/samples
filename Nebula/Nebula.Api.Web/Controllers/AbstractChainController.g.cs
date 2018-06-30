using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
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
        public abstract class AbstractChainController : AbstractApiController
        {
                protected IChainService ChainService { get; private set; }

                protected IApiChainModelMapper ChainModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractChainController(
                        ApiSettings settings,
                        ILogger<AbstractChainController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IChainService chainService,
                        IApiChainModelMapper chainModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.ChainService = chainService;
                        this.ChainModelMapper = chainModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiChainResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiChainResponseModel> response = await this.ChainService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiChainResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiChainResponseModel response = await this.ChainService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiChainResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiChainRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiChainResponseModel> records = new List<ApiChainResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiChainResponseModel> result = await this.ChainService.Create(model);

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
                [ProducesResponseType(typeof(ApiChainResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiChainRequestModel model)
                {
                        CreateResponse<ApiChainResponseModel> result = await this.ChainService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/Chains/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiChainResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiChainRequestModel> patch)
                {
                        ApiChainResponseModel record = await this.ChainService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiChainRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.ChainService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiChainResponseModel response = await this.ChainService.Get(id);

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
                [ProducesResponseType(typeof(ApiChainResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiChainRequestModel model)
                {
                        ApiChainRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.ChainService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiChainResponseModel response = await this.ChainService.Get(id);

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
                        ActionResponse result = await this.ChainService.Delete(id);

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
                [Route("{nextChainId}/Clasps")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiChainResponseModel>), 200)]
                public async virtual Task<IActionResult> Clasps(int nextChainId, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiClaspResponseModel> response = await this.ChainService.Clasps(nextChainId, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{chainId}/Links")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiChainResponseModel>), 200)]
                public async virtual Task<IActionResult> Links(int chainId, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiLinkResponseModel> response = await this.ChainService.Links(chainId, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                private JsonPatchDocument<ApiChainRequestModel> CreatePatch(ApiChainRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiChainRequestModel>();
                        patch.Replace(x => x.ChainStatusId, model.ChainStatusId);
                        patch.Replace(x => x.ExternalId, model.ExternalId);
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.TeamId, model.TeamId);
                        return patch;
                }

                private async Task<ApiChainRequestModel> PatchModel(int id, JsonPatchDocument<ApiChainRequestModel> patch)
                {
                        var record = await this.ChainService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiChainRequestModel request = this.ChainModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>a5a6897039c3d289126abaeb32ef1e43</Hash>
</Codenesium>*/