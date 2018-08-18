using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TicketingCRMNS.Api.DataAccess
{
	[Table("Sale", Schema="dbo")]
	public partial class Sale : AbstractEntity
	{
		public Sale()
		{
		}

		public virtual void SetProperties(
			int id,
			string ipAddress,
			string notes,
			DateTime saleDate,
			int transactionId)
		{
			this.Id = id;
			this.IpAddress = ipAddress;
			this.Notes = notes;
			this.SaleDate = saleDate;
			this.TransactionId = transactionId;
		}

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(128)]
		[Column("ipAddress")]
		public string IpAddress { get; private set; }

		[MaxLength(2147483647)]
		[Column("notes")]
		public string Notes { get; private set; }

		[Column("saleDate")]
		public DateTime SaleDate { get; private set; }

		[Column("transactionId")]
		public int TransactionId { get; private set; }

		[ForeignKey("TransactionId")]
		public virtual Transaction TransactionNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>542fe169f490caa05092c01bff76ad19</Hash>
</Codenesium>*/