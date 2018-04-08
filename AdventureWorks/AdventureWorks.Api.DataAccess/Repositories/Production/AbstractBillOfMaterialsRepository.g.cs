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
	public abstract class AbstractBillOfMaterialsRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractBillOfMaterialsRepository(ILogger logger,
		                                         ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(Nullable<int> productAssemblyID,
		                          int componentID,
		                          DateTime startDate,
		                          Nullable<DateTime> endDate,
		                          string unitMeasureCode,
		                          short bOMLevel,
		                          decimal perAssemblyQty,
		                          DateTime modifiedDate)
		{
			var record = new EFBillOfMaterials ();

			MapPOCOToEF(0, productAssemblyID,
			            componentID,
			            startDate,
			            endDate,
			            unitMeasureCode,
			            bOMLevel,
			            perAssemblyQty,
			            modifiedDate, record);

			this.context.Set<EFBillOfMaterials>().Add(record);
			this.context.SaveChanges();
			return record.BillOfMaterialsID;
		}

		public virtual void Update(int billOfMaterialsID, Nullable<int> productAssemblyID,
		                           int componentID,
		                           DateTime startDate,
		                           Nullable<DateTime> endDate,
		                           string unitMeasureCode,
		                           short bOMLevel,
		                           decimal perAssemblyQty,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.BillOfMaterialsID == billOfMaterialsID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",billOfMaterialsID);
			}
			else
			{
				MapPOCOToEF(billOfMaterialsID,  productAssemblyID,
				            componentID,
				            startDate,
				            endDate,
				            unitMeasureCode,
				            bOMLevel,
				            perAssemblyQty,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int billOfMaterialsID)
		{
			var record = this.SearchLinqEF(x => x.BillOfMaterialsID == billOfMaterialsID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFBillOfMaterials>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int billOfMaterialsID, Response response)
		{
			this.SearchLinqPOCO(x => x.BillOfMaterialsID == billOfMaterialsID,response);
		}

		protected virtual List<EFBillOfMaterials> SearchLinqEF(Expression<Func<EFBillOfMaterials, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFBillOfMaterials> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFBillOfMaterials, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		public virtual List<POCOBillOfMaterials> GetWhereDirect(Expression<Func<EFBillOfMaterials, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.BillOfMaterials;
		}
		public virtual POCOBillOfMaterials GetByIdDirect(int billOfMaterialsID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BillOfMaterialsID == billOfMaterialsID,response);
			return response.BillOfMaterials.FirstOrDefault();
		}

		private void SearchLinqPOCO(Expression<Func<EFBillOfMaterials, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFBillOfMaterials> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFBillOfMaterials> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int billOfMaterialsID, Nullable<int> productAssemblyID,
		                               int componentID,
		                               DateTime startDate,
		                               Nullable<DateTime> endDate,
		                               string unitMeasureCode,
		                               short bOMLevel,
		                               decimal perAssemblyQty,
		                               DateTime modifiedDate, EFBillOfMaterials   efBillOfMaterials)
		{
			efBillOfMaterials.BillOfMaterialsID = billOfMaterialsID;
			efBillOfMaterials.ProductAssemblyID = productAssemblyID;
			efBillOfMaterials.ComponentID = componentID;
			efBillOfMaterials.StartDate = startDate;
			efBillOfMaterials.EndDate = endDate;
			efBillOfMaterials.UnitMeasureCode = unitMeasureCode;
			efBillOfMaterials.BOMLevel = bOMLevel;
			efBillOfMaterials.PerAssemblyQty = perAssemblyQty;
			efBillOfMaterials.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFBillOfMaterials efBillOfMaterials,Response response)
		{
			if(efBillOfMaterials == null)
			{
				return;
			}
			response.AddBillOfMaterials(new POCOBillOfMaterials()
			{
				BillOfMaterialsID = efBillOfMaterials.BillOfMaterialsID.ToInt(),
				StartDate = efBillOfMaterials.StartDate.ToDateTime(),
				EndDate = efBillOfMaterials.EndDate.ToNullableDateTime(),
				BOMLevel = efBillOfMaterials.BOMLevel,
				PerAssemblyQty = efBillOfMaterials.PerAssemblyQty.ToDecimal(),
				ModifiedDate = efBillOfMaterials.ModifiedDate.ToDateTime(),

				ProductAssemblyID = new ReferenceEntity<Nullable<int>>(efBillOfMaterials.ProductAssemblyID,
				                                                       "Products"),
				ComponentID = new ReferenceEntity<int>(efBillOfMaterials.ComponentID,
				                                       "Products"),
				UnitMeasureCode = new ReferenceEntity<string>(efBillOfMaterials.UnitMeasureCode,
				                                              "UnitMeasures"),
			});

			ProductRepository.MapEFToPOCO(efBillOfMaterials.Product, response);

			ProductRepository.MapEFToPOCO(efBillOfMaterials.Product1, response);

			UnitMeasureRepository.MapEFToPOCO(efBillOfMaterials.UnitMeasure, response);
		}
	}
}

/*<Codenesium>
    <Hash>788cfb3104aa1445d121f93ba5490d26</Hash>
</Codenesium>*/