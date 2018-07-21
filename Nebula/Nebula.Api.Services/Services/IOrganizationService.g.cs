using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public interface IOrganizationService
        {
                Task<CreateResponse<ApiOrganizationResponseModel>> Create(
                        ApiOrganizationRequestModel model);

                Task<UpdateResponse<ApiOrganizationResponseModel>> Update(int id,
                                                                           ApiOrganizationRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiOrganizationResponseModel> Get(int id);

                Task<List<ApiOrganizationResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiTeamResponseModel>> Teams(int organizationId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>39b0235b6db9d635be8709aa408eab73</Hash>
</Codenesium>*/