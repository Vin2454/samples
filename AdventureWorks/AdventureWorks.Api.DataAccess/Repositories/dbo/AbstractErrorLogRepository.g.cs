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
	public abstract class AbstractErrorLogRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractErrorLogRepository(ILogger logger,
		                                  ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(DateTime errorTime,
		                          string userName,
		                          int errorNumber,
		                          Nullable<int> errorSeverity,
		                          Nullable<int> errorState,
		                          string errorProcedure,
		                          Nullable<int> errorLine,
		                          string errorMessage)
		{
			var record = new EFErrorLog ();

			MapPOCOToEF(0, errorTime,
			            userName,
			            errorNumber,
			            errorSeverity,
			            errorState,
			            errorProcedure,
			            errorLine,
			            errorMessage, record);

			this.context.Set<EFErrorLog>().Add(record);
			this.context.SaveChanges();
			return record.ErrorLogID;
		}

		public virtual void Update(int errorLogID, DateTime errorTime,
		                           string userName,
		                           int errorNumber,
		                           Nullable<int> errorSeverity,
		                           Nullable<int> errorState,
		                           string errorProcedure,
		                           Nullable<int> errorLine,
		                           string errorMessage)
		{
			var record =  this.SearchLinqEF(x => x.ErrorLogID == errorLogID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",errorLogID);
			}
			else
			{
				MapPOCOToEF(errorLogID,  errorTime,
				            userName,
				            errorNumber,
				            errorSeverity,
				            errorState,
				            errorProcedure,
				            errorLine,
				            errorMessage, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int errorLogID)
		{
			var record = this.SearchLinqEF(x => x.ErrorLogID == errorLogID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFErrorLog>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int errorLogID, Response response)
		{
			this.SearchLinqPOCO(x => x.ErrorLogID == errorLogID,response);
		}

		protected virtual List<EFErrorLog> SearchLinqEF(Expression<Func<EFErrorLog, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFErrorLog> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFErrorLog, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		public virtual List<POCOErrorLog> GetWhereDirect(Expression<Func<EFErrorLog, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ErrorLogs;
		}
		public virtual POCOErrorLog GetByIdDirect(int errorLogID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ErrorLogID == errorLogID,response);
			return response.ErrorLogs.FirstOrDefault();
		}

		private void SearchLinqPOCO(Expression<Func<EFErrorLog, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFErrorLog> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFErrorLog> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int errorLogID, DateTime errorTime,
		                               string userName,
		                               int errorNumber,
		                               Nullable<int> errorSeverity,
		                               Nullable<int> errorState,
		                               string errorProcedure,
		                               Nullable<int> errorLine,
		                               string errorMessage, EFErrorLog   efErrorLog)
		{
			efErrorLog.ErrorLogID = errorLogID;
			efErrorLog.ErrorTime = errorTime;
			efErrorLog.UserName = userName;
			efErrorLog.ErrorNumber = errorNumber;
			efErrorLog.ErrorSeverity = errorSeverity;
			efErrorLog.ErrorState = errorState;
			efErrorLog.ErrorProcedure = errorProcedure;
			efErrorLog.ErrorLine = errorLine;
			efErrorLog.ErrorMessage = errorMessage;
		}

		public static void MapEFToPOCO(EFErrorLog efErrorLog,Response response)
		{
			if(efErrorLog == null)
			{
				return;
			}
			response.AddErrorLog(new POCOErrorLog()
			{
				ErrorLogID = efErrorLog.ErrorLogID.ToInt(),
				ErrorTime = efErrorLog.ErrorTime.ToDateTime(),
				UserName = efErrorLog.UserName,
				ErrorNumber = efErrorLog.ErrorNumber.ToInt(),
				ErrorSeverity = efErrorLog.ErrorSeverity.ToNullableInt(),
				ErrorState = efErrorLog.ErrorState.ToNullableInt(),
				ErrorProcedure = efErrorLog.ErrorProcedure,
				ErrorLine = efErrorLog.ErrorLine.ToNullableInt(),
				ErrorMessage = efErrorLog.ErrorMessage,
			});
		}
	}
}

/*<Codenesium>
    <Hash>b2dfc2e62dde44def9a41ddc4a99e238</Hash>
</Codenesium>*/