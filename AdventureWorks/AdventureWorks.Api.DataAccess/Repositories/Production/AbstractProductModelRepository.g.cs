using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractProductModelRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractProductModelRepository(ILogger logger,
		                                      ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(string name,
		                          string catalogDescription,
		                          string instructions,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFProductModel ();

			MapPOCOToEF(0, name,
			            catalogDescription,
			            instructions,
			            rowguid,
			            modifiedDate, record);

			this.context.Set<EFProductModel>().Add(record);
			this.context.SaveChanges();
			return record.ProductModelID;
		}

		public virtual void Update(int productModelID, string name,
		                           string catalogDescription,
		                           string instructions,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.ProductModelID == productModelID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{productModelID}");
			}
			else
			{
				MapPOCOToEF(productModelID,  name,
				            catalogDescription,
				            instructions,
				            rowguid,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int productModelID)
		{
			var record = this.SearchLinqEF(x => x.ProductModelID == productModelID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFProductModel>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int productModelID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ProductModelID == productModelID,response);
			return response;
		}

		public virtual POCOProductModel GetByIdDirect(int productModelID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ProductModelID == productModelID,response);
			return response.ProductModels.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFProductModel, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOProductModel> GetWhereDirect(Expression<Func<EFProductModel, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ProductModels;
		}

		private void SearchLinqPOCO(Expression<Func<EFProductModel, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductModel> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductModel> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		protected virtual List<EFProductModel> SearchLinqEF(Expression<Func<EFProductModel, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductModel> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(int productModelID, string name,
		                               string catalogDescription,
		                               string instructions,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFProductModel   efProductModel)
		{
			efProductModel.SetProperties(productModelID.ToInt(),name,catalogDescription,instructions,rowguid,modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(EFProductModel efProductModel,Response response)
		{
			if(efProductModel == null)
			{
				return;
			}
			response.AddProductModel(new POCOProductModel(efProductModel.ProductModelID.ToInt(),efProductModel.Name,efProductModel.CatalogDescription,efProductModel.Instructions,efProductModel.Rowguid,efProductModel.ModifiedDate.ToDateTime()));
		}
	}
}

/*<Codenesium>
    <Hash>7527af2a54755d6ede7f5a8bcea68bd1</Hash>
</Codenesium>*/