using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.BusinessObjects;

namespace FermataFishNS.Api.Service
{
	public abstract class AbstractSpaceXSpaceFeatureController: AbstractApiController
	{
		protected IBOSpaceXSpaceFeature spaceXSpaceFeatureManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractSpaceXSpaceFeatureController(
			ILogger<AbstractSpaceXSpaceFeatureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSpaceXSpaceFeature spaceXSpaceFeatureManager
			)
			: base(logger, transactionCoordinator)
		{
			this.spaceXSpaceFeatureManager = spaceXSpaceFeatureManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.spaceXSpaceFeatureManager.GetById(id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			ApiResponse response = this.spaceXSpaceFeatureManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 400)]
		public virtual async Task<IActionResult> Create([FromBody] SpaceXSpaceFeatureModel model)
		{
			var result = await this.spaceXSpaceFeatureManager.Create(model);

			if(result.Success)
			{
				return this.Ok(result);
			}
			else
			{
				return this.BadRequest(result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ActionResponse), 400)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<SpaceXSpaceFeatureModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var result = await this.spaceXSpaceFeatureManager.Create(model);

				if(!result.Success)
				{
					return this.BadRequest(result);
				}
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ActionResponse), 400)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] SpaceXSpaceFeatureModel model)
		{
			var result = await this.spaceXSpaceFeatureManager.Update(id, model);

			if(result.Success)
			{
				return this.Ok();
			}
			else
			{
				return this.BadRequest(result);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ActionResponse), 400)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			var result = await this.spaceXSpaceFeatureManager.Delete(id);

			if(result.Success)
			{
				return this.Ok();
			}
			else
			{
				return this.BadRequest(result);
			}
		}

		[HttpGet]
		[Route("BySpaceId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Spaces/{id}/SpaceXSpaceFeatures")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult BySpaceId(int id)
		{
			ApiResponse response = this.spaceXSpaceFeatureManager.GetWhere(x => x.SpaceId == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("BySpaceFeatureId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/SpaceFeatures/{id}/SpaceXSpaceFeatures")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult BySpaceFeatureId(int id)
		{
			ApiResponse response = this.spaceXSpaceFeatureManager.GetWhere(x => x.SpaceFeatureId == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>69fe0e1375824b42f913227471e066e8</Hash>
</Codenesium>*/