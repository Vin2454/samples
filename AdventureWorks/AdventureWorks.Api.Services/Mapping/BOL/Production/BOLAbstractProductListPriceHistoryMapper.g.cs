using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractProductListPriceHistoryMapper
        {
                public virtual BOProductListPriceHistory MapModelToBO(
                        int productID,
                        ApiProductListPriceHistoryRequestModel model
                        )
                {
                        BOProductListPriceHistory boProductListPriceHistory = new BOProductListPriceHistory();
                        boProductListPriceHistory.SetProperties(
                                productID,
                                model.EndDate,
                                model.ListPrice,
                                model.ModifiedDate,
                                model.StartDate);
                        return boProductListPriceHistory;
                }

                public virtual ApiProductListPriceHistoryResponseModel MapBOToModel(
                        BOProductListPriceHistory boProductListPriceHistory)
                {
                        var model = new ApiProductListPriceHistoryResponseModel();

                        model.SetProperties(boProductListPriceHistory.ProductID, boProductListPriceHistory.EndDate, boProductListPriceHistory.ListPrice, boProductListPriceHistory.ModifiedDate, boProductListPriceHistory.StartDate);

                        return model;
                }

                public virtual List<ApiProductListPriceHistoryResponseModel> MapBOToModel(
                        List<BOProductListPriceHistory> items)
                {
                        List<ApiProductListPriceHistoryResponseModel> response = new List<ApiProductListPriceHistoryResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>ff1d83fc09b9bf1bfa62722204d89187</Hash>
</Codenesium>*/