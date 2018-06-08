using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractProductInventoryMapper
        {
                public virtual ProductInventory MapBOToEF(
                        BOProductInventory bo)
                {
                        ProductInventory efProductInventory = new ProductInventory();

                        efProductInventory.SetProperties(
                                bo.Bin,
                                bo.LocationID,
                                bo.ModifiedDate,
                                bo.ProductID,
                                bo.Quantity,
                                bo.Rowguid,
                                bo.Shelf);
                        return efProductInventory;
                }

                public virtual BOProductInventory MapEFToBO(
                        ProductInventory ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOProductInventory();

                        bo.SetProperties(
                                ef.ProductID,
                                ef.Bin,
                                ef.LocationID,
                                ef.ModifiedDate,
                                ef.Quantity,
                                ef.Rowguid,
                                ef.Shelf);
                        return bo;
                }

                public virtual List<BOProductInventory> MapEFToBO(
                        List<ProductInventory> records)
                {
                        List<BOProductInventory> response = new List<BOProductInventory>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>6818227c7e56b7ceb8ff84e992ae1791</Hash>
</Codenesium>*/