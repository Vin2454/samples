using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class BOLAbstractTicketMapper
	{
		public virtual BOTicket MapModelToBO(
			int id,
			ApiTicketRequestModel model
			)
		{
			BOTicket boTicket = new BOTicket();
			boTicket.SetProperties(
				id,
				model.PublicId,
				model.TicketStatusId);
			return boTicket;
		}

		public virtual ApiTicketResponseModel MapBOToModel(
			BOTicket boTicket)
		{
			var model = new ApiTicketResponseModel();

			model.SetProperties(boTicket.Id, boTicket.PublicId, boTicket.TicketStatusId);

			return model;
		}

		public virtual List<ApiTicketResponseModel> MapBOToModel(
			List<BOTicket> items)
		{
			List<ApiTicketResponseModel> response = new List<ApiTicketResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>976256a1ce1ca7af9d02e46a55ac813c</Hash>
</Codenesium>*/