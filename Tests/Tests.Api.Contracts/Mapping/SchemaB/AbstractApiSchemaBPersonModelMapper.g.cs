using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
        public abstract class AbstractApiSchemaBPersonModelMapper
        {
                public virtual ApiSchemaBPersonResponseModel MapRequestToResponse(
                        int id,
                        ApiSchemaBPersonRequestModel request)
                {
                        var response = new ApiSchemaBPersonResponseModel();
                        response.SetProperties(id,
                                               request.Name);
                        return response;
                }

                public virtual ApiSchemaBPersonRequestModel MapResponseToRequest(
                        ApiSchemaBPersonResponseModel response)
                {
                        var request = new ApiSchemaBPersonRequestModel();
                        request.SetProperties(
                                response.Name);
                        return request;
                }

                public JsonPatchDocument<ApiSchemaBPersonRequestModel> CreatePatch(ApiSchemaBPersonRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiSchemaBPersonRequestModel>();
                        patch.Replace(x => x.Name, model.Name);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>1fa7e4dc047ed02357a16df42b527645</Hash>
</Codenesium>*/