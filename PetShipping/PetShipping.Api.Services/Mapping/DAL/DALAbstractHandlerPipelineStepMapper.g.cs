using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class DALAbstractHandlerPipelineStepMapper
        {
                public virtual HandlerPipelineStep MapBOToEF(
                        BOHandlerPipelineStep bo)
                {
                        HandlerPipelineStep efHandlerPipelineStep = new HandlerPipelineStep();

                        efHandlerPipelineStep.SetProperties(
                                bo.HandlerId,
                                bo.Id,
                                bo.PipelineStepId);
                        return efHandlerPipelineStep;
                }

                public virtual BOHandlerPipelineStep MapEFToBO(
                        HandlerPipelineStep ef)
                {
                        var bo = new BOHandlerPipelineStep();

                        bo.SetProperties(
                                ef.Id,
                                ef.HandlerId,
                                ef.PipelineStepId);
                        return bo;
                }

                public virtual List<BOHandlerPipelineStep> MapEFToBO(
                        List<HandlerPipelineStep> records)
                {
                        List<BOHandlerPipelineStep> response = new List<BOHandlerPipelineStep>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>e2ab40e63f0c78f64f9338efd1f03528</Hash>
</Codenesium>*/