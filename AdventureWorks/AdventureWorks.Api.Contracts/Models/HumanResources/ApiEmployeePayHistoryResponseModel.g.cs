using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiEmployeePayHistoryResponseModel: AbstractApiResponseModel
	{
		public ApiEmployeePayHistoryResponseModel() : base()
		{}

		public void SetProperties(
			int businessEntityID,
			DateTime modifiedDate,
			int payFrequency,
			decimal rate,
			DateTime rateChangeDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PayFrequency = payFrequency.ToInt();
			this.Rate = rate.ToDecimal();
			this.RateChangeDate = rateChangeDate.ToDateTime();
		}

		public int BusinessEntityID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int PayFrequency { get; set; }
		public decimal Rate { get; set; }
		public DateTime RateChangeDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return this.ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePayFrequencyValue { get; set; } = true;

		public bool ShouldSerializePayFrequency()
		{
			return this.ShouldSerializePayFrequencyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRateValue { get; set; } = true;

		public bool ShouldSerializeRate()
		{
			return this.ShouldSerializeRateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRateChangeDateValue { get; set; } = true;

		public bool ShouldSerializeRateChangeDate()
		{
			return this.ShouldSerializeRateChangeDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializePayFrequencyValue = false;
			this.ShouldSerializeRateValue = false;
			this.ShouldSerializeRateChangeDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>136b3585baa858e0ea00f13d83a74fd8</Hash>
</Codenesium>*/