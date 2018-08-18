using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPipelineStepNoteRequestModel : AbstractApiRequestModel
	{
		public ApiPipelineStepNoteRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int employeeId,
			string note,
			int pipelineStepId)
		{
			this.EmployeeId = employeeId;
			this.Note = note;
			this.PipelineStepId = pipelineStepId;
		}

		[JsonProperty]
		public int EmployeeId { get; private set; }

		[JsonProperty]
		public string Note { get; private set; }

		[JsonProperty]
		public int PipelineStepId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e4a3826df056f6c67b65263d7058d379</Hash>
</Codenesium>*/