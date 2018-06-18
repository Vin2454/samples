using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public abstract class AbstractMachineRefTeamService: AbstractService
        {
                private IMachineRefTeamRepository machineRefTeamRepository;

                private IApiMachineRefTeamRequestModelValidator machineRefTeamModelValidator;

                private IBOLMachineRefTeamMapper bolMachineRefTeamMapper;

                private IDALMachineRefTeamMapper dalMachineRefTeamMapper;

                private ILogger logger;

                public AbstractMachineRefTeamService(
                        ILogger logger,
                        IMachineRefTeamRepository machineRefTeamRepository,
                        IApiMachineRefTeamRequestModelValidator machineRefTeamModelValidator,
                        IBOLMachineRefTeamMapper bolMachineRefTeamMapper,
                        IDALMachineRefTeamMapper dalMachineRefTeamMapper

                        )
                        : base()

                {
                        this.machineRefTeamRepository = machineRefTeamRepository;
                        this.machineRefTeamModelValidator = machineRefTeamModelValidator;
                        this.bolMachineRefTeamMapper = bolMachineRefTeamMapper;
                        this.dalMachineRefTeamMapper = dalMachineRefTeamMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiMachineRefTeamResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.machineRefTeamRepository.All(limit, offset);

                        return this.bolMachineRefTeamMapper.MapBOToModel(this.dalMachineRefTeamMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiMachineRefTeamResponseModel> Get(int id)
                {
                        var record = await this.machineRefTeamRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolMachineRefTeamMapper.MapBOToModel(this.dalMachineRefTeamMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiMachineRefTeamResponseModel>> Create(
                        ApiMachineRefTeamRequestModel model)
                {
                        CreateResponse<ApiMachineRefTeamResponseModel> response = new CreateResponse<ApiMachineRefTeamResponseModel>(await this.machineRefTeamModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolMachineRefTeamMapper.MapModelToBO(default (int), model);
                                var record = await this.machineRefTeamRepository.Create(this.dalMachineRefTeamMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolMachineRefTeamMapper.MapBOToModel(this.dalMachineRefTeamMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiMachineRefTeamRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.machineRefTeamModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolMachineRefTeamMapper.MapModelToBO(id, model);
                                await this.machineRefTeamRepository.Update(this.dalMachineRefTeamMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.machineRefTeamModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.machineRefTeamRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>a891c995ac9c1b352c88db39e15658ee</Hash>
</Codenesium>*/