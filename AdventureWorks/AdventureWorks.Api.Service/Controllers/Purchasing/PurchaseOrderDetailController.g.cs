using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public abstract class AbstractPurchaseOrderDetailsController: AbstractEntityFrameworkApiController
	{
		protected IPurchaseOrderDetailRepository _purchaseOrderDetailRepository;
		protected IPurchaseOrderDetailModelValidator _purchaseOrderDetailModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractPurchaseOrderDetailsController(
			ILogger<AbstractPurchaseOrderDetailsController> logger,
			ApplicationContext context,
			IPurchaseOrderDetailRepository purchaseOrderDetailRepository,
			IPurchaseOrderDetailModelValidator purchaseOrderDetailModelValidator
			) : base(logger,context)
		{
			this._purchaseOrderDetailRepository = purchaseOrderDetailRepository;
			this._purchaseOrderDetailModelValidator = purchaseOrderDetailModelValidator;
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
		[PurchaseOrderDetailFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._purchaseOrderDetailRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[PurchaseOrderDetailFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._purchaseOrderDetailRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[PurchaseOrderDetailFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(PurchaseOrderDetailModel model)
		{
			this._purchaseOrderDetailModelValidator.CreateMode();
			var validationResult = this._purchaseOrderDetailModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._purchaseOrderDetailRepository.Create(model.PurchaseOrderDetailID,
				                                                    model.DueDate,
				                                                    model.OrderQty,
				                                                    model.ProductID,
				                                                    model.UnitPrice,
				                                                    model.LineTotal,
				                                                    model.ReceivedQty,
				                                                    model.RejectedQty,
				                                                    model.StockedQty,
				                                                    model.ModifiedDate);
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
		[PurchaseOrderDetailFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<PurchaseOrderDetailModel> models)
		{
			this._purchaseOrderDetailModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._purchaseOrderDetailModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._purchaseOrderDetailRepository.Create(model.PurchaseOrderDetailID,
				                                           model.DueDate,
				                                           model.OrderQty,
				                                           model.ProductID,
				                                           model.UnitPrice,
				                                           model.LineTotal,
				                                           model.ReceivedQty,
				                                           model.RejectedQty,
				                                           model.StockedQty,
				                                           model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[PurchaseOrderDetailFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int PurchaseOrderID,PurchaseOrderDetailModel model)
		{
			this._purchaseOrderDetailModelValidator.UpdateMode();
			var validationResult = this._purchaseOrderDetailModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._purchaseOrderDetailRepository.Update(PurchaseOrderID,  model.PurchaseOrderDetailID,
				                                           model.DueDate,
				                                           model.OrderQty,
				                                           model.ProductID,
				                                           model.UnitPrice,
				                                           model.LineTotal,
				                                           model.ReceivedQty,
				                                           model.RejectedQty,
				                                           model.StockedQty,
				                                           model.ModifiedDate);
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
		[PurchaseOrderDetailFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._purchaseOrderDetailRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByPurchaseOrderID/{id}")]
		[PurchaseOrderDetailFilter]
		[ReadOnlyFilter]
		[Route("~/api/PurchaseOrderHeaders/{id}/PurchaseOrderDetails")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByPurchaseOrderID(int id)
		{
			var response = new Response();

			this._purchaseOrderDetailRepository.GetWhere(x => x.PurchaseOrderID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByProductID/{id}")]
		[PurchaseOrderDetailFilter]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/PurchaseOrderDetails")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByProductID(int id)
		{
			var response = new Response();

			this._purchaseOrderDetailRepository.GetWhere(x => x.ProductID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>9d264e7c5d27d1672886ba2798a3e517</Hash>
</Codenesium>*/