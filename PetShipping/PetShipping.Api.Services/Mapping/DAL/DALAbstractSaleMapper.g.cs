using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class DALAbstractSaleMapper
        {
                public virtual Sale MapBOToEF(
                        BOSale bo)
                {
                        Sale efSale = new Sale();

                        efSale.SetProperties(
                                bo.Amount,
                                bo.ClientId,
                                bo.Id,
                                bo.Note,
                                bo.PetId,
                                bo.SaleDate,
                                bo.SalesPersonId);
                        return efSale;
                }

                public virtual BOSale MapEFToBO(
                        Sale ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOSale();

                        bo.SetProperties(
                                ef.Id,
                                ef.Amount,
                                ef.ClientId,
                                ef.Note,
                                ef.PetId,
                                ef.SaleDate,
                                ef.SalesPersonId);
                        return bo;
                }

                public virtual List<BOSale> MapEFToBO(
                        List<Sale> records)
                {
                        List<BOSale> response = new List<BOSale>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>48a82c0bc5c1607ab429e6b4aa206aaf</Hash>
</Codenesium>*/