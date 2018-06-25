using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IProjectService
        {
                Task<CreateResponse<ApiProjectResponseModel>> Create(
                        ApiProjectRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiProjectRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiProjectResponseModel> Get(string id);

                Task<List<ApiProjectResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiProjectResponseModel> ByName(string name);

                Task<ApiProjectResponseModel> BySlug(string slug);

                Task<List<ApiProjectResponseModel>> ByDataVersion(byte[] dataVersion);

                Task<List<ApiProjectResponseModel>> ByDiscreteChannelReleaseId(bool discreteChannelRelease, string id);
        }
}

/*<Codenesium>
    <Hash>631355a5b04a210dbe17c58166a321a6</Hash>
</Codenesium>*/