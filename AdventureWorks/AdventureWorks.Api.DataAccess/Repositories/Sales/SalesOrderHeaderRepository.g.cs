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
	public abstract class AbstractSalesOrderHeaderRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractSalesOrderHeaderRepository(ILogger logger,
		                                          ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int revisionNumber,
		                          DateTime orderDate,
		                          DateTime dueDate,
		                          Nullable<DateTime> shipDate,
		                          int status,
		                          bool onlineOrderFlag,
		                          string salesOrderNumber,
		                          string purchaseOrderNumber,
		                          string accountNumber,
		                          int customerID,
		                          Nullable<int> salesPersonID,
		                          Nullable<int> territoryID,
		                          int billToAddressID,
		                          int shipToAddressID,
		                          int shipMethodID,
		                          Nullable<int> creditCardID,
		                          string creditCardApprovalCode,
		                          Nullable<int> currencyRateID,
		                          decimal subTotal,
		                          decimal taxAmt,
		                          decimal freight,
		                          decimal totalDue,
		                          string comment,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFSalesOrderHeader ();

			MapPOCOToEF(0, revisionNumber,
			            orderDate,
			            dueDate,
			            shipDate,
			            status,
			            onlineOrderFlag,
			            salesOrderNumber,
			            purchaseOrderNumber,
			            accountNumber,
			            customerID,
			            salesPersonID,
			            territoryID,
			            billToAddressID,
			            shipToAddressID,
			            shipMethodID,
			            creditCardID,
			            creditCardApprovalCode,
			            currencyRateID,
			            subTotal,
			            taxAmt,
			            freight,
			            totalDue,
			            comment,
			            rowguid,
			            modifiedDate, record);

			this._context.Set<EFSalesOrderHeader>().Add(record);
			this._context.SaveChanges();
			return record.SalesOrderID;
		}

		public virtual void Update(int salesOrderID, int revisionNumber,
		                           DateTime orderDate,
		                           DateTime dueDate,
		                           Nullable<DateTime> shipDate,
		                           int status,
		                           bool onlineOrderFlag,
		                           string salesOrderNumber,
		                           string purchaseOrderNumber,
		                           string accountNumber,
		                           int customerID,
		                           Nullable<int> salesPersonID,
		                           Nullable<int> territoryID,
		                           int billToAddressID,
		                           int shipToAddressID,
		                           int shipMethodID,
		                           Nullable<int> creditCardID,
		                           string creditCardApprovalCode,
		                           Nullable<int> currencyRateID,
		                           decimal subTotal,
		                           decimal taxAmt,
		                           decimal freight,
		                           decimal totalDue,
		                           string comment,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.SalesOrderID == salesOrderID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",salesOrderID);
			}
			else
			{
				MapPOCOToEF(salesOrderID,  revisionNumber,
				            orderDate,
				            dueDate,
				            shipDate,
				            status,
				            onlineOrderFlag,
				            salesOrderNumber,
				            purchaseOrderNumber,
				            accountNumber,
				            customerID,
				            salesPersonID,
				            territoryID,
				            billToAddressID,
				            shipToAddressID,
				            shipMethodID,
				            creditCardID,
				            creditCardApprovalCode,
				            currencyRateID,
				            subTotal,
				            taxAmt,
				            freight,
				            totalDue,
				            comment,
				            rowguid,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int salesOrderID)
		{
			var record = this.SearchLinqEF(x => x.SalesOrderID == salesOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFSalesOrderHeader>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int salesOrderID, Response response)
		{
			this.SearchLinqPOCO(x => x.SalesOrderID == salesOrderID,response);
		}

		protected virtual List<EFSalesOrderHeader> SearchLinqEF(Expression<Func<EFSalesOrderHeader, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesOrderHeader> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFSalesOrderHeader, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFSalesOrderHeader, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSalesOrderHeader> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSalesOrderHeader> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int salesOrderID, int revisionNumber,
		                               DateTime orderDate,
		                               DateTime dueDate,
		                               Nullable<DateTime> shipDate,
		                               int status,
		                               bool onlineOrderFlag,
		                               string salesOrderNumber,
		                               string purchaseOrderNumber,
		                               string accountNumber,
		                               int customerID,
		                               Nullable<int> salesPersonID,
		                               Nullable<int> territoryID,
		                               int billToAddressID,
		                               int shipToAddressID,
		                               int shipMethodID,
		                               Nullable<int> creditCardID,
		                               string creditCardApprovalCode,
		                               Nullable<int> currencyRateID,
		                               decimal subTotal,
		                               decimal taxAmt,
		                               decimal freight,
		                               decimal totalDue,
		                               string comment,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFSalesOrderHeader   efSalesOrderHeader)
		{
			efSalesOrderHeader.SalesOrderID = salesOrderID;
			efSalesOrderHeader.RevisionNumber = revisionNumber;
			efSalesOrderHeader.OrderDate = orderDate;
			efSalesOrderHeader.DueDate = dueDate;
			efSalesOrderHeader.ShipDate = shipDate;
			efSalesOrderHeader.Status = status;
			efSalesOrderHeader.OnlineOrderFlag = onlineOrderFlag;
			efSalesOrderHeader.SalesOrderNumber = salesOrderNumber;
			efSalesOrderHeader.PurchaseOrderNumber = purchaseOrderNumber;
			efSalesOrderHeader.AccountNumber = accountNumber;
			efSalesOrderHeader.CustomerID = customerID;
			efSalesOrderHeader.SalesPersonID = salesPersonID;
			efSalesOrderHeader.TerritoryID = territoryID;
			efSalesOrderHeader.BillToAddressID = billToAddressID;
			efSalesOrderHeader.ShipToAddressID = shipToAddressID;
			efSalesOrderHeader.ShipMethodID = shipMethodID;
			efSalesOrderHeader.CreditCardID = creditCardID;
			efSalesOrderHeader.CreditCardApprovalCode = creditCardApprovalCode;
			efSalesOrderHeader.CurrencyRateID = currencyRateID;
			efSalesOrderHeader.SubTotal = subTotal;
			efSalesOrderHeader.TaxAmt = taxAmt;
			efSalesOrderHeader.Freight = freight;
			efSalesOrderHeader.TotalDue = totalDue;
			efSalesOrderHeader.Comment = comment;
			efSalesOrderHeader.Rowguid = rowguid;
			efSalesOrderHeader.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFSalesOrderHeader efSalesOrderHeader,Response response)
		{
			if(efSalesOrderHeader == null)
			{
				return;
			}
			response.AddSalesOrderHeader(new POCOSalesOrderHeader()
			{
				SalesOrderID = efSalesOrderHeader.SalesOrderID.ToInt(),
				RevisionNumber = efSalesOrderHeader.RevisionNumber,
				OrderDate = efSalesOrderHeader.OrderDate.ToDateTime(),
				DueDate = efSalesOrderHeader.DueDate.ToDateTime(),
				ShipDate = efSalesOrderHeader.ShipDate.ToNullableDateTime(),
				Status = efSalesOrderHeader.Status,
				OnlineOrderFlag = efSalesOrderHeader.OnlineOrderFlag,
				SalesOrderNumber = efSalesOrderHeader.SalesOrderNumber,
				PurchaseOrderNumber = efSalesOrderHeader.PurchaseOrderNumber,
				AccountNumber = efSalesOrderHeader.AccountNumber,
				CreditCardApprovalCode = efSalesOrderHeader.CreditCardApprovalCode,
				SubTotal = efSalesOrderHeader.SubTotal,
				TaxAmt = efSalesOrderHeader.TaxAmt,
				Freight = efSalesOrderHeader.Freight,
				TotalDue = efSalesOrderHeader.TotalDue,
				Comment = efSalesOrderHeader.Comment,
				Rowguid = efSalesOrderHeader.Rowguid,
				ModifiedDate = efSalesOrderHeader.ModifiedDate.ToDateTime(),

				CustomerID = new ReferenceEntity<int>(efSalesOrderHeader.CustomerID,
				                                      "Customers"),
				SalesPersonID = new ReferenceEntity<Nullable<int>>(efSalesOrderHeader.SalesPersonID,
				                                                   "SalesPersons"),
				TerritoryID = new ReferenceEntity<Nullable<int>>(efSalesOrderHeader.TerritoryID,
				                                                 "SalesTerritories"),
				BillToAddressID = new ReferenceEntity<int>(efSalesOrderHeader.BillToAddressID,
				                                           "Addresses"),
				ShipToAddressID = new ReferenceEntity<int>(efSalesOrderHeader.ShipToAddressID,
				                                           "Addresses"),
				ShipMethodID = new ReferenceEntity<int>(efSalesOrderHeader.ShipMethodID,
				                                        "ShipMethods"),
				CreditCardID = new ReferenceEntity<Nullable<int>>(efSalesOrderHeader.CreditCardID,
				                                                  "CreditCards"),
				CurrencyRateID = new ReferenceEntity<Nullable<int>>(efSalesOrderHeader.CurrencyRateID,
				                                                    "CurrencyRates"),
			});

			CustomerRepository.MapEFToPOCO(efSalesOrderHeader.CustomerRef, response);

			SalesPersonRepository.MapEFToPOCO(efSalesOrderHeader.SalesPersonRef, response);

			SalesTerritoryRepository.MapEFToPOCO(efSalesOrderHeader.SalesTerritoryRef, response);

			AddressRepository.MapEFToPOCO(efSalesOrderHeader.AddressRef, response);

			AddressRepository.MapEFToPOCO(efSalesOrderHeader.AddressRef1, response);

			ShipMethodRepository.MapEFToPOCO(efSalesOrderHeader.ShipMethodRef, response);

			CreditCardRepository.MapEFToPOCO(efSalesOrderHeader.CreditCardRef, response);

			CurrencyRateRepository.MapEFToPOCO(efSalesOrderHeader.CurrencyRateRef, response);
		}
	}
}

/*<Codenesium>
    <Hash>f403308f327880be9ad42353637f1e7b</Hash>
</Codenesium>*/