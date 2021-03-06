using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TicketingCRMNS.Api.DataAccess
{
	[Table("SaleTickets", Schema="dbo")]
	public partial class SaleTicket : AbstractEntity
	{
		public SaleTicket()
		{
		}

		public virtual void SetProperties(
			int id,
			int saleId,
			int ticketId)
		{
			this.Id = id;
			this.SaleId = saleId;
			this.TicketId = ticketId;
		}

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[Column("saleId")]
		public int SaleId { get; private set; }

		[Column("ticketId")]
		public int TicketId { get; private set; }

		[ForeignKey("SaleId")]
		public virtual Sale SaleNavigation { get; private set; }

		[ForeignKey("TicketId")]
		public virtual Ticket TicketNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>85941f67c9cde9332e650928cfcc9710</Hash>
</Codenesium>*/