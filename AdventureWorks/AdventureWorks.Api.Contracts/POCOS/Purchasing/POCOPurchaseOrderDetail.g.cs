using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOPurchaseOrderDetail
	{
		public POCOPurchaseOrderDetail()
		{}

		public POCOPurchaseOrderDetail(
			DateTime dueDate,
			decimal lineTotal,
			DateTime modifiedDate,
			short orderQty,
			int productID,
			int purchaseOrderDetailID,
			int purchaseOrderID,
			decimal receivedQty,
			decimal rejectedQty,
			decimal stockedQty,
			decimal unitPrice)
		{
			this.DueDate = dueDate.ToDateTime();
			this.LineTotal = lineTotal.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.OrderQty = orderQty;
			this.PurchaseOrderDetailID = purchaseOrderDetailID.ToInt();
			this.ReceivedQty = receivedQty.ToDecimal();
			this.RejectedQty = rejectedQty.ToDecimal();
			this.StockedQty = stockedQty.ToDecimal();
			this.UnitPrice = unitPrice.ToDecimal();

			this.ProductID = new ReferenceEntity<int>(productID,
			                                          nameof(ApiResponse.Products));
			this.PurchaseOrderID = new ReferenceEntity<int>(purchaseOrderID,
			                                                nameof(ApiResponse.PurchaseOrderHeaders));
		}

		public DateTime DueDate { get; set; }
		public decimal LineTotal { get; set; }
		public DateTime ModifiedDate { get; set; }
		public short OrderQty { get; set; }
		public ReferenceEntity<int> ProductID { get; set; }
		public int PurchaseOrderDetailID { get; set; }
		public ReferenceEntity<int> PurchaseOrderID { get; set; }
		public decimal ReceivedQty { get; set; }
		public decimal RejectedQty { get; set; }
		public decimal StockedQty { get; set; }
		public decimal UnitPrice { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeDueDateValue { get; set; } = true;

		public bool ShouldSerializeDueDate()
		{
			return this.ShouldSerializeDueDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLineTotalValue { get; set; } = true;

		public bool ShouldSerializeLineTotal()
		{
			return this.ShouldSerializeLineTotalValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOrderQtyValue { get; set; } = true;

		public bool ShouldSerializeOrderQty()
		{
			return this.ShouldSerializeOrderQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue { get; set; } = true;

		public bool ShouldSerializeProductID()
		{
			return this.ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePurchaseOrderDetailIDValue { get; set; } = true;

		public bool ShouldSerializePurchaseOrderDetailID()
		{
			return this.ShouldSerializePurchaseOrderDetailIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePurchaseOrderIDValue { get; set; } = true;

		public bool ShouldSerializePurchaseOrderID()
		{
			return this.ShouldSerializePurchaseOrderIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeReceivedQtyValue { get; set; } = true;

		public bool ShouldSerializeReceivedQty()
		{
			return this.ShouldSerializeReceivedQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRejectedQtyValue { get; set; } = true;

		public bool ShouldSerializeRejectedQty()
		{
			return this.ShouldSerializeRejectedQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStockedQtyValue { get; set; } = true;

		public bool ShouldSerializeStockedQty()
		{
			return this.ShouldSerializeStockedQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeUnitPriceValue { get; set; } = true;

		public bool ShouldSerializeUnitPrice()
		{
			return this.ShouldSerializeUnitPriceValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeDueDateValue = false;
			this.ShouldSerializeLineTotalValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeOrderQtyValue = false;
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializePurchaseOrderDetailIDValue = false;
			this.ShouldSerializePurchaseOrderIDValue = false;
			this.ShouldSerializeReceivedQtyValue = false;
			this.ShouldSerializeRejectedQtyValue = false;
			this.ShouldSerializeStockedQtyValue = false;
			this.ShouldSerializeUnitPriceValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>7212eff22ccd3bba030a0445ad397c55</Hash>
</Codenesium>*/