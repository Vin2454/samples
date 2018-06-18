using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IProjectTriggerService
        {
                Task<CreateResponse<ApiProjectTriggerResponseModel>> Create(
                        ApiProjectTriggerRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiProjectTriggerRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiProjectTriggerResponseModel> Get(string id);

                Task<List<ApiProjectTriggerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiProjectTriggerResponseModel> GetProjectIdName(string projectId, string name);
                Task<List<ApiProjectTriggerResponseModel>> GetProjectId(string projectId);
        }
}

/*<Codenesium>
    <Hash>361ebc38ba27ec09bb737c85c8d3cc3d</Hash>
</Codenesium>*/