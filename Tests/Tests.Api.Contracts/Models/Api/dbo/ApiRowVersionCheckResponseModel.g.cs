using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Contracts
{
        public partial class ApiRowVersionCheckResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string name,
                        Guid rowVersion)
                {
                        this.Id = id;
                        this.Name = name;
                        this.RowVersion = rowVersion;
                }

                [JsonProperty]
                public int Id { get; private set; }

                [JsonProperty]
                public string Name { get; private set; }

                [JsonProperty]
                public Guid RowVersion { get; private set; }
        }
}

/*<Codenesium>
    <Hash>2a16cde296a53e2bc532533189620501</Hash>
</Codenesium>*/