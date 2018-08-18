using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPipelineResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			int pipelineStatusId,
			int saleId)
		{
			this.Id = id;
			this.PipelineStatusId = pipelineStatusId;
			this.SaleId = saleId;

			this.PipelineStatusIdEntity = nameof(ApiResponse.PipelineStatus);
		}

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public int PipelineStatusId { get; private set; }

		[JsonProperty]
		public string PipelineStatusIdEntity { get; set; }

		[Required]
		[JsonProperty]
		public int SaleId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c05e5d8c450ed25cd01383d22e4286d6</Hash>
</Codenesium>*/