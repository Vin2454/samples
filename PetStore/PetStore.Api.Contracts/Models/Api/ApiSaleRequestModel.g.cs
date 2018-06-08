using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace PetStoreNS.Api.Contracts
{
        public partial class ApiSaleRequestModel: AbstractApiRequestModel
        {
                public ApiSaleRequestModel() : base()
                {
                }

                public void SetProperties(
                        decimal amount,
                        string firstName,
                        string lastName,
                        int paymentTypeId,
                        int petId,
                        string phone)
                {
                        this.Amount = amount;
                        this.FirstName = firstName;
                        this.LastName = lastName;
                        this.PaymentTypeId = paymentTypeId;
                        this.PetId = petId;
                        this.Phone = phone;
                }

                private decimal amount;

                [Required]
                public decimal Amount
                {
                        get
                        {
                                return this.amount;
                        }

                        set
                        {
                                this.amount = value;
                        }
                }

                private string firstName;

                [Required]
                public string FirstName
                {
                        get
                        {
                                return this.firstName;
                        }

                        set
                        {
                                this.firstName = value;
                        }
                }

                private string lastName;

                [Required]
                public string LastName
                {
                        get
                        {
                                return this.lastName;
                        }

                        set
                        {
                                this.lastName = value;
                        }
                }

                private int paymentTypeId;

                [Required]
                public int PaymentTypeId
                {
                        get
                        {
                                return this.paymentTypeId;
                        }

                        set
                        {
                                this.paymentTypeId = value;
                        }
                }

                private int petId;

                [Required]
                public int PetId
                {
                        get
                        {
                                return this.petId;
                        }

                        set
                        {
                                this.petId = value;
                        }
                }

                private string phone;

                [Required]
                public string Phone
                {
                        get
                        {
                                return this.phone;
                        }

                        set
                        {
                                this.phone = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>bbe1246f871585b35d17f3228f5bf45c</Hash>
</Codenesium>*/