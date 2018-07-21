using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface ICustomerService
        {
                Task<CreateResponse<ApiCustomerResponseModel>> Create(
                        ApiCustomerRequestModel model);

                Task<UpdateResponse<ApiCustomerResponseModel>> Update(int customerID,
                                                                       ApiCustomerRequestModel model);

                Task<ActionResponse> Delete(int customerID);

                Task<ApiCustomerResponseModel> Get(int customerID);

                Task<List<ApiCustomerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiCustomerResponseModel> ByAccountNumber(string accountNumber);

                Task<List<ApiCustomerResponseModel>> ByTerritoryID(int? territoryID);

                Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaders(int customerID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>e1c150d074b919397b4e277c6fb8a0a1</Hash>
</Codenesium>*/