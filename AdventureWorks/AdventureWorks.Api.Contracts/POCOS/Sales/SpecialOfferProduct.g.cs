using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOSpecialOfferProduct
	{
		public POCOSpecialOfferProduct()
		{}

		public POCOSpecialOfferProduct(int specialOfferID,
		                               int productID,
		                               Guid rowguid,
		                               DateTime modifiedDate)
		{
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();

			SpecialOfferID = new ReferenceEntity<int>(specialOfferID,
			                                          "SpecialOffer");
			ProductID = new ReferenceEntity<int>(productID,
			                                     "Product");
		}

		public ReferenceEntity<int>SpecialOfferID {get; set;}
		public ReferenceEntity<int>ProductID {get; set;}
		public Guid Rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeSpecialOfferIDValue {get; set;} = true;

		public bool ShouldSerializeSpecialOfferID()
		{
			return ShouldSerializeSpecialOfferIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue {get; set;} = true;

		public bool ShouldSerializeProductID()
		{
			return ShouldSerializeProductIDValue;
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
			this.ShouldSerializeSpecialOfferIDValue = false;
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>e4331c253309bf41de6f7c0d04d9c4ae</Hash>
</Codenesium>*/