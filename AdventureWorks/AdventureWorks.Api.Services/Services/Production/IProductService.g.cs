using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IProductService
	{
		Task<CreateResponse<ApiProductResponseModel>> Create(
			ApiProductRequestModel model);

		Task<ActionResponse> Update(int productID,
		                            ApiProductRequestModel model);

		Task<ActionResponse> Delete(int productID);

		Task<ApiProductResponseModel> Get(int productID);

		Task<List<ApiProductResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiProductResponseModel> GetName(string name);
		Task<ApiProductResponseModel> GetProductNumber(string productNumber);
	}
}

/*<Codenesium>
    <Hash>b29e2986bb05db3b202c320caffc9a54</Hash>
</Codenesium>*/