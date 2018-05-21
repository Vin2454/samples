using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOAWBuildVersion: AbstractPOCO
	{
		public POCOAWBuildVersion() : base()
		{}

		public POCOAWBuildVersion(
			string database_Version,
			DateTime modifiedDate,
			int systemInformationID,
			DateTime versionDate)
		{
			this.Database_Version = database_Version;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.SystemInformationID = systemInformationID.ToInt();
			this.VersionDate = versionDate.ToDateTime();
		}

		public string Database_Version { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int SystemInformationID { get; set; }
		public DateTime VersionDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeDatabase_VersionValue { get; set; } = true;

		public bool ShouldSerializeDatabase_Version()
		{
			return this.ShouldSerializeDatabase_VersionValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSystemInformationIDValue { get; set; } = true;

		public bool ShouldSerializeSystemInformationID()
		{
			return this.ShouldSerializeSystemInformationIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeVersionDateValue { get; set; } = true;

		public bool ShouldSerializeVersionDate()
		{
			return this.ShouldSerializeVersionDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeDatabase_VersionValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeSystemInformationIDValue = false;
			this.ShouldSerializeVersionDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>82a58c8287424a03dba67849923a87d2</Hash>
</Codenesium>*/