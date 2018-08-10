using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface ICommunityActionTemplateService
	{
		Task<CreateResponse<ApiCommunityActionTemplateResponseModel>> Create(
			ApiCommunityActionTemplateRequestModel model);

		Task<UpdateResponse<ApiCommunityActionTemplateResponseModel>> Update(string id,
		                                                                      ApiCommunityActionTemplateRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiCommunityActionTemplateResponseModel> Get(string id);

		Task<List<ApiCommunityActionTemplateResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiCommunityActionTemplateResponseModel> ByExternalId(Guid externalId);

		Task<ApiCommunityActionTemplateResponseModel> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>c271fd97f90e358275e3a825f590a06e</Hash>
</Codenesium>*/