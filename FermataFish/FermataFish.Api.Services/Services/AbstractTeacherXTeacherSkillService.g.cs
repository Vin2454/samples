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

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractTeacherXTeacherSkillService: AbstractService
	{
		private ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository;
		private IApiTeacherXTeacherSkillRequestModelValidator teacherXTeacherSkillModelValidator;
		private IBOLTeacherXTeacherSkillMapper BOLTeacherXTeacherSkillMapper;
		private IDALTeacherXTeacherSkillMapper DALTeacherXTeacherSkillMapper;
		private ILogger logger;

		public AbstractTeacherXTeacherSkillService(
			ILogger logger,
			ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository,
			IApiTeacherXTeacherSkillRequestModelValidator teacherXTeacherSkillModelValidator,
			IBOLTeacherXTeacherSkillMapper bolteacherXTeacherSkillMapper,
			IDALTeacherXTeacherSkillMapper dalteacherXTeacherSkillMapper)
			: base()

		{
			this.teacherXTeacherSkillRepository = teacherXTeacherSkillRepository;
			this.teacherXTeacherSkillModelValidator = teacherXTeacherSkillModelValidator;
			this.BOLTeacherXTeacherSkillMapper = bolteacherXTeacherSkillMapper;
			this.DALTeacherXTeacherSkillMapper = dalteacherXTeacherSkillMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTeacherXTeacherSkillResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.teacherXTeacherSkillRepository.All(skip, take, orderClause);

			return this.BOLTeacherXTeacherSkillMapper.MapBOToModel(this.DALTeacherXTeacherSkillMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTeacherXTeacherSkillResponseModel> Get(int id)
		{
			var record = await teacherXTeacherSkillRepository.Get(id);

			return this.BOLTeacherXTeacherSkillMapper.MapBOToModel(this.DALTeacherXTeacherSkillMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiTeacherXTeacherSkillResponseModel>> Create(
			ApiTeacherXTeacherSkillRequestModel model)
		{
			CreateResponse<ApiTeacherXTeacherSkillResponseModel> response = new CreateResponse<ApiTeacherXTeacherSkillResponseModel>(await this.teacherXTeacherSkillModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLTeacherXTeacherSkillMapper.MapModelToBO(default (int), model);
				var record = await this.teacherXTeacherSkillRepository.Create(this.DALTeacherXTeacherSkillMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLTeacherXTeacherSkillMapper.MapBOToModel(this.DALTeacherXTeacherSkillMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiTeacherXTeacherSkillRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.teacherXTeacherSkillModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLTeacherXTeacherSkillMapper.MapModelToBO(id, model);
				await this.teacherXTeacherSkillRepository.Update(this.DALTeacherXTeacherSkillMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.teacherXTeacherSkillModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.teacherXTeacherSkillRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>636f36f3afbbe615f974ea9735b77b14</Hash>
</Codenesium>*/