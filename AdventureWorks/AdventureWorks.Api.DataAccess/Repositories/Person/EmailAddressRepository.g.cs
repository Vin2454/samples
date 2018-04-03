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
	public abstract class AbstractEmailAddressRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractEmailAddressRepository(ILogger logger,
		                                      ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int emailAddressID,
		                          string emailAddress,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFEmailAddress ();

			MapPOCOToEF(0, emailAddressID,
			            emailAddress,
			            rowguid,
			            modifiedDate, record);

			this._context.Set<EFEmailAddress>().Add(record);
			this._context.SaveChanges();
			return record.businessEntityID;
		}

		public virtual void Update(int businessEntityID, int emailAddressID,
		                           string emailAddress,
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
				MapPOCOToEF(businessEntityID,  emailAddressID,
				            emailAddress,
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
				this._context.Set<EFEmailAddress>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int businessEntityID, Response response)
		{
			this.SearchLinqPOCO(x => x.businessEntityID == businessEntityID,response);
		}

		protected virtual List<EFEmailAddress> SearchLinqEF(Expression<Func<EFEmailAddress, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFEmailAddress> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFEmailAddress, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFEmailAddress, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFEmailAddress> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFEmailAddress> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int businessEntityID, int emailAddressID,
		                               string emailAddress,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFEmailAddress   efEmailAddress)
		{
			efEmailAddress.businessEntityID = businessEntityID;
			efEmailAddress.emailAddressID = emailAddressID;
			efEmailAddress.emailAddress = emailAddress;
			efEmailAddress.rowguid = rowguid;
			efEmailAddress.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFEmailAddress efEmailAddress,Response response)
		{
			if(efEmailAddress == null)
			{
				return;
			}
			response.AddEmailAddress(new POCOEmailAddress()
			{
				BusinessEntityID = efEmailAddress.businessEntityID.ToInt(),
				EmailAddressID = efEmailAddress.emailAddressID.ToInt(),
				EmailAddress = efEmailAddress.emailAddress,
				Rowguid = efEmailAddress.rowguid,
				ModifiedDate = efEmailAddress.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>fab6b1bcbfddc8b96e77e61773ce305b</Hash>
</Codenesium>*/