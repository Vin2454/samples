using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractCommunityActionTemplateMapper
	{
		public virtual BOCommunityActionTemplate MapModelToBO(
			string id,
			ApiCommunityActionTemplateRequestModel model
			)
		{
			BOCommunityActionTemplate boCommunityActionTemplate = new BOCommunityActionTemplate();
			boCommunityActionTemplate.SetProperties(
				id,
				model.ExternalId,
				model.JSON,
				model.Name);
			return boCommunityActionTemplate;
		}

		public virtual ApiCommunityActionTemplateResponseModel MapBOToModel(
			BOCommunityActionTemplate boCommunityActionTemplate)
		{
			var model = new ApiCommunityActionTemplateResponseModel();

			model.SetProperties(boCommunityActionTemplate.Id, boCommunityActionTemplate.ExternalId, boCommunityActionTemplate.JSON, boCommunityActionTemplate.Name);

			return model;
		}

		public virtual List<ApiCommunityActionTemplateResponseModel> MapBOToModel(
			List<BOCommunityActionTemplate> items)
		{
			List<ApiCommunityActionTemplateResponseModel> response = new List<ApiCommunityActionTemplateResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bca33b0dba10b0bde18edcd056bc7c50</Hash>
</Codenesium>*/