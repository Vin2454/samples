using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiAWBuildVersionResponseModel: AbstractApiResponseModel
        {
                public ApiAWBuildVersionResponseModel() : base()
                {
                }

                public void SetProperties(
                        string database_Version,
                        DateTime modifiedDate,
                        int systemInformationID,
                        DateTime versionDate)
                {
                        this.Database_Version = database_Version;
                        this.ModifiedDate = modifiedDate;
                        this.SystemInformationID = systemInformationID;
                        this.VersionDate = versionDate;
                }

                public string Database_Version { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int SystemInformationID { get; private set; }

                public DateTime VersionDate { get; private set; }

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
    <Hash>8d82124d328bf0ac29181418163ed3eb</Hash>
</Codenesium>*/