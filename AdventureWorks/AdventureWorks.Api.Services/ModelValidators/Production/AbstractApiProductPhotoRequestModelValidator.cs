using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiProductPhotoRequestModelValidator : AbstractValidator<ApiProductPhotoRequestModel>
	{
		private int existingRecordId;

		private IProductPhotoRepository productPhotoRepository;

		public AbstractApiProductPhotoRequestModelValidator(IProductPhotoRepository productPhotoRepository)
		{
			this.productPhotoRepository = productPhotoRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductPhotoRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void LargePhotoRules()
		{
		}

		public virtual void LargePhotoFileNameRules()
		{
			this.RuleFor(x => x.LargePhotoFileName).Length(0, 50);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void ThumbNailPhotoRules()
		{
		}

		public virtual void ThumbnailPhotoFileNameRules()
		{
			this.RuleFor(x => x.ThumbnailPhotoFileName).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>dcdd6e17aff5a87fcc78157b202bf4b1</Hash>
</Codenesium>*/