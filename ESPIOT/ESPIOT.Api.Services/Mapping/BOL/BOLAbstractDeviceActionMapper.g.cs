using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
{
	public abstract class BOLAbstractDeviceActionMapper
	{
		public virtual BODeviceAction MapModelToBO(
			int id,
			ApiDeviceActionRequestModel model
			)
		{
			BODeviceAction boDeviceAction = new BODeviceAction();
			boDeviceAction.SetProperties(
				id,
				model.DeviceId,
				model.Name,
				model.@Value);
			return boDeviceAction;
		}

		public virtual ApiDeviceActionResponseModel MapBOToModel(
			BODeviceAction boDeviceAction)
		{
			var model = new ApiDeviceActionResponseModel();

			model.SetProperties(boDeviceAction.Id, boDeviceAction.DeviceId, boDeviceAction.Name, boDeviceAction.@Value);

			return model;
		}

		public virtual List<ApiDeviceActionResponseModel> MapBOToModel(
			List<BODeviceAction> items)
		{
			List<ApiDeviceActionResponseModel> response = new List<ApiDeviceActionResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e299b79cf8e006c1dba1189983e5b054</Hash>
</Codenesium>*/