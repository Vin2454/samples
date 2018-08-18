using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IBOLSpaceFeatureMapper
	{
		BOSpaceFeature MapModelToBO(
			int id,
			ApiSpaceFeatureRequestModel model);

		ApiSpaceFeatureResponseModel MapBOToModel(
			BOSpaceFeature boSpaceFeature);

		List<ApiSpaceFeatureResponseModel> MapBOToModel(
			List<BOSpaceFeature> items);
	}
}

/*<Codenesium>
    <Hash>a1e3f47f1293831e4746eb89407104a4</Hash>
</Codenesium>*/