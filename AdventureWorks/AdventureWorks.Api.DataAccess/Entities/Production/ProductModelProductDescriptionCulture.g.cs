using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductModelProductDescriptionCulture", Schema="Production")]
	public partial class ProductModelProductDescriptionCulture : AbstractEntity
	{
		public ProductModelProductDescriptionCulture()
		{
		}

		public virtual void SetProperties(
			string cultureID,
			DateTime modifiedDate,
			int productDescriptionID,
			int productModelID)
		{
			this.CultureID = cultureID;
			this.ModifiedDate = modifiedDate;
			this.ProductDescriptionID = productDescriptionID;
			this.ProductModelID = productModelID;
		}

		[MaxLength(6)]
		[Column("CultureID")]
		public string CultureID { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[Column("ProductDescriptionID")]
		public int ProductDescriptionID { get; private set; }

		[Key]
		[Column("ProductModelID")]
		public int ProductModelID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>bae449d17c28c807e1f472b3147c4729</Hash>
</Codenesium>*/