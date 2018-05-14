using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOPipelineStatus
	{
		private IPipelineStatusRepository pipelineStatusRepository;
		private IApiPipelineStatusModelValidator pipelineStatusModelValidator;
		private ILogger logger;

		public AbstractBOPipelineStatus(
			ILogger logger,
			IPipelineStatusRepository pipelineStatusRepository,
			IApiPipelineStatusModelValidator pipelineStatusModelValidator)

		{
			this.pipelineStatusRepository = pipelineStatusRepository;
			this.pipelineStatusModelValidator = pipelineStatusModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOPipelineStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStatusRepository.All(skip, take, orderClause);
		}

		public virtual POCOPipelineStatus Get(int id)
		{
			return this.pipelineStatusRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOPipelineStatus>> Create(
			ApiPipelineStatusModel model)
		{
			CreateResponse<POCOPipelineStatus> response = new CreateResponse<POCOPipelineStatus>(await this.pipelineStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOPipelineStatus record = this.pipelineStatusRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPipelineStatusModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStatusModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.pipelineStatusRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.pipelineStatusRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b7b61ad3c7b2781d7d0fdde167923698</Hash>
</Codenesium>*/