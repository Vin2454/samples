using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductSubcategory", Schema="Production")]
	public partial class ProductSubcategory : AbstractEntity
	{
		public ProductSubcategory()
		{
		}

		public virtual void SetProperties(
			DateTime modifiedDate,
			string name,
			int productCategoryID,
			int productSubcategoryID,
			Guid rowguid)
		{
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.ProductCategoryID = productCategoryID;
			this.ProductSubcategoryID = productSubcategoryID;
			this.Rowguid = rowguid;
		}

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public string Name { get; private set; }

		[Column("ProductCategoryID")]
		public int ProductCategoryID { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductSubcategoryID")]
		public int ProductSubcategoryID { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid")]
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>cb34b6e4714cba6069522080ae581ac3</Hash>
</Codenesium>*/