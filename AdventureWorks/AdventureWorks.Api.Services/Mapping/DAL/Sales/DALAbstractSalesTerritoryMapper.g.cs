using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractSalesTerritoryMapper
        {
                public virtual SalesTerritory MapBOToEF(
                        BOSalesTerritory bo)
                {
                        SalesTerritory efSalesTerritory = new SalesTerritory();

                        efSalesTerritory.SetProperties(
                                bo.CostLastYear,
                                bo.CostYTD,
                                bo.CountryRegionCode,
                                bo.@Group,
                                bo.ModifiedDate,
                                bo.Name,
                                bo.Rowguid,
                                bo.SalesLastYear,
                                bo.SalesYTD,
                                bo.TerritoryID);
                        return efSalesTerritory;
                }

                public virtual BOSalesTerritory MapEFToBO(
                        SalesTerritory ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOSalesTerritory();

                        bo.SetProperties(
                                ef.TerritoryID,
                                ef.CostLastYear,
                                ef.CostYTD,
                                ef.CountryRegionCode,
                                ef.@Group,
                                ef.ModifiedDate,
                                ef.Name,
                                ef.Rowguid,
                                ef.SalesLastYear,
                                ef.SalesYTD);
                        return bo;
                }

                public virtual List<BOSalesTerritory> MapEFToBO(
                        List<SalesTerritory> records)
                {
                        List<BOSalesTerritory> response = new List<BOSalesTerritory>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>dae302461a0a8c7671d037f48f68b341</Hash>
</Codenesium>*/