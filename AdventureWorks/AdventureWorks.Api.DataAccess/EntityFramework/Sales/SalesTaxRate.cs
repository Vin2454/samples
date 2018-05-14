using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesTaxRate", Schema="Sales")]
	public partial class SalesTaxRate: AbstractEntityFrameworkPOCO
	{
		public SalesTaxRate()
		{}

		public void SetProperties(
			int salesTaxRateID,
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			int stateProvinceID,
			decimal taxRate,
			int taxType)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
			this.Rowguid = rowguid.ToGuid();
			this.SalesTaxRateID = salesTaxRateID.ToInt();
			this.StateProvinceID = stateProvinceID.ToInt();
			this.TaxRate = taxRate.ToDecimal();
			this.TaxType = taxType.ToInt();
		}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Key]
		[Column("SalesTaxRateID", TypeName="int")]
		public int SalesTaxRateID { get; set; }

		[Column("StateProvinceID", TypeName="int")]
		public int StateProvinceID { get; set; }

		[Column("TaxRate", TypeName="smallmoney")]
		public decimal TaxRate { get; set; }

		[Column("TaxType", TypeName="tinyint")]
		public int TaxType { get; set; }
	}
}

/*<Codenesium>
    <Hash>7289826f8aa15c265945db57cee9e599</Hash>
</Codenesium>*/