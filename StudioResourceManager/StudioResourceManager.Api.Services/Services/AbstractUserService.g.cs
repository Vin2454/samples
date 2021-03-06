using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractUserService : AbstractService
	{
		protected IUserRepository UserRepository { get; private set; }

		protected IApiUserRequestModelValidator UserModelValidator { get; private set; }

		protected IBOLUserMapper BolUserMapper { get; private set; }

		protected IDALUserMapper DalUserMapper { get; private set; }

		protected IBOLAdminMapper BolAdminMapper { get; private set; }

		protected IDALAdminMapper DalAdminMapper { get; private set; }

		protected IBOLStudentMapper BolStudentMapper { get; private set; }

		protected IDALStudentMapper DalStudentMapper { get; private set; }

		protected IBOLTeacherMapper BolTeacherMapper { get; private set; }

		protected IDALTeacherMapper DalTeacherMapper { get; private set; }

		private ILogger logger;

		public AbstractUserService(
			ILogger logger,
			IUserRepository userRepository,
			IApiUserRequestModelValidator userModelValidator,
			IBOLUserMapper bolUserMapper,
			IDALUserMapper dalUserMapper,
			IBOLAdminMapper bolAdminMapper,
			IDALAdminMapper dalAdminMapper,
			IBOLStudentMapper bolStudentMapper,
			IDALStudentMapper dalStudentMapper,
			IBOLTeacherMapper bolTeacherMapper,
			IDALTeacherMapper dalTeacherMapper)
			: base()
		{
			this.UserRepository = userRepository;
			this.UserModelValidator = userModelValidator;
			this.BolUserMapper = bolUserMapper;
			this.DalUserMapper = dalUserMapper;
			this.BolAdminMapper = bolAdminMapper;
			this.DalAdminMapper = dalAdminMapper;
			this.BolStudentMapper = bolStudentMapper;
			this.DalStudentMapper = dalStudentMapper;
			this.BolTeacherMapper = bolTeacherMapper;
			this.DalTeacherMapper = dalTeacherMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiUserResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.UserRepository.All(limit, offset);

			return this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiUserResponseModel> Get(int id)
		{
			var record = await this.UserRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiUserResponseModel>> Create(
			ApiUserRequestModel model)
		{
			CreateResponse<ApiUserResponseModel> response = new CreateResponse<ApiUserResponseModel>(await this.UserModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolUserMapper.MapModelToBO(default(int), model);
				var record = await this.UserRepository.Create(this.DalUserMapper.MapBOToEF(bo));

				response.SetRecord(this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiUserResponseModel>> Update(
			int id,
			ApiUserRequestModel model)
		{
			var validationResult = await this.UserModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolUserMapper.MapModelToBO(id, model);
				await this.UserRepository.Update(this.DalUserMapper.MapBOToEF(bo));

				var record = await this.UserRepository.Get(id);

				return new UpdateResponse<ApiUserResponseModel>(this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiUserResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.UserModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.UserRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiAdminResponseModel>> AdminsByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			List<Admin> records = await this.UserRepository.AdminsByUserId(userId, limit, offset);

			return this.BolAdminMapper.MapBOToModel(this.DalAdminMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiStudentResponseModel>> StudentsByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			List<Student> records = await this.UserRepository.StudentsByUserId(userId, limit, offset);

			return this.BolStudentMapper.MapBOToModel(this.DalStudentMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiTeacherResponseModel>> TeachersByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			List<Teacher> records = await this.UserRepository.TeachersByUserId(userId, limit, offset);

			return this.BolTeacherMapper.MapBOToModel(this.DalTeacherMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiUserResponseModel>> ByFamilyId(int familyId, int limit = int.MaxValue, int offset = 0)
		{
			List<User> records = await this.UserRepository.ByFamilyId(familyId, limit, offset);

			return this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>49560ce52220394e6e8637e4c7bce871</Hash>
</Codenesium>*/