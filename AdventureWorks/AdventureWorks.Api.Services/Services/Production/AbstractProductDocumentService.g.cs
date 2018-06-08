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
        public abstract class AbstractProductDocumentService: AbstractService
        {
                private IProductDocumentRepository productDocumentRepository;

                private IApiProductDocumentRequestModelValidator productDocumentModelValidator;

                private IBOLProductDocumentMapper bolProductDocumentMapper;

                private IDALProductDocumentMapper dalProductDocumentMapper;

                private ILogger logger;

                public AbstractProductDocumentService(
                        ILogger logger,
                        IProductDocumentRepository productDocumentRepository,
                        IApiProductDocumentRequestModelValidator productDocumentModelValidator,
                        IBOLProductDocumentMapper bolproductDocumentMapper,
                        IDALProductDocumentMapper dalproductDocumentMapper)
                        : base()

                {
                        this.productDocumentRepository = productDocumentRepository;
                        this.productDocumentModelValidator = productDocumentModelValidator;
                        this.bolProductDocumentMapper = bolproductDocumentMapper;
                        this.dalProductDocumentMapper = dalproductDocumentMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProductDocumentResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.productDocumentRepository.All(skip, take, orderClause);

                        return this.bolProductDocumentMapper.MapBOToModel(this.dalProductDocumentMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProductDocumentResponseModel> Get(int productID)
                {
                        var record = await this.productDocumentRepository.Get(productID);

                        return this.bolProductDocumentMapper.MapBOToModel(this.dalProductDocumentMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiProductDocumentResponseModel>> Create(
                        ApiProductDocumentRequestModel model)
                {
                        CreateResponse<ApiProductDocumentResponseModel> response = new CreateResponse<ApiProductDocumentResponseModel>(await this.productDocumentModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProductDocumentMapper.MapModelToBO(default (int), model);
                                var record = await this.productDocumentRepository.Create(this.dalProductDocumentMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolProductDocumentMapper.MapBOToModel(this.dalProductDocumentMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int productID,
                        ApiProductDocumentRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.productDocumentModelValidator.ValidateUpdateAsync(productID, model));

                        if (response.Success)
                        {
                                var bo = this.bolProductDocumentMapper.MapModelToBO(productID, model);
                                await this.productDocumentRepository.Update(this.dalProductDocumentMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int productID)
                {
                        ActionResponse response = new ActionResponse(await this.productDocumentModelValidator.ValidateDeleteAsync(productID));

                        if (response.Success)
                        {
                                await this.productDocumentRepository.Delete(productID);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>5106743bb82747b09a307d9d010ac89b</Hash>
</Codenesium>*/