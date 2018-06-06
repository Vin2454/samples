using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.Services

{
	public abstract class AbstractApiPetRequestModelValidator: AbstractValidator<ApiPetRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiPetRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiPetRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public IBreedRepository BreedRepository { get; set; }
		public IPenRepository PenRepository { get; set; }
		public ISpeciesRepository SpeciesRepository { get; set; }
		public virtual void AcquiredDateRules()
		{
			this.RuleFor(x => x.AcquiredDate).NotNull();
		}

		public virtual void BreedIdRules()
		{
			this.RuleFor(x => x.BreedId).NotNull();
			this.RuleFor(x => x.BreedId).MustAsync(this.BeValidBreed).When(x => x ?.BreedId != null).WithMessage("Invalid reference");
		}

		public virtual void DescriptionRules()
		{
			this.RuleFor(x => x.Description).NotNull();
			this.RuleFor(x => x.Description).Length(0, 2147483647);
		}

		public virtual void PenIdRules()
		{
			this.RuleFor(x => x.PenId).NotNull();
			this.RuleFor(x => x.PenId).MustAsync(this.BeValidPen).When(x => x ?.PenId != null).WithMessage("Invalid reference");
		}

		public virtual void PriceRules()
		{
			this.RuleFor(x => x.Price).NotNull();
		}

		public virtual void SpeciesIdRules()
		{
			this.RuleFor(x => x.SpeciesId).NotNull();
			this.RuleFor(x => x.SpeciesId).MustAsync(this.BeValidSpecies).When(x => x ?.SpeciesId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidBreed(int id,  CancellationToken cancellationToken)
		{
			var record = await this.BreedRepository.Get(id);

			return record != null;
		}

		private async Task<bool> BeValidPen(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PenRepository.Get(id);

			return record != null;
		}

		private async Task<bool> BeValidSpecies(int id,  CancellationToken cancellationToken)
		{
			var record = await this.SpeciesRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>7eb2b5a3dd2be45caf04bbae56c95895</Hash>
</Codenesium>*/