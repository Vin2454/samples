using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public interface ILinkService
        {
                Task<CreateResponse<ApiLinkResponseModel>> Create(
                        ApiLinkRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiLinkRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiLinkResponseModel> Get(int id);

                Task<List<ApiLinkResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>8322243e3bfea3ce0c1aba3c338b0b98</Hash>
</Codenesium>*/