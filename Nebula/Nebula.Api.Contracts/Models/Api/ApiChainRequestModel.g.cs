using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
	public partial class ApiChainRequestModel : AbstractApiRequestModel
	{
		public ApiChainRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int chainStatusId,
			Guid externalId,
			string name,
			int teamId)
		{
			this.ChainStatusId = chainStatusId;
			this.ExternalId = externalId;
			this.Name = name;
			this.TeamId = teamId;
		}

		[Required]
		[JsonProperty]
		public int ChainStatusId { get; private set; }

		[Required]
		[JsonProperty]
		public Guid ExternalId { get; private set; } = default(Guid);

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int TeamId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4aefd36333fcddec4ade6c756821b3e6</Hash>
</Codenesium>*/