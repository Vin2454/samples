using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractProductModelIllustrationModelValidator: AbstractValidator<ProductModelIllustrationModel>
	{
		public new ValidationResult Validate(ProductModelIllustrationModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ProductModelIllustrationModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IIllustrationRepository IllustrationRepository { get; set; }
		public IProductModelRepository ProductModelRepository { get; set; }
		public virtual void IllustrationIDRules()
		{
			this.RuleFor(x => x.IllustrationID).NotNull();
			this.RuleFor(x => x.IllustrationID).Must(this.BeValidIllustration).When(x => x ?.IllustrationID != null).WithMessage("Invalid reference");
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidIllustration(int id)
		{
			return this.IllustrationRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidProductModel(int id)
		{
			return this.ProductModelRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>3d5ea9edfe8783ecfdf079192085f482</Hash>
</Codenesium>*/