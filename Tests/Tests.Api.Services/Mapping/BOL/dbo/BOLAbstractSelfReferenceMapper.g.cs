using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class BOLAbstractSelfReferenceMapper
	{
		public virtual BOSelfReference MapModelToBO(
			int id,
			ApiSelfReferenceRequestModel model
			)
		{
			BOSelfReference boSelfReference = new BOSelfReference();
			boSelfReference.SetProperties(
				id,
				model.SelfReferenceId,
				model.SelfReferenceId2);
			return boSelfReference;
		}

		public virtual ApiSelfReferenceResponseModel MapBOToModel(
			BOSelfReference boSelfReference)
		{
			var model = new ApiSelfReferenceResponseModel();

			model.SetProperties(boSelfReference.Id, boSelfReference.SelfReferenceId, boSelfReference.SelfReferenceId2);

			return model;
		}

		public virtual List<ApiSelfReferenceResponseModel> MapBOToModel(
			List<BOSelfReference> items)
		{
			List<ApiSelfReferenceResponseModel> response = new List<ApiSelfReferenceResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2ff6929b4009399cf1c92fd4300ca990</Hash>
</Codenesium>*/