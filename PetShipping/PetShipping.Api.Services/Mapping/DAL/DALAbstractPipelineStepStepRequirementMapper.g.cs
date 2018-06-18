using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class DALAbstractPipelineStepStepRequirementMapper
        {
                public virtual PipelineStepStepRequirement MapBOToEF(
                        BOPipelineStepStepRequirement bo)
                {
                        PipelineStepStepRequirement efPipelineStepStepRequirement = new PipelineStepStepRequirement();

                        efPipelineStepStepRequirement.SetProperties(
                                bo.Details,
                                bo.Id,
                                bo.PipelineStepId,
                                bo.RequirementMet);
                        return efPipelineStepStepRequirement;
                }

                public virtual BOPipelineStepStepRequirement MapEFToBO(
                        PipelineStepStepRequirement ef)
                {
                        var bo = new BOPipelineStepStepRequirement();

                        bo.SetProperties(
                                ef.Id,
                                ef.Details,
                                ef.PipelineStepId,
                                ef.RequirementMet);
                        return bo;
                }

                public virtual List<BOPipelineStepStepRequirement> MapEFToBO(
                        List<PipelineStepStepRequirement> records)
                {
                        List<BOPipelineStepStepRequirement> response = new List<BOPipelineStepStepRequirement>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>5afb52157da437d26131c15920685aaa</Hash>
</Codenesium>*/