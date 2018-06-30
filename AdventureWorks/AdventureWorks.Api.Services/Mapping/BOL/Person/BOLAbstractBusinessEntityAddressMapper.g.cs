using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractBusinessEntityAddressMapper
        {
                public virtual BOBusinessEntityAddress MapModelToBO(
                        int businessEntityID,
                        ApiBusinessEntityAddressRequestModel model
                        )
                {
                        BOBusinessEntityAddress boBusinessEntityAddress = new BOBusinessEntityAddress();
                        boBusinessEntityAddress.SetProperties(
                                businessEntityID,
                                model.AddressID,
                                model.AddressTypeID,
                                model.ModifiedDate,
                                model.Rowguid);
                        return boBusinessEntityAddress;
                }

                public virtual ApiBusinessEntityAddressResponseModel MapBOToModel(
                        BOBusinessEntityAddress boBusinessEntityAddress)
                {
                        var model = new ApiBusinessEntityAddressResponseModel();

                        model.SetProperties(boBusinessEntityAddress.BusinessEntityID, boBusinessEntityAddress.AddressID, boBusinessEntityAddress.AddressTypeID, boBusinessEntityAddress.ModifiedDate, boBusinessEntityAddress.Rowguid);

                        return model;
                }

                public virtual List<ApiBusinessEntityAddressResponseModel> MapBOToModel(
                        List<BOBusinessEntityAddress> items)
                {
                        List<ApiBusinessEntityAddressResponseModel> response = new List<ApiBusinessEntityAddressResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>ed98cba0e133aab94a839ba111dd7ee0</Hash>
</Codenesium>*/