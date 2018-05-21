using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOCreditCard
	{
		Task<CreateResponse<POCOCreditCard>> Create(
			ApiCreditCardModel model);

		Task<ActionResponse> Update(int creditCardID,
		                            ApiCreditCardModel model);

		Task<ActionResponse> Delete(int creditCardID);

		Task<POCOCreditCard> Get(int creditCardID);

		Task<List<POCOCreditCard>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOCreditCard> GetCardNumber(string cardNumber);
	}
}

/*<Codenesium>
    <Hash>99d9ff25d48ef530486cffc0ff974d79</Hash>
</Codenesium>*/