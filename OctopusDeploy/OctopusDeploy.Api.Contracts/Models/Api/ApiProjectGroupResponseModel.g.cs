using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiProjectGroupResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string id,
			byte[] dataVersion,
			string jSON,
			string name)
		{
			this.Id = id;
			this.DataVersion = dataVersion;
			this.JSON = jSON;
			this.Name = name;
		}

		[Required]
		[JsonProperty]
		public byte[] DataVersion { get; private set; }

		[Required]
		[JsonProperty]
		public string Id { get; private set; }

		[Required]
		[JsonProperty]
		public string JSON { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>fbbbc41eab771d794b9b5ef68ddc20ad</Hash>
</Codenesium>*/