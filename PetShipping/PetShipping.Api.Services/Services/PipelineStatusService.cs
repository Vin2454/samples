using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
        public partial class PipelineStatusService : AbstractPipelineStatusService, IPipelineStatusService
        {
                public PipelineStatusService(
                        ILogger<IPipelineStatusRepository> logger,
                        IPipelineStatusRepository pipelineStatusRepository,
                        IApiPipelineStatusRequestModelValidator pipelineStatusModelValidator,
                        IBOLPipelineStatusMapper bolpipelineStatusMapper,
                        IDALPipelineStatusMapper dalpipelineStatusMapper,
                        IBOLPipelineMapper bolPipelineMapper,
                        IDALPipelineMapper dalPipelineMapper
                        )
                        : base(logger,
                               pipelineStatusRepository,
                               pipelineStatusModelValidator,
                               bolpipelineStatusMapper,
                               dalpipelineStatusMapper,
                               bolPipelineMapper,
                               dalPipelineMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>573943424d719262ac71bdde3d8aa6b6</Hash>
</Codenesium>*/