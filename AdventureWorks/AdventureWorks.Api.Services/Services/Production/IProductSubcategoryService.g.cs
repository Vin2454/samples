using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IProductSubcategoryService
        {
                Task<CreateResponse<ApiProductSubcategoryResponseModel>> Create(
                        ApiProductSubcategoryRequestModel model);

                Task<ActionResponse> Update(int productSubcategoryID,
                                            ApiProductSubcategoryRequestModel model);

                Task<ActionResponse> Delete(int productSubcategoryID);

                Task<ApiProductSubcategoryResponseModel> Get(int productSubcategoryID);

                Task<List<ApiProductSubcategoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiProductSubcategoryResponseModel> ByName(string name);

                Task<List<ApiProductResponseModel>> Products(int productSubcategoryID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>7b294b6177b48285bde57082ad521aec</Hash>
</Codenesium>*/