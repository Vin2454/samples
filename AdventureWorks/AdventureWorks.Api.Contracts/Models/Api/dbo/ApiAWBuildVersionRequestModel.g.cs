using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiAWBuildVersionRequestModel : AbstractApiRequestModel
        {
                public ApiAWBuildVersionRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string database_Version,
                        DateTime modifiedDate,
                        DateTime versionDate)
                {
                        this.Database_Version = database_Version;
                        this.ModifiedDate = modifiedDate;
                        this.VersionDate = versionDate;
                }

                private string database_Version;

                [Required]
                public string Database_Version
                {
                        get
                        {
                                return this.database_Version;
                        }

                        set
                        {
                                this.database_Version = value;
                        }
                }

                private DateTime modifiedDate;

                [Required]
                public DateTime ModifiedDate
                {
                        get
                        {
                                return this.modifiedDate;
                        }

                        set
                        {
                                this.modifiedDate = value;
                        }
                }

                private DateTime versionDate;

                [Required]
                public DateTime VersionDate
                {
                        get
                        {
                                return this.versionDate;
                        }

                        set
                        {
                                this.versionDate = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>d8cac2dc4a7f7099230c5fa0b5f61a81</Hash>
</Codenesium>*/