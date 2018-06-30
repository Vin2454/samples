using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
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

namespace AdventureWorksNS.Api.Web
{
        public abstract class AbstractEmailAddressController : AbstractApiController
        {
                protected IEmailAddressService EmailAddressService { get; private set; }

                protected IApiEmailAddressModelMapper EmailAddressModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractEmailAddressController(
                        ApiSettings settings,
                        ILogger<AbstractEmailAddressController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IEmailAddressService emailAddressService,
                        IApiEmailAddressModelMapper emailAddressModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.EmailAddressService = emailAddressService;
                        this.EmailAddressModelMapper = emailAddressModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiEmailAddressResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiEmailAddressResponseModel> response = await this.EmailAddressService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiEmailAddressResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiEmailAddressResponseModel response = await this.EmailAddressService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiEmailAddressResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiEmailAddressRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiEmailAddressResponseModel> records = new List<ApiEmailAddressResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiEmailAddressResponseModel> result = await this.EmailAddressService.Create(model);

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
                [ProducesResponseType(typeof(ApiEmailAddressResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiEmailAddressRequestModel model)
                {
                        CreateResponse<ApiEmailAddressResponseModel> result = await this.EmailAddressService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/EmailAddresses/{result.Record.BusinessEntityID}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiEmailAddressResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiEmailAddressRequestModel> patch)
                {
                        ApiEmailAddressResponseModel record = await this.EmailAddressService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiEmailAddressRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.EmailAddressService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiEmailAddressResponseModel response = await this.EmailAddressService.Get(id);

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
                [ProducesResponseType(typeof(ApiEmailAddressResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiEmailAddressRequestModel model)
                {
                        ApiEmailAddressRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.EmailAddressService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiEmailAddressResponseModel response = await this.EmailAddressService.Get(id);

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
                        ActionResponse result = await this.EmailAddressService.Delete(id);

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
                [Route("byEmailAddress/{emailAddress1}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiEmailAddressResponseModel>), 200)]
                public async virtual Task<IActionResult> ByEmailAddress(string emailAddress1)
                {
                        List<ApiEmailAddressResponseModel> response = await this.EmailAddressService.ByEmailAddress(emailAddress1);

                        return this.Ok(response);
                }

                private JsonPatchDocument<ApiEmailAddressRequestModel> CreatePatch(ApiEmailAddressRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiEmailAddressRequestModel>();
                        patch.Replace(x => x.EmailAddress1, model.EmailAddress1);
                        patch.Replace(x => x.EmailAddressID, model.EmailAddressID);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.Rowguid, model.Rowguid);
                        return patch;
                }

                private async Task<ApiEmailAddressRequestModel> PatchModel(int id, JsonPatchDocument<ApiEmailAddressRequestModel> patch)
                {
                        var record = await this.EmailAddressService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiEmailAddressRequestModel request = this.EmailAddressModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>f90c8280021d6493b8818064743bec99</Hash>
</Codenesium>*/