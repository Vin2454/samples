using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractProductModelProductDescriptionCultureModelValidator: AbstractValidator<ProductModelProductDescriptionCultureModel>
	{
		public new ValidationResult Validate(ProductModelProductDescriptionCultureModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ProductModelProductDescriptionCultureModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ICultureRepository CultureRepository { get; set; }
		public IProductDescriptionRepository ProductDescriptionRepository { get; set; }
		public IProductModelRepository ProductModelRepository { get; set; }
		public virtual void CultureIDRules()
		{
			this.RuleFor(x => x.CultureID).NotNull();
			this.RuleFor(x => x.CultureID).Must(this.BeValidCulture).When(x => x ?.CultureID != null).WithMessage("Invalid reference");
			this.RuleFor(x => x.CultureID).Length(0, 6);
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void ProductDescriptionIDRules()
		{
			this.RuleFor(x => x.ProductDescriptionID).NotNull();
			this.RuleFor(x => x.ProductDescriptionID).Must(this.BeValidProductDescription).When(x => x ?.ProductDescriptionID != null).WithMessage("Invalid reference");
		}

		private bool BeValidCulture(string id)
		{
			return this.CultureRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidProductDescription(int id)
		{
			return this.ProductDescriptionRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidProductModel(int id)
		{
			return this.ProductModelRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>70111ecfc9f7b49e0233f8a7e658e15c</Hash>
</Codenesium>*/