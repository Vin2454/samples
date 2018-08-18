using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("DashboardConfiguration", Schema="dbo")]
	public partial class DashboardConfiguration : AbstractEntity
	{
		public DashboardConfiguration()
		{
		}

		public virtual void SetProperties(
			string id,
			string includedEnvironmentIds,
			string includedProjectIds,
			string includedTenantIds,
			string includedTenantTags,
			string jSON)
		{
			this.Id = id;
			this.IncludedEnvironmentIds = includedEnvironmentIds;
			this.IncludedProjectIds = includedProjectIds;
			this.IncludedTenantIds = includedTenantIds;
			this.IncludedTenantTags = includedTenantTags;
			this.JSON = jSON;
		}

		[Key]
		[MaxLength(50)]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("IncludedEnvironmentIds")]
		public string IncludedEnvironmentIds { get; private set; }

		[Column("IncludedProjectIds")]
		public string IncludedProjectIds { get; private set; }

		[Column("IncludedTenantIds")]
		public string IncludedTenantIds { get; private set; }

		[Column("IncludedTenantTags")]
		public string IncludedTenantTags { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9e833db046f675cc8c6f9cfe0bb8e90c</Hash>
</Codenesium>*/