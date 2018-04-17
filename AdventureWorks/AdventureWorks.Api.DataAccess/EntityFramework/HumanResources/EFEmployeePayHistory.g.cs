using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("EmployeePayHistory", Schema="HumanResources")]
	public partial class EFEmployeePayHistory
	{
		public EFEmployeePayHistory()
		{}

		public void SetProperties(
			int businessEntityID,
			DateTime rateChangeDate,
			decimal rate,
			int payFrequency,
			DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.RateChangeDate = rateChangeDate.ToDateTime();
			this.Rate = rate.ToDecimal();
			this.PayFrequency = payFrequency.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("RateChangeDate", TypeName="datetime")]
		public DateTime RateChangeDate { get; set; }

		[Column("Rate", TypeName="money")]
		public decimal Rate { get; set; }

		[Column("PayFrequency", TypeName="tinyint")]
		public int PayFrequency { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("BusinessEntityID")]
		public virtual EFEmployee Employee { get; set; }
	}
}

/*<Codenesium>
    <Hash>270d7ab10b19b7e8e5ad2f8883ff3517</Hash>
</Codenesium>*/