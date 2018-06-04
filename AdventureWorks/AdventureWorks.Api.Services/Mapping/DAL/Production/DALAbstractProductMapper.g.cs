using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALProductMapper
	{
		public virtual Product MapBOToEF(
			BOProduct bo)
		{
			Product efProduct = new Product ();

			efProduct.SetProperties(
				bo.@Class,
				bo.Color,
				bo.DaysToManufacture,
				bo.DiscontinuedDate,
				bo.FinishedGoodsFlag,
				bo.ListPrice,
				bo.MakeFlag,
				bo.ModifiedDate,
				bo.Name,
				bo.ProductID,
				bo.ProductLine,
				bo.ProductModelID,
				bo.ProductNumber,
				bo.ProductSubcategoryID,
				bo.ReorderPoint,
				bo.Rowguid,
				bo.SafetyStockLevel,
				bo.SellEndDate,
				bo.SellStartDate,
				bo.Size,
				bo.SizeUnitMeasureCode,
				bo.StandardCost,
				bo.Style,
				bo.Weight,
				bo.WeightUnitMeasureCode);
			return efProduct;
		}

		public virtual BOProduct MapEFToBO(
			Product ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOProduct();

			bo.SetProperties(
				ef.ProductID,
				ef.@Class,
				ef.Color,
				ef.DaysToManufacture,
				ef.DiscontinuedDate,
				ef.FinishedGoodsFlag,
				ef.ListPrice,
				ef.MakeFlag,
				ef.ModifiedDate,
				ef.Name,
				ef.ProductLine,
				ef.ProductModelID,
				ef.ProductNumber,
				ef.ProductSubcategoryID,
				ef.ReorderPoint,
				ef.Rowguid,
				ef.SafetyStockLevel,
				ef.SellEndDate,
				ef.SellStartDate,
				ef.Size,
				ef.SizeUnitMeasureCode,
				ef.StandardCost,
				ef.Style,
				ef.Weight,
				ef.WeightUnitMeasureCode);
			return bo;
		}

		public virtual List<BOProduct> MapEFToBO(
			List<Product> records)
		{
			List<BOProduct> response = new List<BOProduct>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>22b27ef45a389c1d29f06f69e8f76f6f</Hash>
</Codenesium>*/