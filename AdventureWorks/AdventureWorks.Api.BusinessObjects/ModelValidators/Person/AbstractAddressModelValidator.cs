using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiAddressModelValidator: AbstractValidator<ApiAddressModel>
	{
		public new ValidationResult Validate(ApiAddressModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiAddressModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void AddressLine1Rules()
		{
			this.RuleFor(x => x.AddressLine1).NotNull();
			this.RuleFor(x => x.AddressLine1).Length(0, 60);
		}

		public virtual void AddressLine2Rules()
		{
			this.RuleFor(x => x.AddressLine2).Length(0, 60);
		}

		public virtual void CityRules()
		{
			this.RuleFor(x => x.City).NotNull();
			this.RuleFor(x => x.City).Length(0, 30);
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void PostalCodeRules()
		{
			this.RuleFor(x => x.PostalCode).NotNull();
			this.RuleFor(x => x.PostalCode).Length(0, 15);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void SpatialLocationRules()
		{                       }

		public virtual void StateProvinceIDRules()
		{
			this.RuleFor(x => x.StateProvinceID).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>2c0f5e11676e1ae958a271dcb0cf0b90</Hash>
</Codenesium>*/