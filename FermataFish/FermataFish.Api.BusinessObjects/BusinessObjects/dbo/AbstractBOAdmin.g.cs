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
	public abstract class AbstractBOAdmin
	{
		private IAdminRepository adminRepository;
		private IApiAdminModelValidator adminModelValidator;
		private ILogger logger;

		public AbstractBOAdmin(
			ILogger logger,
			IAdminRepository adminRepository,
			IApiAdminModelValidator adminModelValidator)

		{
			this.adminRepository = adminRepository;
			this.adminModelValidator = adminModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOAdmin> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.adminRepository.All(skip, take, orderClause);
		}

		public virtual POCOAdmin Get(int id)
		{
			return this.adminRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOAdmin>> Create(
			ApiAdminModel model)
		{
			CreateResponse<POCOAdmin> response = new CreateResponse<POCOAdmin>(await this.adminModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOAdmin record = this.adminRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiAdminModel model)
		{
			ActionResponse response = new ActionResponse(await this.adminModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.adminRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.adminModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.adminRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8668d0db61418655c462f8cc5487c313</Hash>
</Codenesium>*/