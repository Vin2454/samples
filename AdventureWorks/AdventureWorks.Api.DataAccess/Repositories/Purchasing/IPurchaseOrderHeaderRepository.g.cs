using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IPurchaseOrderHeaderRepository
	{
		Task<PurchaseOrderHeader> Create(PurchaseOrderHeader item);

		Task Update(PurchaseOrderHeader item);

		Task Delete(int purchaseOrderID);

		Task<PurchaseOrderHeader> Get(int purchaseOrderID);

		Task<List<PurchaseOrderHeader>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<PurchaseOrderHeader>> ByEmployeeID(int employeeID, int limit = int.MaxValue, int offset = 0);

		Task<List<PurchaseOrderHeader>> ByVendorID(int vendorID, int limit = int.MaxValue, int offset = 0);

		Task<List<PurchaseOrderDetail>> PurchaseOrderDetailsByPurchaseOrderID(int purchaseOrderID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8e6fbcf91a5790aacb62b1a2312c4da3</Hash>
</Codenesium>*/