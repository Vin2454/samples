using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOShoppingCartItem : AbstractBusinessObject
	{
		public AbstractBOShoppingCartItem()
			: base()
		{
		}

		public virtual void SetProperties(int shoppingCartItemID,
		                                  DateTime dateCreated,
		                                  DateTime modifiedDate,
		                                  int productID,
		                                  int quantity,
		                                  string shoppingCartID)
		{
			this.DateCreated = dateCreated;
			this.ModifiedDate = modifiedDate;
			this.ProductID = productID;
			this.Quantity = quantity;
			this.ShoppingCartID = shoppingCartID;
			this.ShoppingCartItemID = shoppingCartItemID;
		}

		public DateTime DateCreated { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public int ProductID { get; private set; }

		public int Quantity { get; private set; }

		public string ShoppingCartID { get; private set; }

		public int ShoppingCartItemID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1fec79f4d6895e9263f0f606276d28fe</Hash>
</Codenesium>*/