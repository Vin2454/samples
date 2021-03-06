using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("vProductAndDescription", Schema="Production")]
	public partial class VProductAndDescription : AbstractEntity
	{
		public VProductAndDescription()
		{
		}

		public virtual void SetProperties(
			string cultureID,
			string description,
			string name,
			int productID,
			string productModel)
		{
			this.CultureID = cultureID;
			this.Description = description;
			this.Name = name;
			this.ProductID = productID;
			this.ProductModel = productModel;
		}

		[Key]
		[MaxLength(6)]
		[Column("CultureID")]
		public string CultureID { get; private set; }

		[MaxLength(400)]
		[Column("Description")]
		public string Description { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public string Name { get; private set; }

		[Key]
		[Column("ProductID")]
		public int ProductID { get; private set; }

		[MaxLength(50)]
		[Column("ProductModel")]
		public string ProductModel { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f1a824ae070cbefe3208bb0ad56b23b6</Hash>
</Codenesium>*/