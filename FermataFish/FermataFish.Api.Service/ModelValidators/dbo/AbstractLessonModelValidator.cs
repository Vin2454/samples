using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Service

{
	public abstract class AbstractLessonModelValidator: AbstractValidator<LessonModel>
	{
		public new ValidationResult Validate(LessonModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(LessonModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ILessonStatusRepository LessonStatusRepository { get; set; }
		public IStudioRepository StudioRepository { get; set; }
		public virtual void ScheduledStartDateRules()
		{                       }

		public virtual void ScheduledEndDateRules()
		{                       }

		public virtual void ActualStartDateRules()
		{                       }

		public virtual void ActualEndDateRules()
		{                       }

		public virtual void LessonStatusIdRules()
		{
			this.RuleFor(x => x.LessonStatusId).NotNull();
			this.RuleFor(x => x.LessonStatusId).Must(this.BeValidLessonStatus).When(x => x ?.LessonStatusId != null).WithMessage("Invalid reference");
		}

		public virtual void TeacherNotesRules()
		{
			this.RuleFor(x => x.TeacherNotes).Length(0, 2147483647);
		}

		public virtual void StudentNotesRules()
		{
			this.RuleFor(x => x.StudentNotes).Length(0, 2147483647);
		}

		public virtual void BillAmountRules()
		{                       }

		public virtual void StudioIdRules()
		{
			this.RuleFor(x => x.StudioId).NotNull();
			this.RuleFor(x => x.StudioId).Must(this.BeValidStudio).When(x => x ?.StudioId != null).WithMessage("Invalid reference");
		}

		private bool BeValidLessonStatus(int id)
		{
			return this.LessonStatusRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidStudio(int id)
		{
			return this.StudioRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>c8cbb47226b308b6c079183475f03cbc</Hash>
</Codenesium>*/