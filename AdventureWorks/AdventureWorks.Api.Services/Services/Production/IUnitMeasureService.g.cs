using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IUnitMeasureService
        {
                Task<CreateResponse<ApiUnitMeasureResponseModel>> Create(
                        ApiUnitMeasureRequestModel model);

                Task<ActionResponse> Update(string unitMeasureCode,
                                            ApiUnitMeasureRequestModel model);

                Task<ActionResponse> Delete(string unitMeasureCode);

                Task<ApiUnitMeasureResponseModel> Get(string unitMeasureCode);

                Task<List<ApiUnitMeasureResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiUnitMeasureResponseModel> ByName(string name);

                Task<List<ApiBillOfMaterialsResponseModel>> BillOfMaterials(string unitMeasureCode, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiProductResponseModel>> Products(string sizeUnitMeasureCode, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>5a9dbc2d70c135fc543e9607bda3f2f2</Hash>
</Codenesium>*/