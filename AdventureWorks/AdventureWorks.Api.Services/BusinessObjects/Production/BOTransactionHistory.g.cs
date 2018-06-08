using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOTransactionHistory: AbstractBusinessObject
        {
                public BOTransactionHistory() : base()
                {
                }

                public void SetProperties(int transactionID,
                                          decimal actualCost,
                                          DateTime modifiedDate,
                                          int productID,
                                          int quantity,
                                          int referenceOrderID,
                                          int referenceOrderLineID,
                                          DateTime transactionDate,
                                          string transactionType)
                {
                        this.ActualCost = actualCost;
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                        this.Quantity = quantity;
                        this.ReferenceOrderID = referenceOrderID;
                        this.ReferenceOrderLineID = referenceOrderLineID;
                        this.TransactionDate = transactionDate;
                        this.TransactionID = transactionID;
                        this.TransactionType = transactionType;
                }

                public decimal ActualCost { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductID { get; private set; }

                public int Quantity { get; private set; }

                public int ReferenceOrderID { get; private set; }

                public int ReferenceOrderLineID { get; private set; }

                public DateTime TransactionDate { get; private set; }

                public int TransactionID { get; private set; }

                public string TransactionType { get; private set; }
        }
}

/*<Codenesium>
    <Hash>896b3f8df0dbe5c9ee40b3fcf71fbe16</Hash>
</Codenesium>*/