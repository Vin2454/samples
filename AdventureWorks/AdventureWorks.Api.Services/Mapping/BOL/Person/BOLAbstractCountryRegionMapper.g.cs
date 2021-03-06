using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractCountryRegionMapper
	{
		public virtual BOCountryRegion MapModelToBO(
			string countryRegionCode,
			ApiCountryRegionRequestModel model
			)
		{
			BOCountryRegion boCountryRegion = new BOCountryRegion();
			boCountryRegion.SetProperties(
				countryRegionCode,
				model.ModifiedDate,
				model.Name);
			return boCountryRegion;
		}

		public virtual ApiCountryRegionResponseModel MapBOToModel(
			BOCountryRegion boCountryRegion)
		{
			var model = new ApiCountryRegionResponseModel();

			model.SetProperties(boCountryRegion.CountryRegionCode, boCountryRegion.ModifiedDate, boCountryRegion.Name);

			return model;
		}

		public virtual List<ApiCountryRegionResponseModel> MapBOToModel(
			List<BOCountryRegion> items)
		{
			List<ApiCountryRegionResponseModel> response = new List<ApiCountryRegionResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>82dfa9fb9dcc9710680e6b5c9387ec91</Hash>
</Codenesium>*/