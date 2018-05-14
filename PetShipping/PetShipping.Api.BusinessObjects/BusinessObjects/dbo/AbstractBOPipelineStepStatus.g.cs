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
	public abstract class AbstractBOPipelineStepStatus
	{
		private IPipelineStepStatusRepository pipelineStepStatusRepository;
		private IApiPipelineStepStatusModelValidator pipelineStepStatusModelValidator;
		private ILogger logger;

		public AbstractBOPipelineStepStatus(
			ILogger logger,
			IPipelineStepStatusRepository pipelineStepStatusRepository,
			IApiPipelineStepStatusModelValidator pipelineStepStatusModelValidator)

		{
			this.pipelineStepStatusRepository = pipelineStepStatusRepository;
			this.pipelineStepStatusModelValidator = pipelineStepStatusModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOPipelineStepStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStepStatusRepository.All(skip, take, orderClause);
		}

		public virtual POCOPipelineStepStatus Get(int id)
		{
			return this.pipelineStepStatusRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOPipelineStepStatus>> Create(
			ApiPipelineStepStatusModel model)
		{
			CreateResponse<POCOPipelineStepStatus> response = new CreateResponse<POCOPipelineStepStatus>(await this.pipelineStepStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOPipelineStepStatus record = this.pipelineStepStatusRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPipelineStepStatusModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepStatusModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.pipelineStepStatusRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.pipelineStepStatusRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d4fc955be4da9bcb32bd55a3e48335b6</Hash>
</Codenesium>*/