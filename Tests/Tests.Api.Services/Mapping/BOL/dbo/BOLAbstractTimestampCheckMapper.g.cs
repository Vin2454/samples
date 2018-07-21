using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public abstract class BOLAbstractTimestampCheckMapper
        {
                public virtual BOTimestampCheck MapModelToBO(
                        int id,
                        ApiTimestampCheckRequestModel model
                        )
                {
                        BOTimestampCheck boTimestampCheck = new BOTimestampCheck();
                        boTimestampCheck.SetProperties(
                                id,
                                model.Name,
                                model.Timestamp);
                        return boTimestampCheck;
                }

                public virtual ApiTimestampCheckResponseModel MapBOToModel(
                        BOTimestampCheck boTimestampCheck)
                {
                        var model = new ApiTimestampCheckResponseModel();

                        model.SetProperties(boTimestampCheck.Id, boTimestampCheck.Name, boTimestampCheck.Timestamp);

                        return model;
                }

                public virtual List<ApiTimestampCheckResponseModel> MapBOToModel(
                        List<BOTimestampCheck> items)
                {
                        List<ApiTimestampCheckResponseModel> response = new List<ApiTimestampCheckResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>2fe2971b6e8b50d761702a017eb7660f</Hash>
</Codenesium>*/