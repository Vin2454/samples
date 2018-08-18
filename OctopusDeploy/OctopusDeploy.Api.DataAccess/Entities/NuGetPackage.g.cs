using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("NuGetPackage", Schema="dbo")]
	public partial class NuGetPackage : AbstractEntity
	{
		public NuGetPackage()
		{
		}

		public virtual void SetProperties(
			string id,
			string jSON,
			string packageId,
			string version,
			int versionBuild,
			int versionMajor,
			int versionMinor,
			int versionRevision,
			string versionSpecial)
		{
			this.Id = id;
			this.JSON = jSON;
			this.PackageId = packageId;
			this.Version = version;
			this.VersionBuild = versionBuild;
			this.VersionMajor = versionMajor;
			this.VersionMinor = versionMinor;
			this.VersionRevision = versionRevision;
			this.VersionSpecial = versionSpecial;
		}

		[Key]
		[MaxLength(450)]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[MaxLength(100)]
		[Column("PackageId")]
		public string PackageId { get; private set; }

		[MaxLength(349)]
		[Column("Version")]
		public string Version { get; private set; }

		[Column("VersionBuild")]
		public int VersionBuild { get; private set; }

		[Column("VersionMajor")]
		public int VersionMajor { get; private set; }

		[Column("VersionMinor")]
		public int VersionMinor { get; private set; }

		[Column("VersionRevision")]
		public int VersionRevision { get; private set; }

		[MaxLength(250)]
		[Column("VersionSpecial")]
		public string VersionSpecial { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c22c7abc01a8d05746b11208a93e5045</Hash>
</Codenesium>*/