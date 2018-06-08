using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface ITransactionHistoryService
        {
                Task<CreateResponse<ApiTransactionHistoryResponseModel>> Create(
                        ApiTransactionHistoryRequestModel model);

                Task<ActionResponse> Update(int transactionID,
                                            ApiTransactionHistoryRequestModel model);

                Task<ActionResponse> Delete(int transactionID);

                Task<ApiTransactionHistoryResponseModel> Get(int transactionID);

                Task<List<ApiTransactionHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<ApiTransactionHistoryResponseModel>> GetProductID(int productID);
                Task<List<ApiTransactionHistoryResponseModel>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID);
        }
}

/*<Codenesium>
    <Hash>d604315832e79cf74fe95e5b23036fb6</Hash>
</Codenesium>*/