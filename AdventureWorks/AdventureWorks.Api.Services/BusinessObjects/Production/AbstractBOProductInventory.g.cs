using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOProductInventory : AbstractBusinessObject
	{
		public AbstractBOProductInventory()
			: base()
		{
		}

		public virtual void SetProperties(int productID,
		                                  int bin,
		                                  short locationID,
		                                  DateTime modifiedDate,
		                                  short quantity,
		                                  Guid rowguid,
		                                  string shelf)
		{
			this.Bin = bin;
			this.LocationID = locationID;
			this.ModifiedDate = modifiedDate;
			this.ProductID = productID;
			this.Quantity = quantity;
			this.Rowguid = rowguid;
			this.Shelf = shelf;
		}

		public int Bin { get; private set; }

		public short LocationID { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public int ProductID { get; private set; }

		public short Quantity { get; private set; }

		public Guid Rowguid { get; private set; }

		public string Shelf { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b45f7ceb0d9eb5d9c65c13fec7ee495c</Hash>
</Codenesium>*/