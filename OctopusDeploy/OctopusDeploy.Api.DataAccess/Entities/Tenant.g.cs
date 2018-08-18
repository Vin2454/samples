using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("Tenant", Schema="dbo")]
	public partial class Tenant : AbstractEntity
	{
		public Tenant()
		{
		}

		public virtual void SetProperties(
			byte[] dataVersion,
			string id,
			string jSON,
			string name,
			string projectIds,
			string tenantTags)
		{
			this.DataVersion = dataVersion;
			this.Id = id;
			this.JSON = jSON;
			this.Name = name;
			this.ProjectIds = projectIds;
			this.TenantTags = tenantTags;
		}

		[Column("DataVersion")]
		public byte[] DataVersion { get; private set; }

		[Key]
		[MaxLength(50)]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[MaxLength(200)]
		[Column("Name")]
		public string Name { get; private set; }

		[Column("ProjectIds")]
		public string ProjectIds { get; private set; }

		[Column("TenantTags")]
		public string TenantTags { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f020c9bf1b26e2c00d1c32b1ae16bf5e</Hash>
</Codenesium>*/