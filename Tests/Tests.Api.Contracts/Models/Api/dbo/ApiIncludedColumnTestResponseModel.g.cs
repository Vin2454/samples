using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Contracts
{
	public partial class ApiIncludedColumnTestResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			string name,
			string name2)
		{
			this.Id = id;
			this.Name = name;
			this.Name2 = name2;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public string Name2 { get; private set; }
	}
}

/*<Codenesium>
    <Hash>131c7174390c693cb247863850fafa62</Hash>
</Codenesium>*/