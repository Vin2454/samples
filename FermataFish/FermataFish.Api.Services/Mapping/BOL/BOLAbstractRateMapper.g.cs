using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public abstract class BOLAbstractRateMapper
        {
                public virtual BORate MapModelToBO(
                        int id,
                        ApiRateRequestModel model
                        )
                {
                        BORate boRate = new BORate();

                        boRate.SetProperties(
                                id,
                                model.AmountPerMinute,
                                model.TeacherId,
                                model.TeacherSkillId);
                        return boRate;
                }

                public virtual ApiRateResponseModel MapBOToModel(
                        BORate boRate)
                {
                        var model = new ApiRateResponseModel();

                        model.SetProperties(boRate.AmountPerMinute, boRate.Id, boRate.TeacherId, boRate.TeacherSkillId);

                        return model;
                }

                public virtual List<ApiRateResponseModel> MapBOToModel(
                        List<BORate> items)
                {
                        List<ApiRateResponseModel> response = new List<ApiRateResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>e9cfabf099b973e7fc6cdbf4a32ea9c0</Hash>
</Codenesium>*/