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
	public abstract class AbstractEmployeeDepartmentHistoryService: AbstractService
	{
		private IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository;
		private IApiEmployeeDepartmentHistoryRequestModelValidator employeeDepartmentHistoryModelValidator;
		private IBOLEmployeeDepartmentHistoryMapper BOLEmployeeDepartmentHistoryMapper;
		private IDALEmployeeDepartmentHistoryMapper DALEmployeeDepartmentHistoryMapper;
		private ILogger logger;

		public AbstractEmployeeDepartmentHistoryService(
			ILogger logger,
			IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository,
			IApiEmployeeDepartmentHistoryRequestModelValidator employeeDepartmentHistoryModelValidator,
			IBOLEmployeeDepartmentHistoryMapper bolemployeeDepartmentHistoryMapper,
			IDALEmployeeDepartmentHistoryMapper dalemployeeDepartmentHistoryMapper)
			: base()

		{
			this.employeeDepartmentHistoryRepository = employeeDepartmentHistoryRepository;
			this.employeeDepartmentHistoryModelValidator = employeeDepartmentHistoryModelValidator;
			this.BOLEmployeeDepartmentHistoryMapper = bolemployeeDepartmentHistoryMapper;
			this.DALEmployeeDepartmentHistoryMapper = dalemployeeDepartmentHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.employeeDepartmentHistoryRepository.All(skip, take, orderClause);

			return this.BOLEmployeeDepartmentHistoryMapper.MapBOToModel(this.DALEmployeeDepartmentHistoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEmployeeDepartmentHistoryResponseModel> Get(int businessEntityID)
		{
			var record = await employeeDepartmentHistoryRepository.Get(businessEntityID);

			return this.BOLEmployeeDepartmentHistoryMapper.MapBOToModel(this.DALEmployeeDepartmentHistoryMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiEmployeeDepartmentHistoryResponseModel>> Create(
			ApiEmployeeDepartmentHistoryRequestModel model)
		{
			CreateResponse<ApiEmployeeDepartmentHistoryResponseModel> response = new CreateResponse<ApiEmployeeDepartmentHistoryResponseModel>(await this.employeeDepartmentHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLEmployeeDepartmentHistoryMapper.MapModelToBO(default (int), model);
				var record = await this.employeeDepartmentHistoryRepository.Create(this.DALEmployeeDepartmentHistoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLEmployeeDepartmentHistoryMapper.MapBOToModel(this.DALEmployeeDepartmentHistoryMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiEmployeeDepartmentHistoryRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.employeeDepartmentHistoryModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				var bo = this.BOLEmployeeDepartmentHistoryMapper.MapModelToBO(businessEntityID, model);
				await this.employeeDepartmentHistoryRepository.Update(this.DALEmployeeDepartmentHistoryMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.employeeDepartmentHistoryModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.employeeDepartmentHistoryRepository.Delete(businessEntityID);
			}
			return response;
		}

		public async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> GetDepartmentID(short departmentID)
		{
			List<EmployeeDepartmentHistory> records = await this.employeeDepartmentHistoryRepository.GetDepartmentID(departmentID);

			return this.BOLEmployeeDepartmentHistoryMapper.MapBOToModel(this.DALEmployeeDepartmentHistoryMapper.MapEFToBO(records));
		}
		public async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> GetShiftID(int shiftID)
		{
			List<EmployeeDepartmentHistory> records = await this.employeeDepartmentHistoryRepository.GetShiftID(shiftID);

			return this.BOLEmployeeDepartmentHistoryMapper.MapBOToModel(this.DALEmployeeDepartmentHistoryMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>c9ebf46abf80658a4b2d172b69d50588</Hash>
</Codenesium>*/