using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Service
{
	public abstract class AbstractChainsController: AbstractEntityFrameworkApiController
	{
		protected IChainRepository _chainRepository;
		protected IChainModelValidator _chainModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractChainsController(
			ILogger<AbstractChainsController> logger,
			ApplicationContext context,
			IChainRepository chainRepository,
			IChainModelValidator chainModelValidator
			) : base(logger,context)
		{
			this._chainRepository = chainRepository;
			this._chainModelValidator = chainModelValidator;
		}

		protected void AddErrors(ValidationResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
			}
		}

		[HttpGet]
		[Route("{id}")]
		[ChainFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._chainRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ChainFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._chainRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ChainFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ChainModel model)
		{
			this._chainModelValidator.CreateMode();
			var validationResult = this._chainModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._chainRepository.Create(model.Name,
				                                      model.TeamId,
				                                      model.ChainStatusId,
				                                      model.ExternalId);
				return Ok(id);
			}
			else
			{
				AddErrors(validationResult);
				return BadRequest(this.ModelState);
			}
		}

		[HttpPost]
		[Route("CreateMany")]
		[ModelValidateFilter]
		[ChainFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<ChainModel> models)
		{
			this._chainModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._chainModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._chainRepository.Create(model.Name,
				                             model.TeamId,
				                             model.ChainStatusId,
				                             model.ExternalId);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ChainFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,ChainModel model)
		{
			this._chainModelValidator.UpdateMode();
			var validationResult = this._chainModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._chainRepository.Update(id,  model.Name,
				                             model.TeamId,
				                             model.ChainStatusId,
				                             model.ExternalId);
				return Ok();
			}
			else
			{
				AddErrors(validationResult);
				return BadRequest(this.ModelState);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[ModelValidateFilter]
		[ChainFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._chainRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByTeamId/{id}")]
		[ChainFilter]
		[ReadOnlyFilter]
		[Route("~/api/Teams/{id}/Chains")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByTeamId(int id)
		{
			var response = new Response();

			this._chainRepository.GetWhere(x => x.teamId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByChainStatusId/{id}")]
		[ChainFilter]
		[ReadOnlyFilter]
		[Route("~/api/ChainStatus/{id}/Chains")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByChainStatusId(int id)
		{
			var response = new Response();

			this._chainRepository.GetWhere(x => x.chainStatusId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>5106209db3a662ee2095aa5cab7d29bd</Hash>
</Codenesium>*/