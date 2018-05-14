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
	public abstract class AbstractBOAirTransport
	{
		private IAirTransportRepository airTransportRepository;
		private IApiAirTransportModelValidator airTransportModelValidator;
		private ILogger logger;

		public AbstractBOAirTransport(
			ILogger logger,
			IAirTransportRepository airTransportRepository,
			IApiAirTransportModelValidator airTransportModelValidator)

		{
			this.airTransportRepository = airTransportRepository;
			this.airTransportModelValidator = airTransportModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOAirTransport> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.airTransportRepository.All(skip, take, orderClause);
		}

		public virtual POCOAirTransport Get(int airlineId)
		{
			return this.airTransportRepository.Get(airlineId);
		}

		public virtual async Task<CreateResponse<POCOAirTransport>> Create(
			ApiAirTransportModel model)
		{
			CreateResponse<POCOAirTransport> response = new CreateResponse<POCOAirTransport>(await this.airTransportModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOAirTransport record = this.airTransportRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int airlineId,
			ApiAirTransportModel model)
		{
			ActionResponse response = new ActionResponse(await this.airTransportModelValidator.ValidateUpdateAsync(airlineId, model));

			if (response.Success)
			{
				this.airTransportRepository.Update(airlineId, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int airlineId)
		{
			ActionResponse response = new ActionResponse(await this.airTransportModelValidator.ValidateDeleteAsync(airlineId));

			if (response.Success)
			{
				this.airTransportRepository.Delete(airlineId);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>29cbe637fe230260c388326ab28993e1</Hash>
</Codenesium>*/