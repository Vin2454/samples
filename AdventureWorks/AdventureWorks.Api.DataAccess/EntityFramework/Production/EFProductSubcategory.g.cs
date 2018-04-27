using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductSubcategory", Schema="Production")]
	public partial class EFProductSubcategory: AbstractEntityFrameworkPOCO
	{
		public EFProductSubcategory()
		{}

		public void SetProperties(
			int productSubcategoryID,
			DateTime modifiedDate,
			string name,
			int productCategoryID,
			Guid rowguid)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
			this.ProductCategoryID = productCategoryID.ToInt();
			this.ProductSubcategoryID = productSubcategoryID.ToInt();
			this.Rowguid = rowguid.ToGuid();
		}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("ProductCategoryID", TypeName="int")]
		public int ProductCategoryID { get; set; }

		[Key]
		[Column("ProductSubcategoryID", TypeName="int")]
		public int ProductSubcategoryID { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[ForeignKey("ProductCategoryID")]
		public virtual EFProductCategory ProductCategory { get; set; }
	}
}

/*<Codenesium>
    <Hash>19a18cca3d5f338ea73e0f3210b2a341</Hash>
</Codenesium>*/