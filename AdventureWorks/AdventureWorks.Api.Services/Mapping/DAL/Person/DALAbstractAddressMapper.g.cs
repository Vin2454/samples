using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractAddressMapper
        {
                public virtual Address MapBOToEF(
                        BOAddress bo)
                {
                        Address efAddress = new Address();

                        efAddress.SetProperties(
                                bo.AddressID,
                                bo.AddressLine1,
                                bo.AddressLine2,
                                bo.City,
                                bo.ModifiedDate,
                                bo.PostalCode,
                                bo.Rowguid,
                                bo.StateProvinceID);
                        return efAddress;
                }

                public virtual BOAddress MapEFToBO(
                        Address ef)
                {
                        var bo = new BOAddress();

                        bo.SetProperties(
                                ef.AddressID,
                                ef.AddressLine1,
                                ef.AddressLine2,
                                ef.City,
                                ef.ModifiedDate,
                                ef.PostalCode,
                                ef.Rowguid,
                                ef.StateProvinceID);
                        return bo;
                }

                public virtual List<BOAddress> MapEFToBO(
                        List<Address> records)
                {
                        List<BOAddress> response = new List<BOAddress>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>81fd2e7ac5e702d67b9df9042e5e1eda</Hash>
</Codenesium>*/