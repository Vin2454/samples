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
        public abstract class AbstractChainService: AbstractService
        {
                private IChainRepository chainRepository;

                private IApiChainRequestModelValidator chainModelValidator;

                private IBOLChainMapper bolChainMapper;

                private IDALChainMapper dalChainMapper;

                private ILogger logger;

                public AbstractChainService(
                        ILogger logger,
                        IChainRepository chainRepository,
                        IApiChainRequestModelValidator chainModelValidator,
                        IBOLChainMapper bolchainMapper,
                        IDALChainMapper dalchainMapper)
                        : base()

                {
                        this.chainRepository = chainRepository;
                        this.chainModelValidator = chainModelValidator;
                        this.bolChainMapper = bolchainMapper;
                        this.dalChainMapper = dalchainMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiChainResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.chainRepository.All(skip, take, orderClause);

                        return this.bolChainMapper.MapBOToModel(this.dalChainMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiChainResponseModel> Get(int id)
                {
                        var record = await this.chainRepository.Get(id);

                        return this.bolChainMapper.MapBOToModel(this.dalChainMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiChainResponseModel>> Create(
                        ApiChainRequestModel model)
                {
                        CreateResponse<ApiChainResponseModel> response = new CreateResponse<ApiChainResponseModel>(await this.chainModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolChainMapper.MapModelToBO(default (int), model);
                                var record = await this.chainRepository.Create(this.dalChainMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolChainMapper.MapBOToModel(this.dalChainMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiChainRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.chainModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolChainMapper.MapModelToBO(id, model);
                                await this.chainRepository.Update(this.dalChainMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.chainModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.chainRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>37ebfb542a4630f71b912ffc1f481a11</Hash>
</Codenesium>*/