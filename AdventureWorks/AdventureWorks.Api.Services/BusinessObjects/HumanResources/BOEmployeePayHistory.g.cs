using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
	public partial class BOEmployeePayHistory: AbstractBusinessObject
	{
		public BOEmployeePayHistory() : base()
		{}

		public void SetProperties(int businessEntityID,
		                          DateTime modifiedDate,
		                          int payFrequency,
		                          decimal rate,
		                          DateTime rateChangeDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PayFrequency = payFrequency.ToInt();
			this.Rate = rate.ToDecimal();
			this.RateChangeDate = rateChangeDate.ToDateTime();
		}

		public int BusinessEntityID { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public int PayFrequency { get; private set; }
		public decimal Rate { get; private set; }
		public DateTime RateChangeDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>999f17010ece9b25abd52e2847a91a62</Hash>
</Codenesium>*/