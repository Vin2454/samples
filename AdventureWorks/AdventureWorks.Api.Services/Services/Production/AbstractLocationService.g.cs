using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractLocationService: AbstractService
	{
		private ILocationRepository locationRepository;
		private IApiLocationRequestModelValidator locationModelValidator;
		private IBOLLocationMapper BOLLocationMapper;
		private IDALLocationMapper DALLocationMapper;
		private ILogger logger;

		public AbstractLocationService(
			ILogger logger,
			ILocationRepository locationRepository,
			IApiLocationRequestModelValidator locationModelValidator,
			IBOLLocationMapper bollocationMapper,
			IDALLocationMapper dallocationMapper)
			: base()

		{
			this.locationRepository = locationRepository;
			this.locationModelValidator = locationModelValidator;
			this.BOLLocationMapper = bollocationMapper;
			this.DALLocationMapper = dallocationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLocationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.locationRepository.All(skip, take, orderClause);

			return this.BOLLocationMapper.MapBOToModel(this.DALLocationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLocationResponseModel> Get(short locationID)
		{
			var record = await locationRepository.Get(locationID);

			return this.BOLLocationMapper.MapBOToModel(this.DALLocationMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiLocationResponseModel>> Create(
			ApiLocationRequestModel model)
		{
			CreateResponse<ApiLocationResponseModel> response = new CreateResponse<ApiLocationResponseModel>(await this.locationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLLocationMapper.MapModelToBO(default (short), model);
				var record = await this.locationRepository.Create(this.DALLocationMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLLocationMapper.MapBOToModel(this.DALLocationMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			short locationID,
			ApiLocationRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.locationModelValidator.ValidateUpdateAsync(locationID, model));

			if (response.Success)
			{
				var bo = this.BOLLocationMapper.MapModelToBO(locationID, model);
				await this.locationRepository.Update(this.DALLocationMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			short locationID)
		{
			ActionResponse response = new ActionResponse(await this.locationModelValidator.ValidateDeleteAsync(locationID));

			if (response.Success)
			{
				await this.locationRepository.Delete(locationID);
			}
			return response;
		}

		public async Task<ApiLocationResponseModel> GetName(string name)
		{
			Location record = await this.locationRepository.GetName(name);

			return this.BOLLocationMapper.MapBOToModel(this.DALLocationMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>cea9eea72e7c11b10d31ba1ba0143427</Hash>
</Codenesium>*/