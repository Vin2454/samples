using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractCountryService : AbstractService
	{
		protected ICountryRepository CountryRepository { get; private set; }

		protected IApiCountryRequestModelValidator CountryModelValidator { get; private set; }

		protected IBOLCountryMapper BolCountryMapper { get; private set; }

		protected IDALCountryMapper DalCountryMapper { get; private set; }

		protected IBOLCountryRequirementMapper BolCountryRequirementMapper { get; private set; }

		protected IDALCountryRequirementMapper DalCountryRequirementMapper { get; private set; }

		protected IBOLDestinationMapper BolDestinationMapper { get; private set; }

		protected IDALDestinationMapper DalDestinationMapper { get; private set; }

		private ILogger logger;

		public AbstractCountryService(
			ILogger logger,
			ICountryRepository countryRepository,
			IApiCountryRequestModelValidator countryModelValidator,
			IBOLCountryMapper bolCountryMapper,
			IDALCountryMapper dalCountryMapper,
			IBOLCountryRequirementMapper bolCountryRequirementMapper,
			IDALCountryRequirementMapper dalCountryRequirementMapper,
			IBOLDestinationMapper bolDestinationMapper,
			IDALDestinationMapper dalDestinationMapper)
			: base()
		{
			this.CountryRepository = countryRepository;
			this.CountryModelValidator = countryModelValidator;
			this.BolCountryMapper = bolCountryMapper;
			this.DalCountryMapper = dalCountryMapper;
			this.BolCountryRequirementMapper = bolCountryRequirementMapper;
			this.DalCountryRequirementMapper = dalCountryRequirementMapper;
			this.BolDestinationMapper = bolDestinationMapper;
			this.DalDestinationMapper = dalDestinationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCountryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CountryRepository.All(limit, offset);

			return this.BolCountryMapper.MapBOToModel(this.DalCountryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCountryResponseModel> Get(int id)
		{
			var record = await this.CountryRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCountryMapper.MapBOToModel(this.DalCountryMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCountryResponseModel>> Create(
			ApiCountryRequestModel model)
		{
			CreateResponse<ApiCountryResponseModel> response = new CreateResponse<ApiCountryResponseModel>(await this.CountryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolCountryMapper.MapModelToBO(default(int), model);
				var record = await this.CountryRepository.Create(this.DalCountryMapper.MapBOToEF(bo));

				response.SetRecord(this.BolCountryMapper.MapBOToModel(this.DalCountryMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCountryResponseModel>> Update(
			int id,
			ApiCountryRequestModel model)
		{
			var validationResult = await this.CountryModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolCountryMapper.MapModelToBO(id, model);
				await this.CountryRepository.Update(this.DalCountryMapper.MapBOToEF(bo));

				var record = await this.CountryRepository.Get(id);

				return new UpdateResponse<ApiCountryResponseModel>(this.BolCountryMapper.MapBOToModel(this.DalCountryMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiCountryResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.CountryModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.CountryRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiCountryRequirementResponseModel>> CountryRequirementsByCountryId(int countryId, int limit = int.MaxValue, int offset = 0)
		{
			List<CountryRequirement> records = await this.CountryRepository.CountryRequirementsByCountryId(countryId, limit, offset);

			return this.BolCountryRequirementMapper.MapBOToModel(this.DalCountryRequirementMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiDestinationResponseModel>> DestinationsByCountryId(int countryId, int limit = int.MaxValue, int offset = 0)
		{
			List<Destination> records = await this.CountryRepository.DestinationsByCountryId(countryId, limit, offset);

			return this.BolDestinationMapper.MapBOToModel(this.DalDestinationMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>4f9f73602515aeb77a1a0d5d713fdedd</Hash>
</Codenesium>*/