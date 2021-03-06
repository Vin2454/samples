using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractPersonPhoneMapper
	{
		public virtual BOPersonPhone MapModelToBO(
			int businessEntityID,
			ApiPersonPhoneRequestModel model
			)
		{
			BOPersonPhone boPersonPhone = new BOPersonPhone();
			boPersonPhone.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.PhoneNumber,
				model.PhoneNumberTypeID);
			return boPersonPhone;
		}

		public virtual ApiPersonPhoneResponseModel MapBOToModel(
			BOPersonPhone boPersonPhone)
		{
			var model = new ApiPersonPhoneResponseModel();

			model.SetProperties(boPersonPhone.BusinessEntityID, boPersonPhone.ModifiedDate, boPersonPhone.PhoneNumber, boPersonPhone.PhoneNumberTypeID);

			return model;
		}

		public virtual List<ApiPersonPhoneResponseModel> MapBOToModel(
			List<BOPersonPhone> items)
		{
			List<ApiPersonPhoneResponseModel> response = new List<ApiPersonPhoneResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d26294904d6baf24f507f305ca9b9167</Hash>
</Codenesium>*/