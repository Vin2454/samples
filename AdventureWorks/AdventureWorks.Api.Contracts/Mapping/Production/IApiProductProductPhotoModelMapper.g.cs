using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductProductPhotoModelMapper
        {
                ApiProductProductPhotoResponseModel MapRequestToResponse(
                        int productID,
                        ApiProductProductPhotoRequestModel request);

                ApiProductProductPhotoRequestModel MapResponseToRequest(
                        ApiProductProductPhotoResponseModel response);

                JsonPatchDocument<ApiProductProductPhotoRequestModel> CreatePatch(ApiProductProductPhotoRequestModel model);
        }
}

/*<Codenesium>
    <Hash>41dad66f52253466ba5c6b5838648dea</Hash>
</Codenesium>*/