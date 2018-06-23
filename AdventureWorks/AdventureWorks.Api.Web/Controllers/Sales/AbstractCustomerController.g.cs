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
        public abstract class AbstractCustomerController : AbstractApiController
        {
                protected ICustomerService CustomerService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractCustomerController(
                        ApiSettings settings,
                        ILogger<AbstractCustomerController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ICustomerService customerService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.CustomerService = customerService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiCustomerResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiCustomerResponseModel> response = await this.CustomerService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiCustomerResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiCustomerResponseModel response = await this.CustomerService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiCustomerResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiCustomerRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiCustomerResponseModel> records = new List<ApiCustomerResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiCustomerResponseModel> result = await this.CustomerService.Create(model);

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
                [ProducesResponseType(typeof(ApiCustomerResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiCustomerRequestModel model)
                {
                        CreateResponse<ApiCustomerResponseModel> result = await this.CustomerService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/Customers/{result.Record.CustomerID}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiCustomerResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiCustomerRequestModel> patch)
                {
                        ApiCustomerResponseModel record = await this.CustomerService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiCustomerRequestModel model = new ApiCustomerRequestModel();
                                model.SetProperties(model.AccountNumber,
                                                    model.ModifiedDate,
                                                    model.PersonID,
                                                    model.Rowguid,
                                                    model.StoreID,
                                                    model.TerritoryID);
                                patch.ApplyTo(model);
                                ActionResponse result = await this.CustomerService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiCustomerResponseModel response = await this.CustomerService.Get(id);

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
                [ProducesResponseType(typeof(ApiCustomerResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiCustomerRequestModel model)
                {
                        ActionResponse result = await this.CustomerService.Update(id, model);

                        if (result.Success)
                        {
                                ApiCustomerResponseModel response = await this.CustomerService.Get(id);

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
                        ActionResponse result = await this.CustomerService.Delete(id);

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
                [Route("byAccountNumber/{accountNumber}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiCustomerResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> ByAccountNumber(string accountNumber)
                {
                        ApiCustomerResponseModel response = await this.CustomerService.ByAccountNumber(accountNumber);

                        if (response == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                return this.Ok(response);
                        }
                }

                [HttpGet]
                [Route("byTerritoryID/{territoryID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiCustomerResponseModel>), 200)]
                public async virtual Task<IActionResult> ByTerritoryID(Nullable<int> territoryID)
                {
                        List<ApiCustomerResponseModel> response = await this.CustomerService.ByTerritoryID(territoryID);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{customerID}/SalesOrderHeaders")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiCustomerResponseModel>), 200)]
                public async virtual Task<IActionResult> SalesOrderHeaders(int customerID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiSalesOrderHeaderResponseModel> response = await this.CustomerService.SalesOrderHeaders(customerID, query.Limit, query.Offset);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>b295d055acd748b63d73c572d1bae23b</Hash>
</Codenesium>*/