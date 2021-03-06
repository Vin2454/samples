using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiCurrencyModelMapper
	{
		public virtual ApiCurrencyResponseModel MapRequestToResponse(
			string currencyCode,
			ApiCurrencyRequestModel request)
		{
			var response = new ApiCurrencyResponseModel();
			response.SetProperties(currencyCode,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiCurrencyRequestModel MapResponseToRequest(
			ApiCurrencyResponseModel response)
		{
			var request = new ApiCurrencyRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiCurrencyRequestModel> CreatePatch(ApiCurrencyRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCurrencyRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>02f5af4cb47786555a9807b9cd54696e</Hash>
</Codenesium>*/