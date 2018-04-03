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
	public abstract class AbstractStoreRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractStoreRepository(ILogger logger,
		                               ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string name,
		                          Nullable<int> salesPersonID,
		                          string demographics,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFStore ();

			MapPOCOToEF(0, name,
			            salesPersonID,
			            demographics,
			            rowguid,
			            modifiedDate, record);

			this._context.Set<EFStore>().Add(record);
			this._context.SaveChanges();
			return record.businessEntityID;
		}

		public virtual void Update(int businessEntityID, string name,
		                           Nullable<int> salesPersonID,
		                           string demographics,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.businessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",businessEntityID);
			}
			else
			{
				MapPOCOToEF(businessEntityID,  name,
				            salesPersonID,
				            demographics,
				            rowguid,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int businessEntityID)
		{
			var record = this.SearchLinqEF(x => x.businessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFStore>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int businessEntityID, Response response)
		{
			this.SearchLinqPOCO(x => x.businessEntityID == businessEntityID,response);
		}

		protected virtual List<EFStore> SearchLinqEF(Expression<Func<EFStore, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFStore> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFStore, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFStore, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFStore> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFStore> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int businessEntityID, string name,
		                               Nullable<int> salesPersonID,
		                               string demographics,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFStore   efStore)
		{
			efStore.businessEntityID = businessEntityID;
			efStore.name = name;
			efStore.salesPersonID = salesPersonID;
			efStore.demographics = demographics;
			efStore.rowguid = rowguid;
			efStore.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFStore efStore,Response response)
		{
			if(efStore == null)
			{
				return;
			}
			response.AddStore(new POCOStore()
			{
				BusinessEntityID = efStore.businessEntityID.ToInt(),
				Name = efStore.name,
				SalesPersonID = efStore.salesPersonID.ToNullableInt(),
				Demographics = efStore.demographics,
				Rowguid = efStore.rowguid,
				ModifiedDate = efStore.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>4cb355ff85760bbdf68629b487ea1356</Hash>
</Codenesium>*/