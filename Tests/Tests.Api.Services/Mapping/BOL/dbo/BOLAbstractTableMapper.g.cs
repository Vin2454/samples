using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public abstract class BOLAbstractTableMapper
        {
                public virtual BOTable MapModelToBO(
                        int id,
                        ApiTableRequestModel model
                        )
                {
                        BOTable boTable = new BOTable();
                        boTable.SetProperties(
                                id,
                                model.Name);
                        return boTable;
                }

                public virtual ApiTableResponseModel MapBOToModel(
                        BOTable boTable)
                {
                        var model = new ApiTableResponseModel();

                        model.SetProperties(boTable.Id, boTable.Name);

                        return model;
                }

                public virtual List<ApiTableResponseModel> MapBOToModel(
                        List<BOTable> items)
                {
                        List<ApiTableResponseModel> response = new List<ApiTableResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>b322f71c52608f45c85fa3383e9853f8</Hash>
</Codenesium>*/