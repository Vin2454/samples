using Codenesium.DataConversionExtensions;
using System;

namespace PetStoreNS.Api.Services
{
        public abstract class AbstractBOSale : AbstractBusinessObject
        {
                public AbstractBOSale()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  decimal amount,
                                                  string firstName,
                                                  string lastName,
                                                  int paymentTypeId,
                                                  int petId,
                                                  string phone)
                {
                        this.Amount = amount;
                        this.FirstName = firstName;
                        this.Id = id;
                        this.LastName = lastName;
                        this.PaymentTypeId = paymentTypeId;
                        this.PetId = petId;
                        this.Phone = phone;
                }

                public decimal Amount { get; private set; }

                public string FirstName { get; private set; }

                public int Id { get; private set; }

                public string LastName { get; private set; }

                public int PaymentTypeId { get; private set; }

                public int PetId { get; private set; }

                public string Phone { get; private set; }
        }
}

/*<Codenesium>
    <Hash>24482179aa4b6fc8d5a73a446d65ed2d</Hash>
</Codenesium>*/