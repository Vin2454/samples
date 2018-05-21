using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SpecialOffer", Schema="Sales")]
	public partial class SpecialOffer: AbstractEntityFrameworkPOCO
	{
		public SpecialOffer()
		{}

		public void SetProperties(
			int specialOfferID,
			string category,
			string description,
			decimal discountPct,
			DateTime endDate,
			Nullable<int> maxQty,
			int minQty,
			DateTime modifiedDate,
			Guid rowguid,
			DateTime startDate,
			string type)
		{
			this.Category = category;
			this.Description = description;
			this.DiscountPct = discountPct.ToDecimal();
			this.EndDate = endDate.ToDateTime();
			this.MaxQty = maxQty.ToNullableInt();
			this.MinQty = minQty.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Rowguid = rowguid.ToGuid();
			this.SpecialOfferID = specialOfferID.ToInt();
			this.StartDate = startDate.ToDateTime();
			this.Type = type;
		}

		[Column("Category", TypeName="nvarchar(50)")]
		public string Category { get; set; }

		[Column("Description", TypeName="nvarchar(255)")]
		public string Description { get; set; }

		[Column("DiscountPct", TypeName="smallmoney")]
		public decimal DiscountPct { get; set; }

		[Column("EndDate", TypeName="datetime")]
		public DateTime EndDate { get; set; }

		[Column("MaxQty", TypeName="int")]
		public Nullable<int> MaxQty { get; set; }

		[Column("MinQty", TypeName="int")]
		public int MinQty { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Key]
		[Column("SpecialOfferID", TypeName="int")]
		public int SpecialOfferID { get; set; }

		[Column("StartDate", TypeName="datetime")]
		public DateTime StartDate { get; set; }

		[Column("Type", TypeName="nvarchar(50)")]
		public string Type { get; set; }
	}
}

/*<Codenesium>
    <Hash>cc3c4b644de7d96e963cbf9699469b25</Hash>
</Codenesium>*/