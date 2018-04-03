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
	public abstract class AbstractSalesPersonQuotaHistoryRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractSalesPersonQuotaHistoryRepository(ILogger logger,
		                                                 ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(DateTime quotaDate,
		                          decimal salesQuota,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFSalesPersonQuotaHistory ();

			MapPOCOToEF(0, quotaDate,
			            salesQuota,
			            rowguid,
			            modifiedDate, record);

			this._context.Set<EFSalesPersonQuotaHistory>().Add(record);
			this._context.SaveChanges();
			return record.businessEntityID;
		}

		public virtual void Update(int businessEntityID, DateTime quotaDate,
		                           decimal salesQuota,
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
				MapPOCOToEF(businessEntityID,  quotaDate,
				            salesQuota,
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
				this._context.Set<EFSalesPersonQuotaHistory>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int businessEntityID, Response response)
		{
			this.SearchLinqPOCO(x => x.businessEntityID == businessEntityID,response);
		}

		protected virtual List<EFSalesPersonQuotaHistory> SearchLinqEF(Expression<Func<EFSalesPersonQuotaHistory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesPersonQuotaHistory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFSalesPersonQuotaHistory, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFSalesPersonQuotaHistory, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSalesPersonQuotaHistory> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSalesPersonQuotaHistory> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int businessEntityID, DateTime quotaDate,
		                               decimal salesQuota,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFSalesPersonQuotaHistory   efSalesPersonQuotaHistory)
		{
			efSalesPersonQuotaHistory.businessEntityID = businessEntityID;
			efSalesPersonQuotaHistory.quotaDate = quotaDate;
			efSalesPersonQuotaHistory.salesQuota = salesQuota;
			efSalesPersonQuotaHistory.rowguid = rowguid;
			efSalesPersonQuotaHistory.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFSalesPersonQuotaHistory efSalesPersonQuotaHistory,Response response)
		{
			if(efSalesPersonQuotaHistory == null)
			{
				return;
			}
			response.AddSalesPersonQuotaHistory(new POCOSalesPersonQuotaHistory()
			{
				BusinessEntityID = efSalesPersonQuotaHistory.businessEntityID.ToInt(),
				QuotaDate = efSalesPersonQuotaHistory.quotaDate.ToDateTime(),
				SalesQuota = efSalesPersonQuotaHistory.salesQuota,
				Rowguid = efSalesPersonQuotaHistory.rowguid,
				ModifiedDate = efSalesPersonQuotaHistory.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>fb7d44d3652e06e712018083018946ad</Hash>
</Codenesium>*/