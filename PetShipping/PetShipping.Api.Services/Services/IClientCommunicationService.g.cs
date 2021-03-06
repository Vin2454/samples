using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IClientCommunicationService
	{
		Task<CreateResponse<ApiClientCommunicationResponseModel>> Create(
			ApiClientCommunicationRequestModel model);

		Task<UpdateResponse<ApiClientCommunicationResponseModel>> Update(int id,
		                                                                  ApiClientCommunicationRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiClientCommunicationResponseModel> Get(int id);

		Task<List<ApiClientCommunicationResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>70b08df89c19e9d5438aed9028269c22</Hash>
</Codenesium>*/