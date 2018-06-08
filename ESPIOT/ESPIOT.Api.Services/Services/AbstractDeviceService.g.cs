using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Services
{
        public abstract class AbstractDeviceService: AbstractService
        {
                private IDeviceRepository deviceRepository;

                private IApiDeviceRequestModelValidator deviceModelValidator;

                private IBOLDeviceMapper bolDeviceMapper;

                private IDALDeviceMapper dalDeviceMapper;

                private ILogger logger;

                public AbstractDeviceService(
                        ILogger logger,
                        IDeviceRepository deviceRepository,
                        IApiDeviceRequestModelValidator deviceModelValidator,
                        IBOLDeviceMapper boldeviceMapper,
                        IDALDeviceMapper daldeviceMapper)
                        : base()

                {
                        this.deviceRepository = deviceRepository;
                        this.deviceModelValidator = deviceModelValidator;
                        this.bolDeviceMapper = boldeviceMapper;
                        this.dalDeviceMapper = daldeviceMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiDeviceResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.deviceRepository.All(skip, take, orderClause);

                        return this.bolDeviceMapper.MapBOToModel(this.dalDeviceMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiDeviceResponseModel> Get(int id)
                {
                        var record = await this.deviceRepository.Get(id);

                        return this.bolDeviceMapper.MapBOToModel(this.dalDeviceMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiDeviceResponseModel>> Create(
                        ApiDeviceRequestModel model)
                {
                        CreateResponse<ApiDeviceResponseModel> response = new CreateResponse<ApiDeviceResponseModel>(await this.deviceModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolDeviceMapper.MapModelToBO(default (int), model);
                                var record = await this.deviceRepository.Create(this.dalDeviceMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolDeviceMapper.MapBOToModel(this.dalDeviceMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiDeviceRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.deviceModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolDeviceMapper.MapModelToBO(id, model);
                                await this.deviceRepository.Update(this.dalDeviceMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.deviceModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.deviceRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiDeviceResponseModel> GetPublicId(Guid publicId)
                {
                        Device record = await this.deviceRepository.GetPublicId(publicId);

                        return this.bolDeviceMapper.MapBOToModel(this.dalDeviceMapper.MapEFToBO(record));
                }
        }
}

/*<Codenesium>
    <Hash>3167be6c722a316aba62e1fe78369c09</Hash>
</Codenesium>*/