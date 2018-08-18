using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public abstract class BOLAbstractFileMapper
	{
		public virtual BOFile MapModelToBO(
			int id,
			ApiFileRequestModel model
			)
		{
			BOFile boFile = new BOFile();
			boFile.SetProperties(
				id,
				model.BucketId,
				model.DateCreated,
				model.Description,
				model.Expiration,
				model.Extension,
				model.ExternalId,
				model.FileSizeInBytes,
				model.FileTypeId,
				model.Location,
				model.PrivateKey,
				model.PublicKey);
			return boFile;
		}

		public virtual ApiFileResponseModel MapBOToModel(
			BOFile boFile)
		{
			var model = new ApiFileResponseModel();

			model.SetProperties(boFile.Id, boFile.BucketId, boFile.DateCreated, boFile.Description, boFile.Expiration, boFile.Extension, boFile.ExternalId, boFile.FileSizeInBytes, boFile.FileTypeId, boFile.Location, boFile.PrivateKey, boFile.PublicKey);

			return model;
		}

		public virtual List<ApiFileResponseModel> MapBOToModel(
			List<BOFile> items)
		{
			List<ApiFileResponseModel> response = new List<ApiFileResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d916d057a020cd5497313377ad463bf9</Hash>
</Codenesium>*/