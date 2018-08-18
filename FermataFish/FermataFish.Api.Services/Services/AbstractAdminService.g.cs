using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractAdminService : AbstractService
	{
		protected IAdminRepository AdminRepository { get; private set; }

		protected IApiAdminRequestModelValidator AdminModelValidator { get; private set; }

		protected IBOLAdminMapper BolAdminMapper { get; private set; }

		protected IDALAdminMapper DalAdminMapper { get; private set; }

		private ILogger logger;

		public AbstractAdminService(
			ILogger logger,
			IAdminRepository adminRepository,
			IApiAdminRequestModelValidator adminModelValidator,
			IBOLAdminMapper bolAdminMapper,
			IDALAdminMapper dalAdminMapper)
			: base()
		{
			this.AdminRepository = adminRepository;
			this.AdminModelValidator = adminModelValidator;
			this.BolAdminMapper = bolAdminMapper;
			this.DalAdminMapper = dalAdminMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiAdminResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.AdminRepository.All(limit, offset);

			return this.BolAdminMapper.MapBOToModel(this.DalAdminMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiAdminResponseModel> Get(int id)
		{
			var record = await this.AdminRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolAdminMapper.MapBOToModel(this.DalAdminMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiAdminResponseModel>> Create(
			ApiAdminRequestModel model)
		{
			CreateResponse<ApiAdminResponseModel> response = new CreateResponse<ApiAdminResponseModel>(await this.AdminModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolAdminMapper.MapModelToBO(default(int), model);
				var record = await this.AdminRepository.Create(this.DalAdminMapper.MapBOToEF(bo));

				response.SetRecord(this.BolAdminMapper.MapBOToModel(this.DalAdminMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiAdminResponseModel>> Update(
			int id,
			ApiAdminRequestModel model)
		{
			var validationResult = await this.AdminModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolAdminMapper.MapModelToBO(id, model);
				await this.AdminRepository.Update(this.DalAdminMapper.MapBOToEF(bo));

				var record = await this.AdminRepository.Get(id);

				return new UpdateResponse<ApiAdminResponseModel>(this.BolAdminMapper.MapBOToModel(this.DalAdminMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiAdminResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.AdminModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.AdminRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>85af23973a8f1bdf598d43f72a152648</Hash>
</Codenesium>*/