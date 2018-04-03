using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOStore
	{
		public POCOStore()
		{}

		public POCOStore(int businessEntityID,
		                 string name,
		                 Nullable<int> salesPersonID,
		                 string demographics,
		                 Guid rowguid,
		                 DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.Name = name;
			this.SalesPersonID = salesPersonID.ToNullableInt();
			this.Demographics = demographics;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int BusinessEntityID {get; set;}
		public string Name {get; set;}
		public Nullable<int> SalesPersonID {get; set;}
		public string Demographics {get; set;}
		public Guid Rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue {get; set;} = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesPersonIDValue {get; set;} = true;

		public bool ShouldSerializeSalesPersonID()
		{
			return ShouldSerializeSalesPersonIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDemographicsValue {get; set;} = true;

		public bool ShouldSerializeDemographics()
		{
			return ShouldSerializeDemographicsValue;
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
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeSalesPersonIDValue = false;
			this.ShouldSerializeDemographicsValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>5963c1a6bf4b6c9452605ddcf37387c0</Hash>
</Codenesium>*/