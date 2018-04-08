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
	public abstract class AbstractProductCategoryRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractProductCategoryRepository(ILogger logger,
		                                         ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(string name,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFProductCategory ();

			MapPOCOToEF(0, name,
			            rowguid,
			            modifiedDate, record);

			this.context.Set<EFProductCategory>().Add(record);
			this.context.SaveChanges();
			return record.ProductCategoryID;
		}

		public virtual void Update(int productCategoryID, string name,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.ProductCategoryID == productCategoryID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",productCategoryID);
			}
			else
			{
				MapPOCOToEF(productCategoryID,  name,
				            rowguid,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int productCategoryID)
		{
			var record = this.SearchLinqEF(x => x.ProductCategoryID == productCategoryID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFProductCategory>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int productCategoryID, Response response)
		{
			this.SearchLinqPOCO(x => x.ProductCategoryID == productCategoryID,response);
		}

		protected virtual List<EFProductCategory> SearchLinqEF(Expression<Func<EFProductCategory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductCategory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFProductCategory, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		public virtual List<POCOProductCategory> GetWhereDirect(Expression<Func<EFProductCategory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ProductCategories;
		}
		public virtual POCOProductCategory GetByIdDirect(int productCategoryID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ProductCategoryID == productCategoryID,response);
			return response.ProductCategories.FirstOrDefault();
		}

		private void SearchLinqPOCO(Expression<Func<EFProductCategory, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductCategory> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductCategory> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int productCategoryID, string name,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFProductCategory   efProductCategory)
		{
			efProductCategory.ProductCategoryID = productCategoryID;
			efProductCategory.Name = name;
			efProductCategory.Rowguid = rowguid;
			efProductCategory.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFProductCategory efProductCategory,Response response)
		{
			if(efProductCategory == null)
			{
				return;
			}
			response.AddProductCategory(new POCOProductCategory()
			{
				ProductCategoryID = efProductCategory.ProductCategoryID.ToInt(),
				Name = efProductCategory.Name,
				Rowguid = efProductCategory.Rowguid,
				ModifiedDate = efProductCategory.ModifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>1fc6dfb6c960c8b84f8b13a543bbe89d</Hash>
</Codenesium>*/