using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("SalesPersonQuotaHistory", Schema="Sales")]
	public partial class EFSalesPersonQuotaHistory
	{
		public EFSalesPersonQuotaHistory()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID {get; set;}
		[Column("QuotaDate", TypeName="datetime")]
		public DateTime QuotaDate {get; set;}
		[Column("SalesQuota", TypeName="money")]
		public decimal SalesQuota {get; set;}
		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}
		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("BusinessEntityID")]
		public virtual EFSalesPerson SalesPersonRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>34720ca90078f833e88cd4e05090e83f</Hash>
</Codenesium>*/