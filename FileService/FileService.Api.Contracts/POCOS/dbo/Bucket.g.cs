using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Spatial;

namespace FileServiceNS.Api.Contracts
{
	public partial class POCOBucket
	{
		public POCOBucket()
		{}

		public POCOBucket(Guid externalId,
		                  int id,
		                  string name)
		{
			this.ExternalId = externalId;
			this.Id = id.ToInt();
			this.Name = name;
		}

		public Guid ExternalId {get; set;}
		public int Id {get; set;}
		public string Name {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeExternalIdValue {get; set;} = true;

		public bool ShouldSerializeExternalId()
		{
			return ShouldSerializeExternalIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue {get; set;} = true;

		public bool ShouldSerializeId()
		{
			return ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeExternalIdValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNameValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>f704e9127281103ddce4b7e11214b93d</Hash>
</Codenesium>*/