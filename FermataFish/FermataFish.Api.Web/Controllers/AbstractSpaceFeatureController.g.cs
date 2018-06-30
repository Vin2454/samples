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
        public abstract class AbstractSpaceFeatureController : AbstractApiController
        {
                protected ISpaceFeatureService SpaceFeatureService { get; private set; }

                protected IApiSpaceFeatureModelMapper SpaceFeatureModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractSpaceFeatureController(
                        ApiSettings settings,
                        ILogger<AbstractSpaceFeatureController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISpaceFeatureService spaceFeatureService,
                        IApiSpaceFeatureModelMapper spaceFeatureModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.SpaceFeatureService = spaceFeatureService;
                        this.SpaceFeatureModelMapper = spaceFeatureModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiSpaceFeatureResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiSpaceFeatureResponseModel> response = await this.SpaceFeatureService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiSpaceFeatureResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiSpaceFeatureResponseModel response = await this.SpaceFeatureService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiSpaceFeatureResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSpaceFeatureRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiSpaceFeatureResponseModel> records = new List<ApiSpaceFeatureResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiSpaceFeatureResponseModel> result = await this.SpaceFeatureService.Create(model);

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
                [ProducesResponseType(typeof(ApiSpaceFeatureResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiSpaceFeatureRequestModel model)
                {
                        CreateResponse<ApiSpaceFeatureResponseModel> result = await this.SpaceFeatureService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/SpaceFeatures/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiSpaceFeatureResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiSpaceFeatureRequestModel> patch)
                {
                        ApiSpaceFeatureResponseModel record = await this.SpaceFeatureService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiSpaceFeatureRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.SpaceFeatureService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiSpaceFeatureResponseModel response = await this.SpaceFeatureService.Get(id);

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
                [ProducesResponseType(typeof(ApiSpaceFeatureResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSpaceFeatureRequestModel model)
                {
                        ApiSpaceFeatureRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.SpaceFeatureService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiSpaceFeatureResponseModel response = await this.SpaceFeatureService.Get(id);

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
                        ActionResponse result = await this.SpaceFeatureService.Delete(id);

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
                [Route("{spaceFeatureId}/SpaceXSpaceFeatures")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiSpaceFeatureResponseModel>), 200)]
                public async virtual Task<IActionResult> SpaceXSpaceFeatures(int spaceFeatureId, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiSpaceXSpaceFeatureResponseModel> response = await this.SpaceFeatureService.SpaceXSpaceFeatures(spaceFeatureId, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                private JsonPatchDocument<ApiSpaceFeatureRequestModel> CreatePatch(ApiSpaceFeatureRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiSpaceFeatureRequestModel>();
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.StudioId, model.StudioId);
                        return patch;
                }

                private async Task<ApiSpaceFeatureRequestModel> PatchModel(int id, JsonPatchDocument<ApiSpaceFeatureRequestModel> patch)
                {
                        var record = await this.SpaceFeatureService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiSpaceFeatureRequestModel request = this.SpaceFeatureModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>929d278759a42797f70a80799d8dfa68</Hash>
</Codenesium>*/