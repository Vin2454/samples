using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractEventStatusMapper
	{
		public virtual BOEventStatus MapModelToBO(
			int id,
			ApiEventStatusRequestModel model
			)
		{
			BOEventStatus boEventStatus = new BOEventStatus();
			boEventStatus.SetProperties(
				id,
				model.Name);
			return boEventStatus;
		}

		public virtual ApiEventStatusResponseModel MapBOToModel(
			BOEventStatus boEventStatus)
		{
			var model = new ApiEventStatusResponseModel();

			model.SetProperties(boEventStatus.Id, boEventStatus.Name);

			return model;
		}

		public virtual List<ApiEventStatusResponseModel> MapBOToModel(
			List<BOEventStatus> items)
		{
			List<ApiEventStatusResponseModel> response = new List<ApiEventStatusResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f370b6befcbbfe22a552651e2031ad77</Hash>
</Codenesium>*/