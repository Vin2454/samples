using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiHandlerPipelineStepRequestModel : AbstractApiRequestModel
        {
                public ApiHandlerPipelineStepRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int handlerId,
                        int pipelineStepId)
                {
                        this.HandlerId = handlerId;
                        this.PipelineStepId = pipelineStepId;
                }

                private int handlerId;

                [Required]
                public int HandlerId
                {
                        get
                        {
                                return this.handlerId;
                        }

                        set
                        {
                                this.handlerId = value;
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
    <Hash>3951261d70d0a413e0d39a5059566427</Hash>
</Codenesium>*/