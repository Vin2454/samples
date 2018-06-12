using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractMutexMapper
        {
                public virtual BOMutex MapModelToBO(
                        string id,
                        ApiMutexRequestModel model
                        )
                {
                        BOMutex boMutex = new BOMutex();

                        boMutex.SetProperties(
                                id,
                                model.JSON);
                        return boMutex;
                }

                public virtual ApiMutexResponseModel MapBOToModel(
                        BOMutex boMutex)
                {
                        var model = new ApiMutexResponseModel();

                        model.SetProperties(boMutex.Id, boMutex.JSON);

                        return model;
                }

                public virtual List<ApiMutexResponseModel> MapBOToModel(
                        List<BOMutex> items)
                {
                        List<ApiMutexResponseModel> response = new List<ApiMutexResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>fde21cc813797e6ca34eb32bd0dc6d72</Hash>
</Codenesium>*/