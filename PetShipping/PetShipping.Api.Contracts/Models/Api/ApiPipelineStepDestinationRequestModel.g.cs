using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiPipelineStepDestinationRequestModel : AbstractApiRequestModel
        {
                public ApiPipelineStepDestinationRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int destinationId,
                        int pipelineStepId)
                {
                        this.DestinationId = destinationId;
                        this.PipelineStepId = pipelineStepId;
                }

                private int destinationId;

                [Required]
                public int DestinationId
                {
                        get
                        {
                                return this.destinationId;
                        }

                        set
                        {
                                this.destinationId = value;
                        }
                }

                private int pipelineStepId;

                [Required]
                public int PipelineStepId
                {
                        get
                        {
                                return this.pipelineStepId;
                        }

                        set
                        {
                                this.pipelineStepId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>8845c4c8be2c07d5c5efde3b9577575f</Hash>
</Codenesium>*/