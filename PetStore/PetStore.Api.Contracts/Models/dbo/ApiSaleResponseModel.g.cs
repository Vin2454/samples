using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetStoreNS.Api.Contracts
{
	public partial class ApiSaleResponseModel: AbstractApiResponseModel
	{
		public ApiSaleResponseModel() : base()
		{}

		public void SetProperties(
			decimal amount,
			string firstName,
			int id,
			string lastName,
			int paymentTypeId,
			int petId,
			string phone)
		{
			this.Amount = amount.ToDecimal();
			this.FirstName = firstName;
			this.Id = id.ToInt();
			this.LastName = lastName;
			this.Phone = phone;

			this.PaymentTypeId = new ReferenceEntity<int>(paymentTypeId,
			                                              nameof(ApiResponse.PaymentTypes));
			this.PetId = new ReferenceEntity<int>(petId,
			                                      nameof(ApiResponse.Pets));
		}

		public decimal Amount { get; set; }
		public string FirstName { get; set; }
		public int Id { get; set; }
		public string LastName { get; set; }
		public ReferenceEntity<int> PaymentTypeId { get; set; }
		public ReferenceEntity<int> PetId { get; set; }
		public string Phone { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeAmountValue { get; set; } = true;

		public bool ShouldSerializeAmount()
		{
			return this.ShouldSerializeAmountValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFirstNameValue { get; set; } = true;

		public bool ShouldSerializeFirstName()
		{
			return this.ShouldSerializeFirstNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLastNameValue { get; set; } = true;

		public bool ShouldSerializeLastName()
		{
			return this.ShouldSerializeLastNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePaymentTypeIdValue { get; set; } = true;

		public bool ShouldSerializePaymentTypeId()
		{
			return this.ShouldSerializePaymentTypeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePetIdValue { get; set; } = true;

		public bool ShouldSerializePetId()
		{
			return this.ShouldSerializePetIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePhoneValue { get; set; } = true;

		public bool ShouldSerializePhone()
		{
			return this.ShouldSerializePhoneValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeAmountValue = false;
			this.ShouldSerializeFirstNameValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeLastNameValue = false;
			this.ShouldSerializePaymentTypeIdValue = false;
			this.ShouldSerializePetIdValue = false;
			this.ShouldSerializePhoneValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>3711923fd274af7380f841d1966d0ffd</Hash>
</Codenesium>*/