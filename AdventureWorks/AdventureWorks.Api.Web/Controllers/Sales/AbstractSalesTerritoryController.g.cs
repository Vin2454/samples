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
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
        public abstract class AbstractSalesTerritoryController: AbstractApiController
        {
                protected ISalesTerritoryService SalesTerritoryService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractSalesTerritoryController(
                        ServiceSettings settings,
                        ILogger<AbstractSalesTerritoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISalesTerritoryService salesTerritoryService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.SalesTerritoryService = salesTerritoryService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiSalesTerritoryResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiSalesTerritoryResponseModel> response = await this.SalesTerritoryService.All(query.Offset, query.Limit);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiSalesTerritoryResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiSalesTerritoryResponseModel response = await this.SalesTerritoryService.Get(id);

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
                [ProducesResponseType(typeof(ApiSalesTerritoryResponseModel), 200)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiSalesTerritoryRequestModel model)
                {
                        CreateResponse<ApiSalesTerritoryResponseModel> result = await this.SalesTerritoryService.Create(model);

                        if (result.Success)
                        {
                                this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.TerritoryID.ToString());
                                this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/SalesTerritories/{result.Record.TerritoryID.ToString()}");
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
                [ProducesResponseType(typeof(List<ApiSalesTerritoryResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSalesTerritoryRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiSalesTerritoryResponseModel> records = new List<ApiSalesTerritoryResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiSalesTerritoryResponseModel> result = await this.SalesTerritoryService.Create(model);

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
                [ProducesResponseType(typeof(ApiSalesTerritoryResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSalesTerritoryRequestModel model)
                {
                        ActionResponse result = await this.SalesTerritoryService.Update(id, model);

                        if (result.Success)
                        {
                                ApiSalesTerritoryResponseModel response = await this.SalesTerritoryService.Get(id);

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
                        ActionResponse result = await this.SalesTerritoryService.Delete(id);

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
                [Route("getName/{name}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiSalesTerritoryResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> GetName(string name)
                {
                        ApiSalesTerritoryResponseModel response = await this.SalesTerritoryService.GetName(name);

                        if (response == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                return this.Ok(response);
                        }
                }
        }
}

/*<Codenesium>
    <Hash>1f4e9c79537cd86643ebe91f76bb619c</Hash>
</Codenesium>*/