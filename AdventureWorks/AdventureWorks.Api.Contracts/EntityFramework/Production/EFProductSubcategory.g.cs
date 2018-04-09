using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductSubcategory", Schema="Production")]
	public partial class EFProductSubcategory
	{
		public EFProductSubcategory()
		{}

		public void SetProperties(int productSubcategoryID,
		                          int productCategoryID,
		                          string name,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			this.ProductSubcategoryID = productSubcategoryID.ToInt();
			this.ProductCategoryID = productCategoryID.ToInt();
			this.Name = name;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductSubcategoryID", TypeName="int")]
		public int ProductSubcategoryID {get; set;}

		[Column("ProductCategoryID", TypeName="int")]
		public int ProductCategoryID {get; set;}

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name {get; set;}

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFProductCategory ProductCategory { get; set; }
	}
}

/*<Codenesium>
    <Hash>6c30c049884c9fa9cb6cd04bbd7efc1a</Hash>
</Codenesium>*/