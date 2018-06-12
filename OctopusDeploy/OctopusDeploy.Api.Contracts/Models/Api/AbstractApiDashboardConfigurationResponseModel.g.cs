using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiDashboardConfigurationResponseModel: AbstractApiResponseModel
        {
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

                public string Id { get; private set; }

                public string IncludedEnvironmentIds { get; private set; }

                public string IncludedProjectIds { get; private set; }

                public string IncludedTenantIds { get; private set; }

                public string IncludedTenantTags { get; private set; }

                public string JSON { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIncludedEnvironmentIdsValue { get; set; } = true;

                public bool ShouldSerializeIncludedEnvironmentIds()
                {
                        return this.ShouldSerializeIncludedEnvironmentIdsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIncludedProjectIdsValue { get; set; } = true;

                public bool ShouldSerializeIncludedProjectIds()
                {
                        return this.ShouldSerializeIncludedProjectIdsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIncludedTenantIdsValue { get; set; } = true;

                public bool ShouldSerializeIncludedTenantIds()
                {
                        return this.ShouldSerializeIncludedTenantIdsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIncludedTenantTagsValue { get; set; } = true;

                public bool ShouldSerializeIncludedTenantTags()
                {
                        return this.ShouldSerializeIncludedTenantTagsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeJSONValue { get; set; } = true;

                public bool ShouldSerializeJSON()
                {
                        return this.ShouldSerializeJSONValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeIncludedEnvironmentIdsValue = false;
                        this.ShouldSerializeIncludedProjectIdsValue = false;
                        this.ShouldSerializeIncludedTenantIdsValue = false;
                        this.ShouldSerializeIncludedTenantTagsValue = false;
                        this.ShouldSerializeJSONValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>97e95ec8931c1cbd18d6187c7a76d64e</Hash>
</Codenesium>*/