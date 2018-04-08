using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOSalesPerson
	{
		public POCOSalesPerson()
		{}

		public POCOSalesPerson(int businessEntityID,
		                       Nullable<int> territoryID,
		                       Nullable<decimal> salesQuota,
		                       decimal bonus,
		                       decimal commissionPct,
		                       decimal salesYTD,
		                       decimal salesLastYear,
		                       Guid rowguid,
		                       DateTime modifiedDate)
		{
			this.SalesQuota = salesQuota;
			this.Bonus = bonus;
			this.CommissionPct = commissionPct;
			this.SalesYTD = salesYTD;
			this.SalesLastYear = salesLastYear;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();

			BusinessEntityID = new ReferenceEntity<int>(businessEntityID,
			                                            "Employee");
			TerritoryID = new ReferenceEntity<Nullable<int>>(territoryID,
			                                                 "SalesTerritory");
		}

		public ReferenceEntity<int>BusinessEntityID {get; set;}
		public ReferenceEntity<Nullable<int>>TerritoryID {get; set;}
		public Nullable<decimal> SalesQuota {get; set;}
		public decimal Bonus {get; set;}
		public decimal CommissionPct {get; set;}
		public decimal SalesYTD {get; set;}
		public decimal SalesLastYear {get; set;}
		public Guid Rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue {get; set;} = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTerritoryIDValue {get; set;} = true;

		public bool ShouldSerializeTerritoryID()
		{
			return ShouldSerializeTerritoryIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesQuotaValue {get; set;} = true;

		public bool ShouldSerializeSalesQuota()
		{
			return ShouldSerializeSalesQuotaValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeBonusValue {get; set;} = true;

		public bool ShouldSerializeBonus()
		{
			return ShouldSerializeBonusValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCommissionPctValue {get; set;} = true;

		public bool ShouldSerializeCommissionPct()
		{
			return ShouldSerializeCommissionPctValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesYTDValue {get; set;} = true;

		public bool ShouldSerializeSalesYTD()
		{
			return ShouldSerializeSalesYTDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesLastYearValue {get; set;} = true;

		public bool ShouldSerializeSalesLastYear()
		{
			return ShouldSerializeSalesLastYearValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue {get; set;} = true;

		public bool ShouldSerializeRowguid()
		{
			return ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeTerritoryIDValue = false;
			this.ShouldSerializeSalesQuotaValue = false;
			this.ShouldSerializeBonusValue = false;
			this.ShouldSerializeCommissionPctValue = false;
			this.ShouldSerializeSalesYTDValue = false;
			this.ShouldSerializeSalesLastYearValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>1408b7bf6b0909e82f20fb130062c1b1</Hash>
</Codenesium>*/