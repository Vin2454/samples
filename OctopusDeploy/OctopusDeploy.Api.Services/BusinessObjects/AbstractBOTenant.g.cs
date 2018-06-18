using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOTenant: AbstractBusinessObject
        {
                public AbstractBOTenant() : base()
                {
                }

                public virtual void SetProperties(string id,
                                                  byte[] dataVersion,
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

                public byte[] DataVersion { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public string ProjectIds { get; private set; }

                public string TenantTags { get; private set; }
        }
}

/*<Codenesium>
    <Hash>1bd5dd6897b63729ff60c5bb0f4a9d4d</Hash>
</Codenesium>*/