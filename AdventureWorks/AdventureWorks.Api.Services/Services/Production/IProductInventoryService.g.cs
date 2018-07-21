using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IProductInventoryService
        {
                Task<CreateResponse<ApiProductInventoryResponseModel>> Create(
                        ApiProductInventoryRequestModel model);

                Task<UpdateResponse<ApiProductInventoryResponseModel>> Update(int productID,
                                                                               ApiProductInventoryRequestModel model);

                Task<ActionResponse> Delete(int productID);

                Task<ApiProductInventoryResponseModel> Get(int productID);

                Task<List<ApiProductInventoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>860586099d51fe20c37822f6fa51087e</Hash>
</Codenesium>*/