using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace NebulaNS.Api.DataAccess
{
	[Table("VersionInfo", Schema="dbo")]
	public partial class EFVersionInfo: AbstractEntityFrameworkPOCO
	{
		public EFVersionInfo()
		{}

		public void SetProperties(
			long version,
			Nullable<DateTime> appliedOn,
			string description)
		{
			this.AppliedOn = appliedOn.ToNullableDateTime();
			this.Description = description.ToString();
			this.Version = version.ToLong();
		}

		[Column("AppliedOn", TypeName="datetime")]
		public Nullable<DateTime> AppliedOn { get; set; }

		[Column("Description", TypeName="nvarchar(1024)")]
		public string Description { get; set; }

		[Key]
		[Column("Version", TypeName="bigint")]
		public long Version { get; set; }
	}
}

/*<Codenesium>
    <Hash>bd634db786e948ba3983ca21c2389c4f</Hash>
</Codenesium>*/