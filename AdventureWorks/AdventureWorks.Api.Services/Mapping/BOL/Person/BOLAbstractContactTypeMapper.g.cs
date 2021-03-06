using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractContactTypeMapper
	{
		public virtual BOContactType MapModelToBO(
			int contactTypeID,
			ApiContactTypeRequestModel model
			)
		{
			BOContactType boContactType = new BOContactType();
			boContactType.SetProperties(
				contactTypeID,
				model.ModifiedDate,
				model.Name);
			return boContactType;
		}

		public virtual ApiContactTypeResponseModel MapBOToModel(
			BOContactType boContactType)
		{
			var model = new ApiContactTypeResponseModel();

			model.SetProperties(boContactType.ContactTypeID, boContactType.ModifiedDate, boContactType.Name);

			return model;
		}

		public virtual List<ApiContactTypeResponseModel> MapBOToModel(
			List<BOContactType> items)
		{
			List<ApiContactTypeResponseModel> response = new List<ApiContactTypeResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>462c103101510d307035778e39856c0b</Hash>
</Codenesium>*/