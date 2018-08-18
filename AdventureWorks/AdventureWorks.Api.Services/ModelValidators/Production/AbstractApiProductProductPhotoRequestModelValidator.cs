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
	public abstract class AbstractApiProductProductPhotoRequestModelValidator : AbstractValidator<ApiProductProductPhotoRequestModel>
	{
		private int existingRecordId;

		private IProductProductPhotoRepository productProductPhotoRepository;

		public AbstractApiProductProductPhotoRequestModelValidator(IProductProductPhotoRepository productProductPhotoRepository)
		{
			this.productProductPhotoRepository = productProductPhotoRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductProductPhotoRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void PrimaryRules()
		{
		}

		public virtual void ProductPhotoIDRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>64238dad75e4add80ac043fea22cb0fa</Hash>
</Codenesium>*/