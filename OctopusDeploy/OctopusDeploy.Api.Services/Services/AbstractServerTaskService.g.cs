using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractServerTaskService: AbstractService
        {
                private IServerTaskRepository serverTaskRepository;

                private IApiServerTaskRequestModelValidator serverTaskModelValidator;

                private IBOLServerTaskMapper bolServerTaskMapper;

                private IDALServerTaskMapper dalServerTaskMapper;

                private ILogger logger;

                public AbstractServerTaskService(
                        ILogger logger,
                        IServerTaskRepository serverTaskRepository,
                        IApiServerTaskRequestModelValidator serverTaskModelValidator,
                        IBOLServerTaskMapper bolServerTaskMapper,
                        IDALServerTaskMapper dalServerTaskMapper

                        )
                        : base()

                {
                        this.serverTaskRepository = serverTaskRepository;
                        this.serverTaskModelValidator = serverTaskModelValidator;
                        this.bolServerTaskMapper = bolServerTaskMapper;
                        this.dalServerTaskMapper = dalServerTaskMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiServerTaskResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.serverTaskRepository.All(limit, offset);

                        return this.bolServerTaskMapper.MapBOToModel(this.dalServerTaskMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiServerTaskResponseModel> Get(string id)
                {
                        var record = await this.serverTaskRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolServerTaskMapper.MapBOToModel(this.dalServerTaskMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiServerTaskResponseModel>> Create(
                        ApiServerTaskRequestModel model)
                {
                        CreateResponse<ApiServerTaskResponseModel> response = new CreateResponse<ApiServerTaskResponseModel>(await this.serverTaskModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolServerTaskMapper.MapModelToBO(default (string), model);
                                var record = await this.serverTaskRepository.Create(this.dalServerTaskMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolServerTaskMapper.MapBOToModel(this.dalServerTaskMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiServerTaskRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.serverTaskModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolServerTaskMapper.MapModelToBO(id, model);
                                await this.serverTaskRepository.Update(this.dalServerTaskMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.serverTaskModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.serverTaskRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<List<ApiServerTaskResponseModel>> GetDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(string description, DateTimeOffset queueTime, Nullable<DateTimeOffset> startTime, Nullable<DateTimeOffset> completedTime, string errorMessage, string concurrencyTag, bool hasPendingInterruptions, bool hasWarningsOrErrors, int durationSeconds, string jSON, string state, string name, string projectId, string environmentId, string tenantId, string serverNodeId)
                {
                        List<ServerTask> records = await this.serverTaskRepository.GetDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(description, queueTime, startTime, completedTime, errorMessage, concurrencyTag, hasPendingInterruptions, hasWarningsOrErrors, durationSeconds, jSON, state, name, projectId, environmentId, tenantId, serverNodeId);

                        return this.bolServerTaskMapper.MapBOToModel(this.dalServerTaskMapper.MapEFToBO(records));
                }
                public async Task<List<ApiServerTaskResponseModel>> GetStateConcurrencyTag(string state, string concurrencyTag)
                {
                        List<ServerTask> records = await this.serverTaskRepository.GetStateConcurrencyTag(state, concurrencyTag);

                        return this.bolServerTaskMapper.MapBOToModel(this.dalServerTaskMapper.MapEFToBO(records));
                }
                public async Task<List<ApiServerTaskResponseModel>> GetNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(string name, string description, Nullable<DateTimeOffset> startTime, Nullable<DateTimeOffset> completedTime, string errorMessage, bool hasWarningsOrErrors, string projectId, string environmentId, string tenantId, int durationSeconds, string jSON, DateTimeOffset queueTime, string state, string concurrencyTag, bool hasPendingInterruptions, string serverNodeId)
                {
                        List<ServerTask> records = await this.serverTaskRepository.GetNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(name, description, startTime, completedTime, errorMessage, hasWarningsOrErrors, projectId, environmentId, tenantId, durationSeconds, jSON, queueTime, state, concurrencyTag, hasPendingInterruptions, serverNodeId);

                        return this.bolServerTaskMapper.MapBOToModel(this.dalServerTaskMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>9ecf7babcebdc7909b6f9fc4dd8046d4</Hash>
</Codenesium>*/