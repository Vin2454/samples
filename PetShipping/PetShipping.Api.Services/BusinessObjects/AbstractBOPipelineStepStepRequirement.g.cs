using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractBOPipelineStepStepRequirement : AbstractBusinessObject
	{
		public AbstractBOPipelineStepStepRequirement()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string details,
		                                  int pipelineStepId,
		                                  bool requirementMet)
		{
			this.Details = details;
			this.Id = id;
			this.PipelineStepId = pipelineStepId;
			this.RequirementMet = requirementMet;
		}

		public string Details { get; private set; }

		public int Id { get; private set; }

		public int PipelineStepId { get; private set; }

		public bool RequirementMet { get; private set; }
	}
}

/*<Codenesium>
    <Hash>dbda8a76258416d0a1f160557366eff9</Hash>
</Codenesium>*/