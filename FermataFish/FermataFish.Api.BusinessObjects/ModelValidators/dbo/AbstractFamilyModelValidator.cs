using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects

{
	public abstract class AbstractFamilyModelValidator: AbstractValidator<FamilyModel>
	{
		public new ValidationResult Validate(FamilyModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(FamilyModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IStudioRepository StudioRepository { get; set; }
		public virtual void PcFirstNameRules()
		{
			this.RuleFor(x => x.PcFirstName).NotNull();
			this.RuleFor(x => x.PcFirstName).Length(0, 128);
		}

		public virtual void PcLastNameRules()
		{
			this.RuleFor(x => x.PcLastName).NotNull();
			this.RuleFor(x => x.PcLastName).Length(0, 128);
		}

		public virtual void PcPhoneRules()
		{
			this.RuleFor(x => x.PcPhone).NotNull();
			this.RuleFor(x => x.PcPhone).Length(0, 128);
		}

		public virtual void PcEmailRules()
		{
			this.RuleFor(x => x.PcEmail).NotNull();
			this.RuleFor(x => x.PcEmail).Length(0, 128);
		}

		public virtual void NotesRules()
		{
			this.RuleFor(x => x.Notes).NotNull();
			this.RuleFor(x => x.Notes).Length(0, 2147483647);
		}

		public virtual void StudioIdRules()
		{
			this.RuleFor(x => x.StudioId).NotNull();
			this.RuleFor(x => x.StudioId).Must(this.BeValidStudio).When(x => x ?.StudioId != null).WithMessage("Invalid reference");
		}

		private bool BeValidStudio(int id)
		{
			return this.StudioRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>1138bc85ab8833838dca58b478b07b8d</Hash>
</Codenesium>*/