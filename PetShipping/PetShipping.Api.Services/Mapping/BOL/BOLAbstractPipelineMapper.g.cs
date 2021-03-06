using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractPipelineMapper
	{
		public virtual BOPipeline MapModelToBO(
			int id,
			ApiPipelineRequestModel model
			)
		{
			BOPipeline boPipeline = new BOPipeline();
			boPipeline.SetProperties(
				id,
				model.PipelineStatusId,
				model.SaleId);
			return boPipeline;
		}

		public virtual ApiPipelineResponseModel MapBOToModel(
			BOPipeline boPipeline)
		{
			var model = new ApiPipelineResponseModel();

			model.SetProperties(boPipeline.Id, boPipeline.PipelineStatusId, boPipeline.SaleId);

			return model;
		}

		public virtual List<ApiPipelineResponseModel> MapBOToModel(
			List<BOPipeline> items)
		{
			List<ApiPipelineResponseModel> response = new List<ApiPipelineResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a5add28a4df24fe2a1e506c72d0cae20</Hash>
</Codenesium>*/