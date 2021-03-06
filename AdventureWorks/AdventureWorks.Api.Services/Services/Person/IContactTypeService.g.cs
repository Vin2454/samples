using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IContactTypeService
	{
		Task<CreateResponse<ApiContactTypeResponseModel>> Create(
			ApiContactTypeRequestModel model);

		Task<UpdateResponse<ApiContactTypeResponseModel>> Update(int contactTypeID,
		                                                          ApiContactTypeRequestModel model);

		Task<ActionResponse> Delete(int contactTypeID);

		Task<ApiContactTypeResponseModel> Get(int contactTypeID);

		Task<List<ApiContactTypeResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiContactTypeResponseModel> ByName(string name);

		Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContactsByContactTypeID(int contactTypeID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0adda74e00b2c1d54bbaaed3866ecaa8</Hash>
</Codenesium>*/