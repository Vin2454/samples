using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractPurchaseOrderHeaderMapper
        {
                public virtual BOPurchaseOrderHeader MapModelToBO(
                        int purchaseOrderID,
                        ApiPurchaseOrderHeaderRequestModel model
                        )
                {
                        BOPurchaseOrderHeader boPurchaseOrderHeader = new BOPurchaseOrderHeader();
                        boPurchaseOrderHeader.SetProperties(
                                purchaseOrderID,
                                model.EmployeeID,
                                model.Freight,
                                model.ModifiedDate,
                                model.OrderDate,
                                model.RevisionNumber,
                                model.ShipDate,
                                model.ShipMethodID,
                                model.Status,
                                model.SubTotal,
                                model.TaxAmt,
                                model.TotalDue,
                                model.VendorID);
                        return boPurchaseOrderHeader;
                }

                public virtual ApiPurchaseOrderHeaderResponseModel MapBOToModel(
                        BOPurchaseOrderHeader boPurchaseOrderHeader)
                {
                        var model = new ApiPurchaseOrderHeaderResponseModel();

                        model.SetProperties(boPurchaseOrderHeader.PurchaseOrderID, boPurchaseOrderHeader.EmployeeID, boPurchaseOrderHeader.Freight, boPurchaseOrderHeader.ModifiedDate, boPurchaseOrderHeader.OrderDate, boPurchaseOrderHeader.RevisionNumber, boPurchaseOrderHeader.ShipDate, boPurchaseOrderHeader.ShipMethodID, boPurchaseOrderHeader.Status, boPurchaseOrderHeader.SubTotal, boPurchaseOrderHeader.TaxAmt, boPurchaseOrderHeader.TotalDue, boPurchaseOrderHeader.VendorID);

                        return model;
                }

                public virtual List<ApiPurchaseOrderHeaderResponseModel> MapBOToModel(
                        List<BOPurchaseOrderHeader> items)
                {
                        List<ApiPurchaseOrderHeaderResponseModel> response = new List<ApiPurchaseOrderHeaderResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>32145db9b54c2998be211080b1616ce1</Hash>
</Codenesium>*/