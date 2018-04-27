using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractProductSubcategoryModelValidator: AbstractValidator<ProductSubcategoryModel>
	{
		public new ValidationResult Validate(ProductSubcategoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ProductSubcategoryModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IProductCategoryRepository ProductCategoryRepository { get; set; }
		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void ProductCategoryIDRules()
		{
			this.RuleFor(x => x.ProductCategoryID).NotNull();
			this.RuleFor(x => x.ProductCategoryID).Must(this.BeValidProductCategory).When(x => x ?.ProductCategoryID != null).WithMessage("Invalid reference");
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		private bool BeValidProductCategory(int id)
		{
			return this.ProductCategoryRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>4b786a64305f64f832a3bb9aedcfe28b</Hash>
</Codenesium>*/