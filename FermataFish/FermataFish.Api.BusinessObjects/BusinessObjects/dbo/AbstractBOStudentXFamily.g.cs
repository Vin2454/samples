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
	public abstract class AbstractBOStudentXFamily
	{
		private IStudentXFamilyRepository studentXFamilyRepository;
		private IApiStudentXFamilyModelValidator studentXFamilyModelValidator;
		private ILogger logger;

		public AbstractBOStudentXFamily(
			ILogger logger,
			IStudentXFamilyRepository studentXFamilyRepository,
			IApiStudentXFamilyModelValidator studentXFamilyModelValidator)

		{
			this.studentXFamilyRepository = studentXFamilyRepository;
			this.studentXFamilyModelValidator = studentXFamilyModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOStudentXFamily> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.studentXFamilyRepository.All(skip, take, orderClause);
		}

		public virtual POCOStudentXFamily Get(int id)
		{
			return this.studentXFamilyRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOStudentXFamily>> Create(
			ApiStudentXFamilyModel model)
		{
			CreateResponse<POCOStudentXFamily> response = new CreateResponse<POCOStudentXFamily>(await this.studentXFamilyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOStudentXFamily record = this.studentXFamilyRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiStudentXFamilyModel model)
		{
			ActionResponse response = new ActionResponse(await this.studentXFamilyModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.studentXFamilyRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.studentXFamilyModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.studentXFamilyRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a2d3426b1849d60106462ddb72021ed8</Hash>
</Codenesium>*/