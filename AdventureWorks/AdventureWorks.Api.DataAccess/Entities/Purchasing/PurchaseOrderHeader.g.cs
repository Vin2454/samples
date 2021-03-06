using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("PurchaseOrderHeader", Schema="Purchasing")]
	public partial class PurchaseOrderHeader : AbstractEntity
	{
		public PurchaseOrderHeader()
		{
		}

		public virtual void SetProperties(
			int employeeID,
			decimal freight,
			DateTime modifiedDate,
			DateTime orderDate,
			int purchaseOrderID,
			int revisionNumber,
			DateTime? shipDate,
			int shipMethodID,
			int status,
			decimal subTotal,
			decimal taxAmt,
			decimal totalDue,
			int vendorID)
		{
			this.EmployeeID = employeeID;
			this.Freight = freight;
			this.ModifiedDate = modifiedDate;
			this.OrderDate = orderDate;
			this.PurchaseOrderID = purchaseOrderID;
			this.RevisionNumber = revisionNumber;
			this.ShipDate = shipDate;
			this.ShipMethodID = shipMethodID;
			this.Status = status;
			this.SubTotal = subTotal;
			this.TaxAmt = taxAmt;
			this.TotalDue = totalDue;
			this.VendorID = vendorID;
		}

		[Column("EmployeeID")]
		public int EmployeeID { get; private set; }

		[Column("Freight")]
		public decimal Freight { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[Column("OrderDate")]
		public DateTime OrderDate { get; private set; }

		[Key]
		[Column("PurchaseOrderID")]
		public int PurchaseOrderID { get; private set; }

		[Column("RevisionNumber")]
		public int RevisionNumber { get; private set; }

		[Column("ShipDate")]
		public DateTime? ShipDate { get; private set; }

		[Column("ShipMethodID")]
		public int ShipMethodID { get; private set; }

		[Column("Status")]
		public int Status { get; private set; }

		[Column("SubTotal")]
		public decimal SubTotal { get; private set; }

		[Column("TaxAmt")]
		public decimal TaxAmt { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("TotalDue")]
		public decimal TotalDue { get; private set; }

		[Column("VendorID")]
		public int VendorID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>662112aac08253837ce7f54ffd9a464f</Hash>
</Codenesium>*/