using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOCreditCard: AbstractBusinessObject
        {
                public BOCreditCard() : base()
                {
                }

                public void SetProperties(int creditCardID,
                                          string cardNumber,
                                          string cardType,
                                          int expMonth,
                                          short expYear,
                                          DateTime modifiedDate)
                {
                        this.CardNumber = cardNumber;
                        this.CardType = cardType;
                        this.CreditCardID = creditCardID;
                        this.ExpMonth = expMonth;
                        this.ExpYear = expYear;
                        this.ModifiedDate = modifiedDate;
                }

                public string CardNumber { get; private set; }

                public string CardType { get; private set; }

                public int CreditCardID { get; private set; }

                public int ExpMonth { get; private set; }

                public short ExpYear { get; private set; }

                public DateTime ModifiedDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b8181993e0eb7be55bbf24bd8766b0a1</Hash>
</Codenesium>*/