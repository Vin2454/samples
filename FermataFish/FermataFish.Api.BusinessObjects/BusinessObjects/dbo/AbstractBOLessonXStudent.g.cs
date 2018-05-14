using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOLessonXStudent
	{
		private ILessonXStudentRepository lessonXStudentRepository;
		private IApiLessonXStudentModelValidator lessonXStudentModelValidator;
		private ILogger logger;

		public AbstractBOLessonXStudent(
			ILogger logger,
			ILessonXStudentRepository lessonXStudentRepository,
			IApiLessonXStudentModelValidator lessonXStudentModelValidator)

		{
			this.lessonXStudentRepository = lessonXStudentRepository;
			this.lessonXStudentModelValidator = lessonXStudentModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOLessonXStudent> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.lessonXStudentRepository.All(skip, take, orderClause);
		}

		public virtual POCOLessonXStudent Get(int id)
		{
			return this.lessonXStudentRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOLessonXStudent>> Create(
			ApiLessonXStudentModel model)
		{
			CreateResponse<POCOLessonXStudent> response = new CreateResponse<POCOLessonXStudent>(await this.lessonXStudentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOLessonXStudent record = this.lessonXStudentRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiLessonXStudentModel model)
		{
			ActionResponse response = new ActionResponse(await this.lessonXStudentModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.lessonXStudentRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.lessonXStudentModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.lessonXStudentRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8fe71827e6e44a1c0bd79fd4b8d4447f</Hash>
</Codenesium>*/