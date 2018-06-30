using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractLocationMapper
        {
                public virtual BOLocation MapModelToBO(
                        short locationID,
                        ApiLocationRequestModel model
                        )
                {
                        BOLocation boLocation = new BOLocation();
                        boLocation.SetProperties(
                                locationID,
                                model.Availability,
                                model.CostRate,
                                model.ModifiedDate,
                                model.Name);
                        return boLocation;
                }

                public virtual ApiLocationResponseModel MapBOToModel(
                        BOLocation boLocation)
                {
                        var model = new ApiLocationResponseModel();

                        model.SetProperties(boLocation.LocationID, boLocation.Availability, boLocation.CostRate, boLocation.ModifiedDate, boLocation.Name);

                        return model;
                }

                public virtual List<ApiLocationResponseModel> MapBOToModel(
                        List<BOLocation> items)
                {
                        List<ApiLocationResponseModel> response = new List<ApiLocationResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>69bab989d7c3ea94c227c4d363700814</Hash>
</Codenesium>*/