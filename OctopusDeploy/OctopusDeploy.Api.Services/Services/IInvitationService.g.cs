using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IInvitationService
	{
		Task<CreateResponse<ApiInvitationResponseModel>> Create(
			ApiInvitationRequestModel model);

		Task<UpdateResponse<ApiInvitationResponseModel>> Update(string id,
		                                                         ApiInvitationRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiInvitationResponseModel> Get(string id);

		Task<List<ApiInvitationResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c6aee37730be00bd8e539a6acd713df0</Hash>
</Codenesium>*/