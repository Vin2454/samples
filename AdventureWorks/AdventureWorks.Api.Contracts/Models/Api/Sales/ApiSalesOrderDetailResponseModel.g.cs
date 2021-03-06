using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiSalesOrderDetailResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int salesOrderID,
			string carrierTrackingNumber,
			decimal lineTotal,
			DateTime modifiedDate,
			short orderQty,
			int productID,
			Guid rowguid,
			int salesOrderDetailID,
			int specialOfferID,
			decimal unitPrice,
			decimal unitPriceDiscount)
		{
			this.SalesOrderID = salesOrderID;
			this.CarrierTrackingNumber = carrierTrackingNumber;
			this.LineTotal = lineTotal;
			this.ModifiedDate = modifiedDate;
			this.OrderQty = orderQty;
			this.ProductID = productID;
			this.Rowguid = rowguid;
			this.SalesOrderDetailID = salesOrderDetailID;
			this.SpecialOfferID = specialOfferID;
			this.UnitPrice = unitPrice;
			this.UnitPriceDiscount = unitPriceDiscount;

			this.SalesOrderIDEntity = nameof(ApiResponse.SalesOrderHeaders);
		}

		[Required]
		[JsonProperty]
		public string CarrierTrackingNumber { get; private set; }

		[JsonProperty]
		public decimal LineTotal { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public short OrderQty { get; private set; }

		[JsonProperty]
		public int ProductID { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[JsonProperty]
		public int SalesOrderDetailID { get; private set; }

		[JsonProperty]
		public int SalesOrderID { get; private set; }

		[JsonProperty]
		public string SalesOrderIDEntity { get; set; }

		[JsonProperty]
		public int SpecialOfferID { get; private set; }

		[JsonProperty]
		public decimal UnitPrice { get; private set; }

		[JsonProperty]
		public decimal UnitPriceDiscount { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a8a1a62edda8f60a887b01ae82a848a3</Hash>
</Codenesium>*/