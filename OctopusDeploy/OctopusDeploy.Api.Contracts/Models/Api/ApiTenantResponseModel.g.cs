using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiTenantResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        byte[] dataVersion,
                        string jSON,
                        string name,
                        string projectIds,
                        string tenantTags)
                {
                        this.Id = id;
                        this.DataVersion = dataVersion;
                        this.JSON = jSON;
                        this.Name = name;
                        this.ProjectIds = projectIds;
                        this.TenantTags = tenantTags;
                }

                [Required]
                [JsonProperty]
                public byte[] DataVersion { get; private set; }

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
                public string ProjectIds { get; private set; }

                [Required]
                [JsonProperty]
                public string TenantTags { get; private set; }
        }
}

/*<Codenesium>
    <Hash>38fba0f3b9c08e13dad4b2843312ea3f</Hash>
</Codenesium>*/