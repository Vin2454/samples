using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Contracts
{
	public partial class ApiTimestampCheckRequestModel : AbstractApiRequestModel
	{
		public ApiTimestampCheckRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string name,
			byte[] timestamp)
		{
			this.Name = name;
			this.Timestamp = timestamp;
		}

		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public byte[] Timestamp { get; private set; }
	}
}

/*<Codenesium>
    <Hash>328fb046491fe4fbf942a3701690410c</Hash>
</Codenesium>*/