using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public interface IChainService
        {
                Task<CreateResponse<ApiChainResponseModel>> Create(
                        ApiChainRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiChainRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiChainResponseModel> Get(int id);

                Task<List<ApiChainResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiClaspResponseModel>> Clasps(int nextChainId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiLinkResponseModel>> Links(int chainId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>6daccffc38d656d820ea064b50de637b</Hash>
</Codenesium>*/