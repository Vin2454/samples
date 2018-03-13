using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Service
{
	public abstract class AbstractLinkStatusController: AbstractEntityFrameworkApiController
	{
		protected LinkStatusRepository _linkStatusRepository;
		protected LinkStatusModelValidator _linkStatusModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractLinkStatusController(
			ILogger<AbstractLinkStatusController> logger,
			ApplicationContext context,
			LinkStatusRepository linkStatusRepository,
			LinkStatusModelValidator linkStatusModelValidator
			) : base(logger,context)
		{
			this._linkStatusRepository = linkStatusRepository;
			this._linkStatusModelValidator = linkStatusModelValidator;
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
		[LinkStatusFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._linkStatusRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[LinkStatusFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._linkStatusRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[LinkStatusFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), 400)]
		public virtual IActionResult Create(LinkStatusModel model)
		{
			this._linkStatusModelValidator.CreateMode();
			var validationResult = this._linkStatusModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._linkStatusRepository.Create(model.Id,
				                                           model.Name);
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
		[LinkStatusFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<LinkStatusModel> models)
		{
			this._linkStatusModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._linkStatusModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._linkStatusRepository.Create(model.Id,
				                                  model.Name);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[LinkStatusFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,LinkStatusModel model)
		{
			this._linkStatusModelValidator.UpdateMode();
			var validationResult = this._linkStatusModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._linkStatusRepository.Update(model.Id,
				                                  model.Name);
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
		[LinkStatusFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._linkStatusRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>45e25e4384ca6523c190d15f0b58937e</Hash>
</Codenesium>*/