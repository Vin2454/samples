using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPipelineStepDestinationResponseModel: AbstractApiResponseModel
	{
		public ApiPipelineStepDestinationResponseModel() : base()
		{}

		public void SetProperties(
			int destinationId,
			int id,
			int pipelineStepId)
		{
			this.Id = id.ToInt();

			this.DestinationId = new ReferenceEntity<int>(destinationId,
			                                              nameof(ApiResponse.Destinations));
			this.PipelineStepId = new ReferenceEntity<int>(pipelineStepId,
			                                               nameof(ApiResponse.PipelineSteps));
		}

		public ReferenceEntity<int> DestinationId { get; set; }
		public int Id { get; set; }
		public ReferenceEntity<int> PipelineStepId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeDestinationIdValue { get; set; } = true;

		public bool ShouldSerializeDestinationId()
		{
			return this.ShouldSerializeDestinationIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePipelineStepIdValue { get; set; } = true;

		public bool ShouldSerializePipelineStepId()
		{
			return this.ShouldSerializePipelineStepIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeDestinationIdValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializePipelineStepIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>8d659c8f79a8e5ca111289114a56bd48</Hash>
</Codenesium>*/