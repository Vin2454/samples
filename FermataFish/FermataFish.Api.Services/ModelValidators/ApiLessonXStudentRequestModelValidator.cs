using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public class ApiLessonXStudentRequestModelValidator : AbstractApiLessonXStudentRequestModelValidator, IApiLessonXStudentRequestModelValidator
	{
		public ApiLessonXStudentRequestModelValidator(ILessonXStudentRepository lessonXStudentRepository)
			: base(lessonXStudentRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiLessonXStudentRequestModel model)
		{
			this.LessonIdRules();
			this.StudentIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonXStudentRequestModel model)
		{
			this.LessonIdRules();
			this.StudentIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>9f14dd1730232f602c676af6f9d1d81a</Hash>
</Codenesium>*/