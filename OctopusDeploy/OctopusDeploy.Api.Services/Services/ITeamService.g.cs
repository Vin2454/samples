using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface ITeamService
        {
                Task<CreateResponse<ApiTeamResponseModel>> Create(
                        ApiTeamRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiTeamRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiTeamResponseModel> Get(string id);

                Task<List<ApiTeamResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiTeamResponseModel> ByName(string name);
        }
}

/*<Codenesium>
    <Hash>16dd02d7bf4d4e32be8cdbc6d371e6d3</Hash>
</Codenesium>*/