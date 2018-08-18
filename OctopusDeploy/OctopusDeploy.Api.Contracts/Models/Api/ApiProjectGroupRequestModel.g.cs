using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiProjectGroupRequestModel : AbstractApiRequestModel
	{
		public ApiProjectGroupRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			byte[] dataVersion,
			string jSON,
			string name)
		{
			this.DataVersion = dataVersion;
			this.JSON = jSON;
			this.Name = name;
		}

		[JsonProperty]
		public byte[] DataVersion { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f6c3d4842841614606a46d805a5aac47</Hash>
</Codenesium>*/