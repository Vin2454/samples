using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOMachine: AbstractBusinessObject
        {
                public BOMachine() : base()
                {
                }

                public void SetProperties(string id,
                                          string communicationStyle,
                                          string environmentIds,
                                          string fingerprint,
                                          bool isDisabled,
                                          string jSON,
                                          string machinePolicyId,
                                          string name,
                                          string relatedDocumentIds,
                                          string roles,
                                          string tenantIds,
                                          string tenantTags,
                                          string thumbprint)
                {
                        this.CommunicationStyle = communicationStyle;
                        this.EnvironmentIds = environmentIds;
                        this.Fingerprint = fingerprint;
                        this.Id = id;
                        this.IsDisabled = isDisabled;
                        this.JSON = jSON;
                        this.MachinePolicyId = machinePolicyId;
                        this.Name = name;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.Roles = roles;
                        this.TenantIds = tenantIds;
                        this.TenantTags = tenantTags;
                        this.Thumbprint = thumbprint;
                }

                public string CommunicationStyle { get; private set; }

                public string EnvironmentIds { get; private set; }

                public string Fingerprint { get; private set; }

                public string Id { get; private set; }

                public bool IsDisabled { get; private set; }

                public string JSON { get; private set; }

                public string MachinePolicyId { get; private set; }

                public string Name { get; private set; }

                public string RelatedDocumentIds { get; private set; }

                public string Roles { get; private set; }

                public string TenantIds { get; private set; }

                public string TenantTags { get; private set; }

                public string Thumbprint { get; private set; }
        }
}

/*<Codenesium>
    <Hash>0e7cb06ad0f4ef7282057706878eb1d6</Hash>
</Codenesium>*/