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
	public abstract class AbstractClientService : AbstractService
	{
		protected IClientRepository ClientRepository { get; private set; }

		protected IApiClientRequestModelValidator ClientModelValidator { get; private set; }

		protected IBOLClientMapper BolClientMapper { get; private set; }

		protected IDALClientMapper DalClientMapper { get; private set; }

		protected IBOLClientCommunicationMapper BolClientCommunicationMapper { get; private set; }

		protected IDALClientCommunicationMapper DalClientCommunicationMapper { get; private set; }

		protected IBOLPetMapper BolPetMapper { get; private set; }

		protected IDALPetMapper DalPetMapper { get; private set; }

		protected IBOLSaleMapper BolSaleMapper { get; private set; }

		protected IDALSaleMapper DalSaleMapper { get; private set; }

		private ILogger logger;

		public AbstractClientService(
			ILogger logger,
			IClientRepository clientRepository,
			IApiClientRequestModelValidator clientModelValidator,
			IBOLClientMapper bolClientMapper,
			IDALClientMapper dalClientMapper,
			IBOLClientCommunicationMapper bolClientCommunicationMapper,
			IDALClientCommunicationMapper dalClientCommunicationMapper,
			IBOLPetMapper bolPetMapper,
			IDALPetMapper dalPetMapper,
			IBOLSaleMapper bolSaleMapper,
			IDALSaleMapper dalSaleMapper)
			: base()
		{
			this.ClientRepository = clientRepository;
			this.ClientModelValidator = clientModelValidator;
			this.BolClientMapper = bolClientMapper;
			this.DalClientMapper = dalClientMapper;
			this.BolClientCommunicationMapper = bolClientCommunicationMapper;
			this.DalClientCommunicationMapper = dalClientCommunicationMapper;
			this.BolPetMapper = bolPetMapper;
			this.DalPetMapper = dalPetMapper;
			this.BolSaleMapper = bolSaleMapper;
			this.DalSaleMapper = dalSaleMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiClientResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ClientRepository.All(limit, offset);

			return this.BolClientMapper.MapBOToModel(this.DalClientMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiClientResponseModel> Get(int id)
		{
			var record = await this.ClientRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolClientMapper.MapBOToModel(this.DalClientMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiClientResponseModel>> Create(
			ApiClientRequestModel model)
		{
			CreateResponse<ApiClientResponseModel> response = new CreateResponse<ApiClientResponseModel>(await this.ClientModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolClientMapper.MapModelToBO(default(int), model);
				var record = await this.ClientRepository.Create(this.DalClientMapper.MapBOToEF(bo));

				response.SetRecord(this.BolClientMapper.MapBOToModel(this.DalClientMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiClientResponseModel>> Update(
			int id,
			ApiClientRequestModel model)
		{
			var validationResult = await this.ClientModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolClientMapper.MapModelToBO(id, model);
				await this.ClientRepository.Update(this.DalClientMapper.MapBOToEF(bo));

				var record = await this.ClientRepository.Get(id);

				return new UpdateResponse<ApiClientResponseModel>(this.BolClientMapper.MapBOToModel(this.DalClientMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiClientResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.ClientModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.ClientRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiClientCommunicationResponseModel>> ClientCommunicationsByClientId(int clientId, int limit = int.MaxValue, int offset = 0)
		{
			List<ClientCommunication> records = await this.ClientRepository.ClientCommunicationsByClientId(clientId, limit, offset);

			return this.BolClientCommunicationMapper.MapBOToModel(this.DalClientCommunicationMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPetResponseModel>> PetsByClientId(int clientId, int limit = int.MaxValue, int offset = 0)
		{
			List<Pet> records = await this.ClientRepository.PetsByClientId(clientId, limit, offset);

			return this.BolPetMapper.MapBOToModel(this.DalPetMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSaleResponseModel>> SalesByClientId(int clientId, int limit = int.MaxValue, int offset = 0)
		{
			List<Sale> records = await this.ClientRepository.SalesByClientId(clientId, limit, offset);

			return this.BolSaleMapper.MapBOToModel(this.DalSaleMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>54a947563f7155318efb3ffb4a143b50</Hash>
</Codenesium>*/