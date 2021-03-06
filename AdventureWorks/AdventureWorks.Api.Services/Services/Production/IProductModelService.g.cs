using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IProductModelService
	{
		Task<CreateResponse<ApiProductModelResponseModel>> Create(
			ApiProductModelRequestModel model);

		Task<UpdateResponse<ApiProductModelResponseModel>> Update(int productModelID,
		                                                           ApiProductModelRequestModel model);

		Task<ActionResponse> Delete(int productModelID);

		Task<ApiProductModelResponseModel> Get(int productModelID);

		Task<List<ApiProductModelResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiProductModelResponseModel> ByName(string name);

		Task<List<ApiProductModelResponseModel>> ByCatalogDescription(string catalogDescription, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductModelResponseModel>> ByInstruction(string instruction, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductResponseModel>> ProductsByProductModelID(int productModelID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCulturesByProductModelID(int productModelID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductModelResponseModel>> ByIllustrationID(int productModelID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3c06ad6f685d4a30c229175d092e7c7d</Hash>
</Codenesium>*/