using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiLibraryVariableSetResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string id,
			string contentType,
			string jSON,
			string name,
			string variableSetId)
		{
			this.Id = id;
			this.ContentType = contentType;
			this.JSON = jSON;
			this.Name = name;
			this.VariableSetId = variableSetId;
		}

		[Required]
		[JsonProperty]
		public string ContentType { get; private set; }

		[Required]
		[JsonProperty]
		public string Id { get; private set; }

		[Required]
		[JsonProperty]
		public string JSON { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public string VariableSetId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>58672eea0c0cbd7144848110f90611c3</Hash>
</Codenesium>*/