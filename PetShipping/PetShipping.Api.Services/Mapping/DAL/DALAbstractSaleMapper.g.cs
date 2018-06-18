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
    <Hash>92ff0be4fb53cd89c9de93f0b5649f79</Hash>
</Codenesium>*/