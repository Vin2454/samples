using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSalesPerson
	{
		Task<CreateResponse<POCOSalesPerson>> Create(
			ApiSalesPersonModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiSalesPersonModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		POCOSalesPerson Get(int businessEntityID);

		List<POCOSalesPerson> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>12fcb32de6e2fcd07c4e6f3ce07a71a1</Hash>
</Codenesium>*/