using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public abstract class AbstractBOPen
	{
		private IPenRepository penRepository;
		private IApiPenModelValidator penModelValidator;
		private ILogger logger;

		public AbstractBOPen(
			ILogger logger,
			IPenRepository penRepository,
			IApiPenModelValidator penModelValidator)

		{
			this.penRepository = penRepository;
			this.penModelValidator = penModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOPen> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.penRepository.All(skip, take, orderClause);
		}

		public virtual POCOPen Get(int id)
		{
			return this.penRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOPen>> Create(
			ApiPenModel model)
		{
			CreateResponse<POCOPen> response = new CreateResponse<POCOPen>(await this.penModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOPen record = this.penRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPenModel model)
		{
			ActionResponse response = new ActionResponse(await this.penModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.penRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.penModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.penRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b83dcff8edd0b4b577148265177e97bf</Hash>
</Codenesium>*/