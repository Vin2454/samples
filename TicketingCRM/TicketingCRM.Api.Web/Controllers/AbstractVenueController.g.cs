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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
        public abstract class AbstractVenueController: AbstractApiController
        {
                protected IVenueService VenueService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractVenueController(
                        ServiceSettings settings,
                        ILogger<AbstractVenueController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IVenueService venueService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.VenueService = venueService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiVenueResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiVenueResponseModel> response = await this.VenueService.All(query.Offset, query.Limit);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiVenueResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiVenueResponseModel response = await this.VenueService.Get(id);

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
                [ProducesResponseType(typeof(ApiVenueResponseModel), 200)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiVenueRequestModel model)
                {
                        CreateResponse<ApiVenueResponseModel> result = await this.VenueService.Create(model);

                        if (result.Success)
                        {
                                this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.Id.ToString());
                                this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/Venues/{result.Record.Id.ToString()}");
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
                [ProducesResponseType(typeof(List<ApiVenueResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiVenueRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiVenueResponseModel> records = new List<ApiVenueResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiVenueResponseModel> result = await this.VenueService.Create(model);

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
                [ProducesResponseType(typeof(ApiVenueResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiVenueRequestModel model)
                {
                        ActionResponse result = await this.VenueService.Update(id, model);

                        if (result.Success)
                        {
                                ApiVenueResponseModel response = await this.VenueService.Get(id);

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
                        ActionResponse result = await this.VenueService.Delete(id);

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
                [Route("getAdminId/{adminId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiVenueResponseModel>), 200)]
                public async virtual Task<IActionResult> GetAdminId(int adminId)
                {
                        List<ApiVenueResponseModel> response = await this.VenueService.GetAdminId(adminId);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("getProvinceId/{provinceId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiVenueResponseModel>), 200)]
                public async virtual Task<IActionResult> GetProvinceId(int provinceId)
                {
                        List<ApiVenueResponseModel> response = await this.VenueService.GetProvinceId(provinceId);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>b05eb6e9385df1453e2d06f1feb51ce2</Hash>
</Codenesium>*/