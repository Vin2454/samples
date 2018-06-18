using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOShoppingCartItem: AbstractBusinessObject
        {
                public AbstractBOShoppingCartItem() : base()
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
    <Hash>c9b27615fba26268541d8b00252f6d6c</Hash>
</Codenesium>*/