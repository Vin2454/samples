using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
	public partial class ApiSaleTicketsResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			int saleId,
			int ticketId)
		{
			this.Id = id;
			this.SaleId = saleId;
			this.TicketId = ticketId;

			this.SaleIdEntity = nameof(ApiResponse.Sales);
			this.TicketIdEntity = nameof(ApiResponse.Tickets);
		}

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public int SaleId { get; private set; }

		[JsonProperty]
		public string SaleIdEntity { get; set; }

		[Required]
		[JsonProperty]
		public int TicketId { get; private set; }

		[JsonProperty]
		public string TicketIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>e5629cd35f6e3a59ad1f665c1d66fc42</Hash>
</Codenesium>*/