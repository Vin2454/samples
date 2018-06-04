using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiSalesOrderHeaderSalesReasonResponseModel: AbstractApiResponseModel
	{
		public ApiSalesOrderHeaderSalesReasonResponseModel() : base()
		{}

		public void SetProperties(
			DateTime modifiedDate,
			int salesOrderID,
			int salesReasonID)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.SalesOrderID = salesOrderID.ToInt();
			this.SalesReasonID = salesReasonID.ToInt();

			this.SalesOrderIDEntity = nameof(ApiResponse.SalesOrderHeaders);
			this.SalesReasonIDEntity = nameof(ApiResponse.SalesReasons);
		}

		public DateTime ModifiedDate { get; private set; }
		public int SalesOrderID { get; private set; }
		public string SalesOrderIDEntity { get; set; }
		public int SalesReasonID { get; private set; }
		public string SalesReasonIDEntity { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesOrderIDValue { get; set; } = true;

		public bool ShouldSerializeSalesOrderID()
		{
			return this.ShouldSerializeSalesOrderIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesReasonIDValue { get; set; } = true;

		public bool ShouldSerializeSalesReasonID()
		{
			return this.ShouldSerializeSalesReasonIDValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeSalesOrderIDValue = false;
			this.ShouldSerializeSalesReasonIDValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>11beb7403feb4fa4733f134f7ab56413</Hash>
</Codenesium>*/